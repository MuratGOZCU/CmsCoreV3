using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using CmsCoreV2.Data;
using CmsCoreV2.Models;
using CmsCoreV2.Services;
using Microsoft.AspNetCore.Http;
using Z.EntityFramework.Plus;
using SaasKit.Multitenancy;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace CmsCoreV2.Controllers
{
    public class HomeController : Controller
    {
        protected readonly AppTenant tenant;
        private readonly ApplicationDbContext _context;
        private readonly IFeedbackService feedbackService;
        public HomeController(ApplicationDbContext context, IFeedbackService _feedbackService, ITenant<AppTenant> _tenant)
        {
            _context = context;
            this.feedbackService = _feedbackService;
            this.tenant = _tenant.Value;
        }
        public string GetCategoryName(long id)
        {
            var postcat = _context.SetFiltered<PostCategory>().ToList();
            var c = _context.SetFiltered<PostPostCategory>().Where(w => w.PostId == id).FirstOrDefault();
            if (c!=null) { 
                var pcId = c.PostCategoryId;
                var val = postcat.FirstOrDefault(p => p.Id == pcId).Name;
                return val;
            }
            return "";
        }
        public IActionResult RedirectToNewUrl(string oldUrl)
        {
            return Redirect(HttpContext.Items["NewUrl"].ToString());
        }
        public IActionResult Index(string slug, string culture,string message="")
        { 
            if (culture == "no")
            {
                return Redirect("/tr");
            }
            ViewData["Culture"] = culture;
            ViewBag.PageScript = "";
            HttpContext.Items["Culture"] = culture;
            slug = slug.ToLower();
            ViewBag.Popup = _context.SetFiltered<Popup>().Where(w => w.PageSlug == slug && w.IsPublished == true && w.PublishDate <= DateTime.Now && (w.FinishDate.HasValue ? w.FinishDate > DateTime.Now : true)).OrderByDescending(o => o.PublishDate).FirstOrDefault();
            if (message == "subscriptionSuccessful")
            {
                ViewBag.SubscribeMessage = "E-bülten kaydınız yapılmıştır, teşekkür ederiz.";
            }
            else if (message == "subscriptionUnsuccessful")
            {
                ViewBag.SubscribeMessage = "E-bülten kaydınız mevcuttur. Mail adresinizi kontrol ediniz.";
            }
            var setting = _context.SetFiltered<Setting>().FirstOrDefault();
            ViewBag.MapLat = setting.MapLat;
            ViewBag.MapLon = setting.MapLon;
            ViewBag.MapTitle = setting.MapTitle;
            ViewBag.GoogleAnalytics = setting.GoogleAnalytics;
            ViewBag.HeaderScript = setting.HeaderString;
            ViewBag.FooterScript = setting.FooterScript;
            var page = _context.SetFiltered<Page>().Include(i=> i.Language).FirstOrDefault(p => p.Slug.ToLower() == slug && p.Language.Culture== culture);
            if (page == null || page.IsPublished == false)
            {
                var post = _context.SetFiltered<Post>().FirstOrDefault(p => p.Slug.ToLower() == slug);
                if (post == null)
                {
                    ViewData["Title"] = "404 - Sayfa bulunamadı";
                    ViewData["Description"] = "Aradığınız sayfa adresi değiştirilmiş, yanlış ya da silinmiş. Site aramasını kullanarak sayfayı arayabilirsiniz.";
                    ViewData["Keywords"] = "404";
                    return View("Page404");
                }
                else
                {
                    if (post == null || post.IsPublished == false)
                    {
                        ViewData["Title"] = "404 - Sayfa bulunamadı";
                        ViewData["Description"] = "Aradığınız sayfa adresi değiştirilmiş, yanlış ya da silinmiş. Site aramasını kullanarak sayfa arayabilirsiniz.";
                        ViewData["Keywords"] = "404";
                        return View("Page404");
                    }
                    PostViewModel postVM = new PostViewModel();
                    postVM.Id = post.Id;
                    postVM.Title = post.Title;
                    postVM.Slug = post.Slug;
                    postVM.Body = post.Body;
                    postVM.CategoryName = GetCategoryName(post.Id);
                    postVM.Description = post.Description;
                    postVM.IsPublished = post.IsPublished;
                    postVM.PublishDate = post.PublishDate;
                    postVM.CreateDate = post.CreateDate;
                    postVM.SeoTitle = post.SeoTitle;
                    postVM.SeoDescription = post.SeoDescription;
                    postVM.SeoKeywords = post.SeoKeywords;
                    postVM.Photo = post.Photo;
                    postVM.HeaderScript = post.HeaderScript;
                    
                    ViewData["Title"] = post.SeoTitle;
                    ViewData["Description"] = post.SeoDescription;
                    ViewData["Keywords"] = post.SeoKeywords;
                    post.ViewCount++;
                    postVM.ViewCount = post.ViewCount;

                    _context.Update(post);
                    _context.SaveChanges();
                    return View("Post", postVM);
                }
            }
            else
            {
                if (page.IsPublished == false)
                {
                    ViewData["Title"] = "404 - Sayfa bulunamadı";
                    ViewData["Description"] = "Aradığınız sayfa adresi değiştirilmiş, yanlış ya da silinmiş. Site aramasını kullanarak sayfayı arayabilirsiniz";
                    ViewData["Keywords"] = "404";
                    return View("Page404");
                }
                
                PageViewModel pageVM = new PageViewModel();
                pageVM.Id = page.Id;
                pageVM.Title = page.Title;
                pageVM.Slug = page.Slug;
                pageVM.Body = page.Body;
                pageVM.Photo = page.Photo;
                pageVM.LayoutTemplate = page.LayoutTemplate;
                pageVM.HeaderScript = page.HeaderScript;
                ViewBag.PageScript = page.HeaderScript;
                pageVM.Meta1 = page.Meta1;
                pageVM.Meta2 = page.Meta2;
                pageVM.Template = page.Template;
                pageVM.SeoTitle = page.SeoTitle;
                pageVM.SeoKeywords = page.SeoKeywords;
                pageVM.SeoDescription = page.SeoDescription;

                ViewData["Search"] = Request.Query["query"].ToString();
                ViewData["Title"] = page.SeoTitle;
                ViewData["Description"] = page.SeoDescription;
                ViewData["Keywords"] = page.SeoKeywords;
                page.ViewCount++;
                _context.Update(page);
                _context.SaveChanges();
                pageVM.ViewCount = page.ViewCount;
                if (!String.IsNullOrEmpty(page.Template))
                {
                    
                    return View(page.Template, pageVM);
                }
                return View(pageVM);
            }
        }

        
        public IActionResult Page404()
        {
            return View();
        }

        public IActionResult kindergarten()
        {
            return View();
        }

        public IActionResult Successful(int id)
        {
            ViewBag.FormClosingDescription = _context.Forms.Where(f => f.Id == id).FirstOrDefault()?.ClosingDescription;
            return View("Successful");
        }
        public ActionResult RedirectToDefaultLanguage()
        {
            var culture = CurrentCulture;
            if (culture == "")
            {
                culture = "tr";
            }

            return RedirectToAction("Index", new { culture = culture });
        }
        private string _currentCulture;
        private string CurrentCulture
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentCulture))
                {
                    return _currentCulture;
                }



                if (string.IsNullOrEmpty(_currentCulture))
                {
                    var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentCulture = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower();
                }

                return _currentCulture;
            }
        }
       
        // gönderilen form önce burada işlenir
        [HttpPost]
        public IActionResult PostForm(IFormCollection formCollection,IFormFile[] upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.Length > 0)
                {
                    bool redirect = false;
                    foreach (var file in upload)
                    {
                        if (!(Path.GetExtension(file.FileName) == ".jpg" || Path.GetExtension(file.FileName) == ".jpeg" || Path.GetExtension(file.FileName) == ".png" || Path.GetExtension(file.FileName) == ".doc"
                           || Path.GetExtension(file.FileName) == ".pdf"
                           || Path.GetExtension(file.FileName) == ".rtf"
                           || Path.GetExtension(file.FileName) == ".docx"))
                        {
                            redirect = true;
                        }
                    }
                    if (redirect)
                    {
                        Redirect(Request.Headers["Referer"].ToString() + "?message=Dosya uzantısı izin verilen uzantılardan olmalıdır.");
                    }
                }
                var result = feedbackService.FeedbackPost(formCollection, Request.HttpContext.Connection.RemoteIpAddress.ToString(), tenant.AppTenantId, upload);
                if (result == false)
                {
                    return Redirect("/tr/form/" + formCollection["Slug"]);
                }
                TempData["Referer"] = Request.Headers["Referer"].ToString();
                return RedirectToAction("Successful", new { id = formCollection["FormId"]});
            }
            return Redirect(Request.Headers["Referer"].ToString()+"?message=Gönderdiğiniz formda geçersiz alanlar var");
        }

        [HttpPost]
        public IActionResult PostFormAjax(IFormCollection formCollection, IFormFile[] upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.Length > 0)
                {
                    foreach (var file in upload)
                    {
                        if (!(Path.GetExtension(file.FileName) == ".jpg" || Path.GetExtension(file.FileName) == ".jpeg" || Path.GetExtension(file.FileName) == ".png" || Path.GetExtension(file.FileName) == ".doc"
                           || Path.GetExtension(file.FileName) == ".pdf"
                           || Path.GetExtension(file.FileName) == ".rtf"
                           || Path.GetExtension(file.FileName) == ".docx"))
                        {
                            return Json(new { response = "danger", message = "Dosya uzantısı geçersiz" });
                        }
                    }
                }
                feedbackService.FeedbackPost(formCollection, Request.HttpContext.Connection.RemoteIpAddress.ToString(), tenant.AppTenantId, upload);
                return Json(new { response = "success", message = "Girdiğiniz bilgiler başarıyla gönderildi" });
            }
            return Json(new { response = "danger", message = "Gönderdiğiniz formda geçersiz alanlar var" });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Form(string slug, string culture = "tr")
        {
            if (culture == "no")
            {
                return Redirect("/tr");
            }
            ViewBag.Slug = slug;
            return View();
        }

        [HttpPost]
        public IActionResult Subscribe(Subscription subscription)
        { var subs = _context.Subscriptions.FirstOrDefault(s => s.Email == subscription.Email);
            if (subs==null)

            {
                subscription.AppTenantId = tenant.AppTenantId;
                subscription.CreatedBy = User.Identity.Name ?? "username";
                subscription.CreateDate = DateTime.Now;
                subscription.UpdatedBy = User.Identity.Name ?? "username";
                subscription.UpdateDate = DateTime.Now;
                subscription.SubscriptionDate = DateTime.Now;
                _context.Add(subscription);
                _context.SaveChanges();
                return Redirect(Request.Headers["Referer"].ToString() + "?message=subscriptionSuccessful");
            }
            return Redirect(Request.Headers["Referer"].ToString() + "?message=subscriptionUnsuccessful");
           
           
        }

        public IActionResult CustomCss()
        {

            Customization customization = _context.Customizations.FirstOrDefault();
            if (customization != null)
            {
                return Content(customization.CustomCSS, "text/css");


            }
            return Content("", "text/css");

        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
