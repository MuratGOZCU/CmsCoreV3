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
using Microsoft.AspNetCore.Identity;
using Iyzipay.Request;
using Iyzipay.Model;
using Iyzipay;

namespace CmsCoreV2.Controllers
{
    public class HomeController : Controller
    {
        protected readonly AppTenant tenant;
        private readonly ApplicationDbContext _context;
        private readonly IFeedbackService feedbackService;
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private IEmailSender emailSender;
        public HomeController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender, UserManager<ApplicationUser> userManager, IFeedbackService _feedbackService, ITenant<AppTenant> _tenant)
        {
            _context = context;
            this.feedbackService = _feedbackService;
            this.tenant = _tenant.Value;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
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
        public int GetCartProductCount()
        {
            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                owner = HttpContext.Session.Id;
            }
            var cart = GetMyCart(owner);
            return cart?.ProductCount ?? 0;
        }
       
        public IActionResult Index(string slug, string culture,string message="",string ajax="")
        { 
            if (culture == "no")
            {
                return Redirect("/tr");
            }
            ViewData["Culture"] = culture;
            ViewBag.PageScript = "";
            HttpContext.Items["Culture"] = culture;
            slug = slug.ToLower();
            ViewBag.CartProductCount = GetCartProductCount();
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
            ViewBag.IsAjax = (ajax == "1");
            var page = _context.SetFiltered<Page>().Include(i=> i.Language).FirstOrDefault(p => p.Slug.ToLower() == slug && p.Language.Culture== culture);
            if (page == null || page.IsPublished == false)
            {
                var post = _context.SetFiltered<Post>().FirstOrDefault(p => p.Slug.ToLower() == slug);
                if (post == null)
                {
                    var product = _context.SetFiltered<Product>().Include(i => i.Language).Include(i=>i.ProductMedias).Include(i => i.ProductProductCategories).ThenInclude(t => t.ProductCategory).FirstOrDefault(p => p.Slug.ToLower() == slug && p.Language.Culture == culture && p.IsApproved == true );

                    if (product != null)
                    {
                        ViewData["Title"] = product.Name;
                        ViewData["Description"] = product.Description;

                        return View("Product", product);
                    }
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
        public IList<Region> GetCities(string parentId) {
            return _context.Regions.Where(r=>r.RegionType == RegionType.City && r.ParentRegion.Code == parentId).OrderBy(o=>o.Name).ToList();
        }
        public IList<Region> GetCounties(string parentId) {
            return _context.Regions.Where(r=>r.RegionType == RegionType.District && r.ParentRegion.Code == parentId).OrderBy(o=>o.Name).ToList();
        }
        public async Task<IActionResult> Checkout(CheckoutViewModel viewModel)
        {
            if (ModelState.IsValid) {
                string owner = User.Identity.Name;
                if (string.IsNullOrEmpty(owner))
                {
                    owner = HttpContext.Session.Id;
                }
                var cart = GetMyCart(owner);
                if (cart == null) {
                    return Redirect("/tr/sepet?status=-1");
                }
                if (string.IsNullOrEmpty(owner) && string.IsNullOrEmpty(viewModel.Password)) {
                    return Redirect("/tr/kasa?status=1");
                }
                else if (string.IsNullOrEmpty(owner)) {
                    var user = new ApplicationUser { UserName = viewModel.BillingEmail, Email = viewModel.BillingEmail, AppTenantId = tenant.AppTenantId };
                    var result = await userManager.CreateAsync(user, viewModel.Password);

                    if (result.Succeeded)
                    {
                        var customer = new Customer {FirstName = viewModel.BillingFirstName, LastName = viewModel.BillingLastName,
                        Address = viewModel.BillingAddress, Street = viewModel.BillingStreet, City = viewModel.BillingCity, Country = viewModel.BillingCountry, County = viewModel.BillingCounty, ZipCode = viewModel.BillingZipCode,
                        Phone = viewModel.BillingPhone, UserName = viewModel.BillingEmail, CreateDate = DateTime.Now, CreatedBy = User.Identity.Name, UpdateDate = DateTime.Now, UpdatedBy = User.Identity.Name, AppTenantId = tenant.AppTenantId};
                        _context.Customers.Add(customer);
                        _context.SaveChanges();
                        user.CustomerId = customer.Id;
                        await userManager.UpdateAsync(user);
                        var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                        await emailSender.SendEmailConfirmationAsync(viewModel.BillingEmail, callbackUrl);
                        await signInManager.SignInAsync(user, isPersistent: false);                    
                    } else
                    {
                        string errors = "";
                        foreach (var error in result.Errors)
                        {
                            errors += error.Description + "|";
                        }
                        return Redirect("/tr/kasa?errors="+errors);
                    }
                }
                var u = await userManager.GetUserAsync(User);
                var c = _context.Customers.FirstOrDefault(f=>f.Id == u.CustomerId);
                if (c==null) {
                        c = new Customer {FirstName = viewModel.BillingFirstName, LastName = viewModel.BillingLastName,
                        Address = viewModel.BillingAddress, Street = viewModel.BillingStreet, City = viewModel.BillingCity, Country = viewModel.BillingCountry, County = viewModel.BillingCounty, ZipCode = viewModel.BillingZipCode,
                        Phone = viewModel.BillingPhone, UserName = viewModel.BillingEmail, CreateDate = DateTime.Now, CreatedBy = User.Identity.Name, UpdateDate = DateTime.Now, UpdatedBy = User.Identity.Name, AppTenantId = tenant.AppTenantId};
                        _context.Customers.Add(c);
                        _context.SaveChanges();                        
                        u.CustomerId = c.Id;
                        await userManager.UpdateAsync(u);
                }
                var order = new Order();            
                order.OrderDate = DateTime.Now;
                order.CreateDate = DateTime.Now;
                order.CreatedBy = User.Identity.Name ?? "(Bilinmeyen)";
                order.UpdateDate = DateTime.Now;
                order.UpdatedBy = User.Identity.Name ?? "(Bilinmeyen)";
                order.Owner = owner;
                order.OrderStatus = OrderStatus.PaymentWaiting;
                order.AppTenantId = tenant.AppTenantId;
                order.BillingAddress = viewModel.BillingAddress;
                order.BillingCity = viewModel.BillingCity;
                order.BillingCounty = viewModel.BillingCounty;
                order.BillingCompanyName = viewModel.BillingCompanyName;
                order.BillingCountry = viewModel.BillingCountry;
                order.BillingEmail = viewModel.BillingEmail;
                order.BillingFirstName = viewModel.BillingFirstName;
                order.BillingLastName = viewModel.BillingLastName;
                order.BillingIdentityNumber = viewModel.BillingIdentityNumber;
                order.BillingPhone = viewModel.BillingPhone;
                order.BillingStreet = viewModel.BillingStreet;
                order.BillingZipCode = viewModel.BillingZipCode;
                order.DeliveryAddress = viewModel.DeliveryAddress ?? order.BillingAddress;
                order.DeliveryCity = viewModel.DeliveryCity ?? order.BillingCity;
                order.DeliveryCompanyName = viewModel.DeliveryCompanyName ?? order.BillingCompanyName;
                order.DeliveryCountry = viewModel.DeliveryCountry ?? order.BillingCountry;
                order.DeliveryCounty = viewModel.DeliveryCounty ?? order.BillingCounty;
                order.DeliveryFirstName = viewModel.DeliveryFirstName ?? order.BillingFirstName;
                order.DeliveryLastName = viewModel.DeliveryLastName ?? order.BillingLastName;
                order.DeliveryStreet = viewModel.DeliveryStreet ?? order.BillingStreet;
                order.DeliveryZipCode = viewModel.DeliveryZipCode ?? order.BillingZipCode;
                order.CartId = viewModel.CartId;
                order.CustomerId = c.Id;
                var paymentMethod = _context.PaymentMethods.FirstOrDefault(f => f.Code == viewModel.PaymentMethod);
                order.PaymentMethodId = paymentMethod.Id;
                order.DeliveryNotes = viewModel.DeliveryNotes;
                _context.Orders.Add(order);
                foreach (var item in cart.CartItems) {
                    var oi = new OrderItem() {AppTenantId=tenant.AppTenantId, CreateDate=DateTime.Now, CreatedBy = User.Identity.Name, UpdateDate = DateTime.Now, UpdatedBy = User.Identity.Name,
                    OrderId=order.Id, ProductId=item.ProductId, StockCode = item.Product.StockCode, SalePrice = item.Product.SalePrice.Value, ShippingPrice = item.ShippingPrice, DiscountPrice=0, Quantity=item.Quantity, Refund=0};
                    order.OrderItems.Add(oi);
                }
                _context.SaveChanges();                        
                viewModel.Order = order;
                if (viewModel.PaymentMethod == "CC") {
                    var options = new Options();
                    options.ApiKey = paymentMethod.ApiUserName;
                    options.SecretKey = paymentMethod.ApiPassword;
                    options.BaseUrl = paymentMethod.ApiUrl;
                    var url = PayWithIyzipay(viewModel, options);
                    return Redirect(url);
                }
                return View("CheckoutCompleted", viewModel);
            }
            var errs = "";
            foreach (var item in ModelState) {
                foreach (var e in item.Value.Errors) {
                    errs += e.ErrorMessage + "|";
                }
            }
            return Redirect("/tr/kasa?status=0&errors="+System.Net.WebUtility.UrlEncode(errs));
        }
        private async Task<string> PayWithIyzipay(CheckoutViewModel viewModel, Options options) {
            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = viewModel.Order.Id.ToString();
            request.Price = viewModel.Order.TotalPrice.ToString();
            request.PaidPrice = viewModel.Order.TotalPrice.ToString();
            request.Currency = Iyzipay.Model.Currency.TRY.ToString();
            request.BasketId = viewModel.Order.CartId.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = "https://localhost:5000/";

            List<int> enabledInstallments = new List<int>();
            enabledInstallments.Add(2);
            enabledInstallments.Add(3);
            enabledInstallments.Add(6);
            enabledInstallments.Add(9);
            request.EnabledInstallments = enabledInstallments;

            Buyer buyer = new Buyer();
            buyer.Id = viewModel.Order.Customer.Id.ToString();
            buyer.Name = viewModel.Order.Customer.FirstName.ToString();
            buyer.Surname = viewModel.Order.Customer.LastName.ToString();
            buyer.GsmNumber = viewModel.Order.Customer.Phone.ToString();
            buyer.Email = viewModel.Order.Customer.UserName.ToString(); // email eksik
            buyer.IdentityNumber = viewModel.Order.Customer.Phone.ToString(); // tc kimlik no eksik
            var u = await userManager.GetUserAsync(User);
            buyer.LastLoginDate = "2018-04-01 15:12:09"; // last login ve registration tarihleri eksik
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = viewModel.Order.Customer.Address.ToString();
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = "0.3";
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem();
            secondBasketItem.Id = "BI102";
            secondBasketItem.Name = "Game code";
            secondBasketItem.Category1 = "Game";
            secondBasketItem.Category2 = "Online Game Items";
            secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
            secondBasketItem.Price = "0.5";
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem();
            thirdBasketItem.Id = "BI103";
            thirdBasketItem.Name = "Usb";
            thirdBasketItem.Category1 = "Electronics";
            thirdBasketItem.Category2 = "Usb / Cable";
            thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            thirdBasketItem.Price = "0.2";
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
            return checkoutFormInitialize.PaymentPageUrl;
        }

        public IActionResult ApplyCoupon(string couponCode) {
            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                owner = HttpContext.Session.Id;
            }
            var cart = GetMyCart(owner);
            if (cart == null)
            {
                cart = new Cart();
                cart.Owner = owner;
                cart.CreateDate = DateTime.Now;
                cart.UpdateDate = DateTime.Now;
                cart.AppTenantId = tenant.AppTenantId;              
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }
            var coupon = _context.Coupons.FirstOrDefault(f=>(!string.IsNullOrEmpty(couponCode)?f.CouponCode.ToLower() == couponCode.ToLower():false));
            if (coupon != null) {
                // todo: check other restrictions here
                cart.CartCoupons.Add(new CartCoupon() {CartId = cart.Id, CouponId = coupon.Id});
                _context.SaveChanges();
                return Redirect("/tr/sepet?status=1");
            }
            return Redirect("/tr/sepet?status=0");
        }
        public IActionResult AddToCart(string slug, int quantity)
        {
            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                owner = HttpContext.Session.Id;
            }
            var cart = GetMyCart(owner);
            if (cart == null)
            {
                cart = new Cart();
                cart.Owner = owner;
                var ci = new CartItem();
                ci.Product = _context.Products.FirstOrDefault(p => p.Slug.ToLower() == slug.ToLower());
                if (ci.Product != null)
                {
                    ci.CreateDate = DateTime.Now;
                    ci.Cart = cart;
                    ci.UpdateDate = DateTime.Now;
                    ci.Quantity = quantity;
                    cart.CartItems.Add(ci);
                }
                cart.CreateDate = DateTime.Now;
                cart.UpdateDate = DateTime.Now;
                cart.AppTenantId = tenant.AppTenantId;              
                _context.Carts.Add(cart);
                _context.SaveChanges();
            } else
            {
                var p = cart.CartItems.FirstOrDefault(c => c.Product.Slug.ToLower() == slug.ToLower());
                if (p == null)
                {
                    var ci = new CartItem();
                    ci.Product = _context.Products.FirstOrDefault(f => f.Slug.ToLower() == slug.ToLower());
                    if (ci.Product != null)
                    {
                        ci.UpdateDate = DateTime.Now;
                        ci.Quantity = quantity;
                        cart.CartItems.Add(ci);
                    }
                } else
                {
                    p.Quantity += quantity;
                }
                cart.UpdateDate = DateTime.Now;
                _context.SaveChanges();

            }
            HttpContext.Session.SetString("cartId", cart.Id.ToString());
            return Redirect("/tr/sepet");

        }
        public IActionResult RemoveFromCart(string slug)
        {
            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                owner = HttpContext.Session.Id;
            }
            var cart = GetMyCart(owner);
            if (cart != null)
            {
                var ci = cart.CartItems.FirstOrDefault(c => c.Product.Slug.ToLower() == slug.ToLower());
                if (ci!=null)
                {                    
                    cart.CartItems.Remove(ci);
                    cart.UpdateDate = DateTime.Now;
                    _context.SaveChanges();
                }
            }
            
            return Redirect("/tr/sepet");
        }
        public IActionResult UpdateQuantity(string slug, int quantity)
        {
            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                owner = HttpContext.Session.Id;
            }
            var cart = GetMyCart(owner);
            if (cart != null)
            {
                var p = cart.CartItems.FirstOrDefault(c => c.Product.Slug.ToLower() == slug.ToLower());
                if (p != null)
                {
                    p.UpdateDate = DateTime.Now;
                    p.Quantity = quantity;
                }
                cart.UpdateDate = DateTime.Now;
                _context.SaveChanges();
            }
            return Redirect("/tr/sepet");  
        }
        private Cart GetMyCart(string owner)
        {
            var cart = _context.Carts.Include(i=>i.CartCoupons).ThenInclude(t=>t.Coupon).Include(i => i.CartItems).ThenInclude(t => t.Product).FirstOrDefault(c => c.Owner == owner);
            return cart;
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
