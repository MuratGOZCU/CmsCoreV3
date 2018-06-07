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
    [Authorize(Roles = "ADMIN,Supplier")]
    [Area("CmsCore")]
    public class RegionsController : ControllerBase
    {
       
        public RegionsController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {
             
        }

        // GET: CmsCore/Regions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Regions.Include(r => r.ParentRegion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CmsCore/Regions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Regions
                .Include(r => r.ParentRegion)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // GET: CmsCore/Regions/Create
        public IActionResult Create()
        {
            var region = new Region();
            region.CreatedBy = User.Identity.Name ?? "username";
            region.CreateDate = DateTime.Now;
            region.UpdatedBy = User.Identity.Name ?? "username";
            region.UpdateDate = DateTime.Now;
            region.AppTenantId = tenant.AppTenantId;
            ViewData["ParentRegionId"] = new SelectList(_context.Regions, "Id", "Name");

            var regionParent = new MenuItem();
            var parentRegion = _context.Regions.ToList();
            var result = "";
            recurseRegion(ref parentRegion, null, 0,null, ref result);
            ViewBag.ParentRegion = result;
            return View(region);
        }

        // POST: CmsCore/Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Code,RegionType,ParentRegionId,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Region region)
        {
            if (ModelState.IsValid)
            {
                region.CreatedBy = User.Identity.Name ?? "username";
                region.CreateDate = DateTime.Now;
                region.UpdatedBy = User.Identity.Name ?? "username";
                region.UpdateDate = DateTime.Now;
                region.AppTenantId = tenant.AppTenantId;
                _context.Add(region);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var parentRegion = _context.Regions.ToList();
            var result = "";
            recurseRegion(ref parentRegion, null, 0, region.ParentRegionId, ref result);
            ViewBag.ParentRegion = result;
            ViewData["ParentRegionId"] = new SelectList(_context.Regions, "Id", "Name", region.ParentRegionId);
            return View(region);
        }
        static void recurseRegion(ref List<Region> rg, Region start, int lavel, long? selected, ref string result)
        {
            foreach(Region child in rg)
            {
                if (child.ParentRegion == start)
                {
                    result +="<option "+ (selected.HasValue && child.Id == selected.Value ? "selected" : "") + " value='" +child.Id.ToString()+"'>" + (new String(' ',lavel * 2)).Replace(" ", "&nbsp") + child.Name + "</option>";
                    recurseRegion(ref rg, child, lavel +1,selected, ref result);
                }
            }
        }
        
    // GET: CmsCore/Regions/Edit/5
    public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Regions.SingleOrDefaultAsync(m => m.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            var parentRegion = _context.Regions.ToList();
            var result = "";
            recurseRegion(ref parentRegion, null, 0, region.ParentRegionId, ref result);
            ViewBag.ParentRegion = result;

            ViewData["ParentRegionId"] = new SelectList(_context.Regions, "Id", "Name", region.ParentRegionId);
            return View(region);
        }

        // POST: CmsCore/Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,Code,RegionType,ParentRegionId,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Region region)
        {
            if (id != region.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                region.UpdatedBy = User.Identity.Name ?? "username";
                region.UpdateDate = DateTime.Now;
                region.AppTenantId = tenant.AppTenantId;
                try
                {
                    _context.Update(region);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionExists(region.Id))
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
            ViewData["ParentRegionId"] = new SelectList(_context.Regions, "Id", "Name", region.ParentRegionId);
            var parentRegion = _context.Regions.ToList();
            var result = "";
            recurseRegion(ref parentRegion, null, 0, region.ParentRegionId, ref result);
            ViewBag.ParentRegion = result;

            return View(region);
        }

        // GET: CmsCore/Regions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Regions
                .Include(r => r.ParentRegion)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // POST: CmsCore/Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var region = await _context.Regions.SingleOrDefaultAsync(m => m.Id == id);
            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RegionExists(long id)
        {
            return _context.Regions.Any(e => e.Id == id);
        }
    }
}
