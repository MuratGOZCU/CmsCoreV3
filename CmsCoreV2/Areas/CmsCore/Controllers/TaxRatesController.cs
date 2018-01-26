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
using Microsoft.AspNetCore.Authorization;

namespace CmsCoreV2.Areas.CmsCore.Controllers
{
    [Authorize(Roles = "ADMIN")]
    [Area("CmsCore")]
    public class TaxRatesController : ControllerBase
    {
       

        public TaxRatesController(ITenant<AppTenant> tenant, ApplicationDbContext context) : base(context, tenant)
        {

        }

        // GET: CmsCore/TaxRates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaxRates.Include(t => t.District);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CmsCore/TaxRates/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRate = await _context.TaxRates
                .Include(t => t.District)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (taxRate == null)
            {
                return NotFound();
            }

            return View(taxRate);
        }

        // GET: CmsCore/TaxRates/Create
        public IActionResult Create()
        {
            var taxRate = new TaxRate();
            taxRate.CreatedBy = User.Identity.Name ?? "username";
            taxRate.CreateDate = DateTime.Now;
            taxRate.UpdatedBy = User.Identity.Name ?? "username";
            taxRate.UpdateDate = DateTime.Now;
            taxRate.AppTenantId = tenant.AppTenantId;
            ViewData["DistrictId"] = new SelectList(_context.Regions, "Id", "Name");
            return View(taxRate);
        }

        // POST: CmsCore/TaxRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistrictId,CountryCode,CityPlateCode,ZipCode,Rate,TaxName,TaxRatePriority,TaxRateCompound,TaxRateShipping,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] TaxRate taxRate)
        {
           
            if (ModelState.IsValid)
            {
                taxRate.CreatedBy = User.Identity.Name ?? "username";
                taxRate.CreateDate = DateTime.Now;
                taxRate.UpdatedBy = User.Identity.Name ?? "username";
                taxRate.UpdateDate = DateTime.Now;
                taxRate.AppTenantId = tenant.AppTenantId;
                _context.Add(taxRate);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DistrictId"] = new SelectList(_context.Regions, "Id", "Name", taxRate.DistrictId);
            return View(taxRate);
        }

        // GET: CmsCore/TaxRates/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRate = await _context.TaxRates.SingleOrDefaultAsync(m => m.Id == id);
            if (taxRate == null)
            {
                return NotFound();
            }
            ViewData["DistrictId"] = new SelectList(_context.Regions, "Id", "Name", taxRate.DistrictId);
            taxRate.UpdatedBy = User.Identity.Name ?? "username";
            taxRate.UpdateDate = DateTime.Now;
            taxRate.AppTenantId = tenant.AppTenantId;
            return View(taxRate);
        }

        // POST: CmsCore/TaxRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("DistrictId,CountryCode,CityPlateCode,ZipCode,Rate,TaxName,TaxRatePriority,TaxRateCompound,TaxRateShipping,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] TaxRate taxRate)
        {
            if (id != taxRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    taxRate.UpdatedBy = User.Identity.Name ?? "username";
                    taxRate.UpdateDate = DateTime.Now;
                    taxRate.AppTenantId = tenant.AppTenantId;
                    _context.Update(taxRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxRateExists(taxRate.Id))
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
            ViewData["DistrictId"] = new SelectList(_context.Regions, "Id", "Name", taxRate.DistrictId);
            return View(taxRate);
        }

        // GET: CmsCore/TaxRates/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRate = await _context.TaxRates
                .Include(t => t.District)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (taxRate == null)
            {
                return NotFound();
            }

            return View(taxRate);
        }

        // POST: CmsCore/TaxRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var taxRate = await _context.TaxRates.SingleOrDefaultAsync(m => m.Id == id);
            _context.TaxRates.Remove(taxRate);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TaxRateExists(long id)
        {
            return _context.TaxRates.Any(e => e.Id == id);
        }
    }
}
