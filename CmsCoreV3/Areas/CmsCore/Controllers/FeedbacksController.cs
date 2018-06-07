using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmsCoreV3.Data;
using CmsCoreV3.Models;
using SaasKit.Multitenancy;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using CmsCoreV3.Services;
using Z.EntityFramework.Plus;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace CmsCoreV3.Areas.CmsCore.Controllers
{
    [Authorize(Roles = "ADMIN")]
    [Area("CmsCore")]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;
        public FeedbacksController(ApplicationDbContext context, ITenant<AppTenant> tenant, IFeedbackService feedbackService) : base(context, tenant)
        {
            this.feedbackService = feedbackService;
        }
        // GET: CmsCore/Feedbacks
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, int formId=1, int skip=0, int take=1000)
        {
            startDate = startDate ??  DateTime.MinValue;
            endDate = endDate ?? DateTime.Now;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.Forms = _context.Forms.ToList();
            ViewBag.FormId = formId;
            ViewBag.Skip = skip;
            ViewBag.Take = take;
            return View(await _context.SetFiltered<Feedback>().Where(x => x.AppTenantId == tenant.AppTenantId && x.FormId==formId && startDate <= x.CreateDate && x.CreateDate<=endDate).Skip(skip).Take(take).ToListAsync());
        }

        // GET: CmsCore/Feedbacks/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.SetFiltered<Feedback>().Where(x => x.AppTenantId == tenant.AppTenantId).AsQueryable().Include("FeedbackValues")
                .SingleOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }
            ViewBag.FeedbackValues = feedback.FeedbackValues.ToList();
            return View(feedback);
        }

        // GET: CmsCore/Feedbacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CmsCore/Feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection formCollection,IFormFile[] upload)
        {

            feedbackService.FeedbackPost(formCollection, Request.HttpContext.Connection.RemoteIpAddress.ToString(), tenant.AppTenantId,upload);

            return RedirectToAction("Index");
        }

        public IActionResult Export()
        {
            return View();
        }

        //public void ExportToExcel()
        //{
        //    var grid = new GridView();
        //    grid.DataSource = from todoitems in db.TodoItems.ToList()
        //                      select new
        //                      {
        //                          Baslik = todoitems.Title,
        //                          Aciklama = todoitems.Description,
        //                          Kategori = todoitems.Category.Name,
        //                          DosyaEki = todoitems.Attachment,
        //                          Departman = todoitems.Department.Name,
        //                          Taraf = todoitems.Side.Name,
        //                          Müsteri = todoitems.Customer.Name,
        //                          Yonetici = todoitems.Manager.FirstName,
        //                          Organizator = todoitems.Organizator.FirstName,
        //                          Durum = todoitems.Status,
        //                          ToplantiTarihi = todoitems.MeetingDate,
        //                          PlanlananTarih = todoitems.PlannedDate,
        //                          BitirilmeTarihi = todoitems.FinishDate,
        //                          RevizeTarihi = todoitems.ReviseDate,
        //                          GorusmeKonusu = todoitems.ConversationSubject,
        //                          DestekleyenFirma = todoitems.SupporterCompany,
        //                          DestekleyenHekim = todoitems.SupporterDoctor,
        //                          GorusmeKatilimciSayisi = todoitems.ConversationAttendeeCount,
        //                          PlanlananOrganizasyonTarihi = todoitems.ScheduledOrganizationDate,
        //                          MailKonularý = todoitems.MailingSubjects,
        //                          AfisKonusu = todoitems.PosterSubject,
        //                          AfisSayisi = todoitems.PosterCount,
        //                          Elearning = todoitems.Elearning,
        //                          YapilanTaramalarýnTurleri = todoitems.TypesOfScans,
        //                          YapilanTaramalardakiAsoSayisi = todoitems.AsoCountInScans,
        //                          OrganizasyonTurleri = todoitems.TypesOfOrganization,
        //                          OrganizasyondakiAsoSayisi = todoitems.AsoCountInOrganizations,
        //                          AsýOrganizasyonTurleri = todoitems.TypesOfVaccinationOrganization,
        //                          AsýOrganizasyonundakiAsoSayisi = todoitems.AsoCountInVaccinationOrganization,
        //                          AfisicinTazminatMiktari = todoitems.AmountOfCompensationForPoster,
        //                          KurumsalVerimlilikRaporu = todoitems.CorporateProductivityReport,
        //                          Olusturulmatarihi = todoitems.CreateDate,
        //                          OlusturanKullanici = todoitems.CreatedBy,
        //                          GuncellenmeTarihi = todoitems.UpdateDate,
        //                          GuncelleyenKullanici = todoitems.UpdatedBy
        //                      };
        //    grid.DataBind();
        //    Response.Clear();
        //    Response.AddHeader("content-disposition", "attachment;filename=yapilacaklar.xls");
        //    Response.ContentType = "application/ms-excel";
        //    Response.ContentEncoding = System.Text.Encoding.Unicode;
        //    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

        //    System.IO.StringWriter sw = new System.IO.StringWriter();
        //    System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    grid.RenderControl(hw);

        //    Response.Write(sw.ToString());
        //    Response.End();
        //}

        // GET: CmsCore/Feedbacks/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.SetFiltered<Feedback>().SingleOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        // POST: CmsCore/Feedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("UserName,SentDate,FormId,FormName,IP,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Feedback feedback, FeedbackValue feedbackValue)
        {
            if (id != feedback.Id)
            {
                return NotFound();
            }
            feedback.UpdatedBy = User.Identity.Name ?? "username";
            feedback.UpdateDate = DateTime.Now;
            feedback.AppTenantId = tenant.AppTenantId;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        // GET: CmsCore/Feedbacks/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: CmsCore/Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            
            var feedbackValues = _context.FeedbackValues.Where(m => m.FeedbackId == id).ToList();
            foreach (var item in feedbackValues)
            {
                _context.FeedbackValues.Remove(item);
            }
            _context.SaveChanges();
            
            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(m => m.Id == id);
            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FeedbackExists(long id)
        {
            return _context.Feedbacks.Any(e => e.Id == id);
        }
    }
}
