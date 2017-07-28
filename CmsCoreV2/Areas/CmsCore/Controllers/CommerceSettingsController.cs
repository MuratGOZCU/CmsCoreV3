using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmsCoreV2.Data;
using CmsCoreV2.Models;
using SaasKit.Multitenancy;

namespace CmsCoreV2.Areas.CmsCore.Controllers
{
    [Area("CmsCore")]
    public class CommerceSettingsController : ControllerBase
    {
        public CommerceSettingsController(ITenant<AppTenant> tenant, ApplicationDbContext context) : base(context, tenant)
        {

        }

        // GET: CmsCore/CommerceSetting
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Settings.Include(s => s.BasketPage).Include(s => s.Currency).
                Include(s => s.MainLocation).Include(s => s.MyAccountPage).Include(s => s.PaymentPage).
                Include(s => s.StorePage).Include(s => s.TermsAndConditionsPage);
            return View(await applicationDbContext.FirstOrDefaultAsync());
        }
        [HttpPost]
        public IActionResult Index(Setting CommerceSetting)
        {
            CommerceSetting.UpdateDate = DateTime.Now;
            CommerceSetting.UpdatedBy = User.Identity.Name;
            CommerceSetting.AppTenantId = tenant.AppTenantId;
            ViewData["BasketPageId"] = new SelectList(_context.Pages, "Id", "Slug", CommerceSetting.BasketPageId);
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "Id", CommerceSetting.CurrencyId);
            ViewData["MainLocationId"] = new SelectList(_context.Regions, "Id", "Name", CommerceSetting.MainLocationId);
            ViewData["MyAccountPageId"] = new SelectList(_context.Pages, "Id", "Slug", CommerceSetting.MyAccountPageId);
            ViewData["PaymentPageId"] = new SelectList(_context.Pages, "Id", "Slug", CommerceSetting.PaymentPageId);
            ViewData["StorePageId"] = new SelectList(_context.Pages, "Id", "Slug", CommerceSetting.StorePageId);
            ViewData["TermsAndConditionsPageId"] = new SelectList(_context.Pages, "Id", "Slug", CommerceSetting.TermsAndConditionsPageId);
            ViewData["Region"] = new SelectList(_context.Regions, "Id", "Name");
            _context.Update(CommerceSetting);
            ViewBag.Message = "Ayarlar baþarýyla kaydedildi";
            return View(CommerceSetting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Setting setting)
        {
            if (id != setting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    setting.UpdatedBy = User.Identity.Name ?? "username";
                    setting.UpdateDate = DateTime.Now;
                    setting.AppTenantId = tenant.AppTenantId;
                    _context.Update(setting);
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
            ViewData["BasketPageId"] = new SelectList(_context.Pages, "Id", "Slug", setting.BasketPageId);
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "Id", setting.CurrencyId);
            ViewData["MainLocationId"] = new SelectList(_context.Regions, "Id", "Name", setting.MainLocationId);
            ViewData["MyAccountPageId"] = new SelectList(_context.Pages, "Id", "Slug", setting.MyAccountPageId);
            ViewData["PaymentPageId"] = new SelectList(_context.Pages, "Id", "Slug", setting.PaymentPageId);
            ViewData["StorePageId"] = new SelectList(_context.Pages, "Id", "Slug", setting.StorePageId);
            ViewData["TermsAndConditionsPageId"] = new SelectList(_context.Pages, "Id", "Slug", setting.TermsAndConditionsPageId);
            ViewData["Region"] = new SelectList(_context.Regions, "Id", "Name");
            return View(setting);
        }

        private bool SettingExists(long id)
        {
            return _context.Settings.Any(e => e.Id == id);
        }
    }
}
