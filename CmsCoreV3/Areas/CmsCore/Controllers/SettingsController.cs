using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmsCoreV3.Data;
using CmsCoreV3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using SaasKit.Multitenancy;
using Z.EntityFramework.Plus;

namespace CmsCoreV3.Areas.CmsCore.Controllers
{
    [Authorize(Roles = "ADMIN,SETTING")]
    [Area("CmsCore")]
    public class SettingsController : ControllerBase
    {
        public SettingsController( ITenant<AppTenant> tenant, ApplicationDbContext context) : base(context, tenant)
        {

        }

        // GET: CmsCore/Settings
        public async Task<IActionResult> Index()
        {
            var setting = await _context.SetFiltered<Setting>().Where(x => x.AppTenantId == tenant.AppTenantId).FirstOrDefaultAsync();
            return View(setting);
        }
        [HttpPost]
        public IActionResult Index(Setting setting)
        {
            setting.UpdateDate = DateTime.Now;
            setting.UpdatedBy = User.Identity.Name;
            setting.AppTenantId = tenant.AppTenantId;
            _context.Update(setting);
            _context.SaveChanges();
            ViewBag.Message = "Ayarlar baþarýyla kaydedildi";
            return View(setting);
        }
        public async Task<IActionResult> Mail()
        {
            var setting = await _context.Settings.FirstOrDefaultAsync();
            return View(setting);
        }
        [HttpPost]
        public IActionResult Mail(Setting setting)
        {
            Setting allSettings = _context.Settings.FirstOrDefault();

            allSettings.UpdateDate = DateTime.Now;
            allSettings.UpdatedBy = User.Identity.Name;
            allSettings.AppTenantId = tenant.AppTenantId;
            allSettings.SmtpHost = setting.SmtpHost;
            allSettings.SmtpPassword = setting.SmtpPassword;
            allSettings.SmtpPort = setting.SmtpPort;
            allSettings.SmtpUseSSL = setting.SmtpUseSSL;
            allSettings.SmtpUserName = setting.SmtpUserName;

            allSettings.UpdateDate = DateTime.Now;
            allSettings.UpdatedBy = User.Identity.Name ?? "username";
            allSettings.AppTenantId = tenant.AppTenantId;
            _context.SaveChanges();
            ViewBag.Message = "Ayarlar baþarýyla kaydedildi";
            return View(setting);
        }

        // POST: CmsCore/Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MapTitle,HeaderString,GoogleAnalytics,FooterScript,MapLat,MapLon,SmtpUserName,SmtpPassword,SmtpHost,SmtpPort,SmtpUseSSL,Name,Value,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Setting setting)
        {
            if (id != setting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //setting.UpdatedBy = User.Identity.Name ?? "username";
                    //setting.UpdateDate = DateTime.Now;
                    //setting.AppTenantId = tenant.AppTenantId;
                    Setting allSetting = _context.Settings.FirstOrDefault();

                    allSetting.HeaderString = setting.HeaderString;
                    allSetting.GoogleAnalytics = setting.GoogleAnalytics;
                    allSetting.FooterScript = setting.FooterScript;
                    allSetting.MapTitle = setting.MapTitle;
                    allSetting.MapLat = setting.MapLat;
                    allSetting.MapLon = setting.MapLon;
                    allSetting.UpdateDate = DateTime.Now;
                    allSetting.UpdatedBy = User.Identity.Name ?? "username";
                    allSetting.AppTenantId = tenant.AppTenantId;
                    
                    await _context.SaveChangesAsync();
                    ViewBag.Message = "Ayarlar baþarýyla kaydedildi";

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingExists(setting.Id))
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
            return View(setting);
        }

        // GET: CmsCore/Settings/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setting = await _context.Settings
                .SingleOrDefaultAsync(m => m.Id == id);
            if (setting == null)
            {
                return NotFound();
            }

            return View(setting);
        }

        // POST: CmsCore/Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var setting = await _context.Settings.SingleOrDefaultAsync(m => m.Id == id);
            _context.Settings.Remove(setting);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SettingExists(long id)
        {
            return _context.Settings.Any(e => e.Id == id);
        }
    }
}
