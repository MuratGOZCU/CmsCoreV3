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
using Z.EntityFramework.Plus;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CmsCoreV3.Areas.CmsCore.Controllers
{
    [Authorize(Roles = "ADMIN,FORM")]
    [Area("CmsCore")]
    public class FormsController : ControllerBase
    {


        public FormsController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {

        }

        public IActionResult ExportToCsv(long id, DateTime startDate, DateTime endDate)
        {
            StringWriter sw = new StringWriter();
            HttpContext.Response.Clear();
            string formName = _context.Forms.FirstOrDefault(f => f.Id == id).Slug;
            var fields = _context.FormFields.Where(f => f.FormId == id).OrderBy(o => o.Position).ToList();            
            var fieldCount = fields.Count();
            sw.WriteLine("sep=|");
            var fieldNames = fields.Select(f => f.Name).ToList().ToArray();
            var fieldIds = fields.Select(f => f.Id).ToList(); ;
            sw.WriteLine(string.Join("|", fieldNames)+"|CreateDate");
            Response.Headers.Add("content-disposition", "attachment;filename=" + formName + ".csv");
            Response.ContentType = "text/csv";
            var items = _context.FeedbackValues.Include(t => t.Feedback).Where(f => f.Feedback.FormId == id && fieldIds.Contains(f.FormFieldId) && f.CreateDate >= startDate && f.CreateDate <= endDate).OrderBy(o=>o.FeedbackId).ToList();
            int i = 0;
            var feedbackIds = items.Select(s => s.FeedbackId).Distinct().ToList();
            foreach (var fId in feedbackIds)
            {
                var itemlar = items.Where(t => t.FeedbackId == fId).OrderBy(o=>o.Position).ToList();
                var createDate = itemlar.Select(s => s.CreateDate).FirstOrDefault();
                var itemFieldCount = itemlar.Select(s => s.FormFieldId).Distinct().Count();
                foreach (var field in fields)
                {
                    var item = itemlar.FirstOrDefault(t => t.FormFieldId == field.Id);
                    if (item!= null) {
                        sw.Write(item.Value?.Replace(System.Environment.NewLine, ". ") + "|");                                           
                    } else
                    {
                        sw.Write(" |");
                    }
                    i++;
                    if (i >= fieldCount)
                    {                      
                        sw.Write(createDate);
                        sw.WriteLine();
                        i = 0;
                    }
                }
            }
            return Content(sw.ToString(), "text/csv", System.Text.Encoding.UTF8);
        }
        public async Task<IActionResult> Clone(long id) {
            var form = await _context.Forms.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            form.Id = 0;             
            string cloneString = JsonConvert.SerializeObject(form);
            Form form2 = JsonConvert.DeserializeObject<Form>(cloneString);
            form2.CreateDate = DateTime.Now;
            form2.CreatedBy = User.Identity.Name ?? "username";
            form2.UpdateDate = DateTime.Now;
            form2.UpdatedBy = User.Identity.Name ?? "username";            
            form2.FormName += " (Kopya)";
            form2.Slug += "-kopya";
            _context.Forms.Add(form2);
            _context.SaveChanges();
            form2.FormFields = new HashSet<FormField>();
            var formFields = _context.FormFields.AsNoTracking().Where(w=>w.FormId == id).ToList();
            foreach (var item in formFields) {
                item.Id = 0;             
                string cloneString2 = JsonConvert.SerializeObject(item);
                FormField item2 = JsonConvert.DeserializeObject<FormField>(cloneString2); 
                item2.CreateDate = DateTime.Now;
                item2.CreatedBy = User.Identity.Name;
                item2.UpdateDate = DateTime.Now;
                item2.UpdatedBy = User.Identity.Name;
                item2.FormId = form2.Id;
                form2.FormFields.Add(item2);
            }
            _context.SaveChanges();
            return RedirectToAction("Edit", new {id=form2.Id});
        }
        // GET: CmsCore/Forms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SetFiltered<Form>().Where(x => x.AppTenantId == tenant.AppTenantId).Include(f => f.Language);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Preview(long? id)
        {
            var form = await _context.Forms.Include("FormFields").SingleOrDefaultAsync(m => m.Id == id);
            return View(form);
        }

        // GET: CmsCore/Forms/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms
                .Include(f => f.Language)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // GET: CmsCore/Forms/Create
        public IActionResult Create()
        {
            ViewData["LanguageId"] = new SelectList(_context.Languages.ToList(), "Id", "NativeName");
            return View();
        }

        // POST: CmsCore/Forms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormName,EmailTo,EmailBcc,EmailCc,Description,Template,ClosingDescription,GoogleAnalyticsCode,IsPublished,LanguageId,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,Slug,AppTenantId,SendMailToUser,UserMailContent,UserMailSubject,UserMailAttachment,SendSMS1ToUser,UserSMS1,SendSMS2ToUser,UserSMS2")] Form form)
        {
            form.CreatedBy = User.Identity.Name ?? "username";
            form.CreateDate = DateTime.Now;
            form.UpdatedBy = User.Identity.Name ?? "username";
            form.UpdateDate = DateTime.Now;
            form.AppTenantId = tenant.AppTenantId;
            if (ModelState.IsValid)
            {
                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages.ToList(), "Id", "NativeName", form.LanguageId);
            return View(form);
        }

        // GET: CmsCore/Forms/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms.SingleOrDefaultAsync(m => m.Id == id);
            if (form == null)
            {
                return NotFound();
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages.ToList(), "Id", "NativeName", form.LanguageId);
            return View(form);
        }

        // POST: CmsCore/Forms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("FormName,EmailTo,EmailBcc,EmailCc,Description,Template,ClosingDescription,GoogleAnalyticsCode,IsPublished,LanguageId,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,Slug,AppTenantId,SendMailToUser,UserMailContent,UserMailSubject,UserMailAttachment,SendSMS1ToUser,UserSMS1,SendSMS2ToUser,UserSMS2")] Form form)
        {
            if (id != form.Id)
            {
                return NotFound();
            }
            form.UpdatedBy = User.Identity.Name ?? "username";
            form.UpdateDate = DateTime.Now;
            form.AppTenantId = tenant.AppTenantId;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(form);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormExists(form.Id))
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
            ViewData["LanguageId"] = new SelectList(_context.Languages.ToList(), "Id", "NativeName", form.LanguageId);
            return View(form);
        }

        // GET: CmsCore/Forms/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms
                .Include(f => f.Language)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // POST: CmsCore/Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var form = await _context.Forms.SingleOrDefaultAsync(m => m.Id == id);
            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FormExists(long id)
        {
            return _context.Forms.Any(e => e.Id == id);
        }
    }
}
