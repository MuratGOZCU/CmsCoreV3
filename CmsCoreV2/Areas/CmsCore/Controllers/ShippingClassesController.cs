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
    [Authorize(Roles="ADMIN,Supplier")]
    [Area("CmsCore")]
    public class ShippingClassesController : ControllerBase
    {
       
        public ShippingClassesController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {
       
        }

        // GET: CmsCore/ShippingClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShippingClasses.ToListAsync());
        }

        // GET: CmsCore/ShippingClasses/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingClass = await _context.ShippingClasses
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shippingClass == null)
            {
                return NotFound();
            }

            return View(shippingClass);
        }

        // GET: CmsCore/ShippingClasses/Create
        public IActionResult Create()
        {
            var sc = new ShippingClass();
            sc.CreateDate = DateTime.Now;
            sc.UpdateDate = DateTime.Now;
            sc.CreatedBy = User.Identity.Name ?? "username";
            sc.UpdatedBy = User.Identity.Name ?? "username";
            sc.AppTenantId = tenant.AppTenantId;
            return View(sc);
        }

        // POST: CmsCore/ShippingClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShippingClassName,Slug,Description,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] ShippingClass shippingClass)
        {
            if (ModelState.IsValid)
            {
                shippingClass.CreateDate = DateTime.Now;
                shippingClass.UpdateDate = DateTime.Now;
                shippingClass.CreatedBy = User.Identity.Name ?? "username";
                shippingClass.UpdatedBy = User.Identity.Name ?? "username";
                shippingClass.AppTenantId = tenant.AppTenantId;
                _context.Add(shippingClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shippingClass);
        }

        // GET: CmsCore/ShippingClasses/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingClass = await _context.ShippingClasses.SingleOrDefaultAsync(m => m.Id == id);
            if (shippingClass == null)
            {
                return NotFound();
            }
            return View(shippingClass);
        }

        // POST: CmsCore/ShippingClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ShippingClassName,Slug,Description,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] ShippingClass shippingClass)
        {
            if (id != shippingClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
               
                    shippingClass.UpdateDate = DateTime.Now;
                    shippingClass.UpdatedBy = User.Identity.Name ?? "username";
                    shippingClass.AppTenantId = tenant.AppTenantId;
                    _context.Update(shippingClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingClassExists(shippingClass.Id))
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
            return View(shippingClass);
        }

        // GET: CmsCore/ShippingClasses/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingClass = await _context.ShippingClasses
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shippingClass == null)
            {
                return NotFound();
            }

            return View(shippingClass);
        }

        // POST: CmsCore/ShippingClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var shippingClass = await _context.ShippingClasses.SingleOrDefaultAsync(m => m.Id == id);
            _context.ShippingClasses.Remove(shippingClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShippingClassExists(long id)
        {
            return _context.ShippingClasses.Any(e => e.Id == id);
        }
    }
}
