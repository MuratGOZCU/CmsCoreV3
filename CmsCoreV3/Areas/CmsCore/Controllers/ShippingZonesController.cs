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
using Microsoft.AspNetCore.Authorization;

namespace CmsCoreV3.Areas.CmsCore.Controllers
{
    [Authorize(Roles="ADMIN,Supplier")]
    [Area("CmsCore")]
    public class ShippingZonesController : ControllerBase
    {
        

        public ShippingZonesController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {
         
        }

        // GET: CmsCore/ShippingZones
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShippingZones.Include(i=>i.ShippingZoneRegions).ThenInclude(t=>t.Region).ToListAsync());
        }

        // GET: CmsCore/ShippingZones/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingZone = await _context.ShippingZones
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shippingZone == null)
            {
                return NotFound();
            }

            return View(shippingZone);
        }

        // GET: CmsCore/ShippingZones/Create
        public IActionResult Create()
        {
            var z = new ShippingZone();
            z.CreateDate = DateTime.Now;
            z.CreatedBy = User.Identity.Name ?? "username";
            z.UpdateDate = DateTime.Now;
            z.UpdatedBy = User.Identity.Name ?? "username";
            z.AppTenantId = tenant.AppTenantId;
            ViewBag.ZoneRegions = new MultiSelectList(_context.Regions.ToList(),"Id","Name");
            return View(z);
        }

        // POST: CmsCore/ShippingZones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] ShippingZone shippingZone, long[] zoneRegionId)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shippingZone);
                await _context.SaveChangesAsync();
                var prd = _context.ShippingZones.Include(i=>i.ShippingZoneRegions).ThenInclude(t=>t.Region).FirstOrDefault(f=>f.Id == shippingZone.Id);
                prd.ShippingZoneRegions.Clear();
                await _context.SaveChangesAsync();
                if (zoneRegionId != null) {
                    foreach (var k in zoneRegionId) {
                        prd.ShippingZoneRegions.Add(new ShippingZoneRegion() {ShippingZoneId=prd.Id,RegionId=k,AppTenantId=tenant.AppTenantId});
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shippingZone);
        }

        // GET: CmsCore/ShippingZones/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingZone = await _context.ShippingZones.SingleOrDefaultAsync(m => m.Id == id);
            if (shippingZone == null)
            {
                return NotFound();
            }
            return View(shippingZone);
        }

        // POST: CmsCore/ShippingZones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] ShippingZone shippingZone)
        {
            if (id != shippingZone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shippingZone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingZoneExists(shippingZone.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shippingZone);
        }

        // GET: CmsCore/ShippingZones/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingZone = await _context.ShippingZones
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shippingZone == null)
            {
                return NotFound();
            }

            return View(shippingZone);
        }

        // POST: CmsCore/ShippingZones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var shippingZone = await _context.ShippingZones.SingleOrDefaultAsync(m => m.Id == id);
            _context.ShippingZones.Remove(shippingZone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShippingZoneExists(long id)
        {
            return _context.ShippingZones.Any(e => e.Id == id);
        }
    }
}
