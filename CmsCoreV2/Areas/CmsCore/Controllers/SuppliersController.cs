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
    [Authorize(Roles = "ADMIN,Supplier")]
    [Area("CmsCore")]
    public class SuppliersController : ControllerBase
    {
       
        public SuppliersController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {
             
        }
        [Authorize(Roles="ADMIN,SupplierIndex")]
        // GET: CmsCore/Suppliers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Suppliers;
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles="ADMIN,SupplierDetails")]
        // GET: CmsCore/Suppliers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }
        [Authorize(Roles="ADMIN,SupplierCreate")]
        // GET: CmsCore/Suppliers/Create
        public IActionResult Create()
        {
            var supplier = new Supplier();
            supplier.CreatedBy = User.Identity.Name ?? "username";
            supplier.CreateDate = DateTime.Now;
            supplier.UpdatedBy = User.Identity.Name ?? "username";
            supplier.UpdateDate = DateTime.Now;
            supplier.AppTenantId = tenant.AppTenantId;
            
            return View(supplier);
        }
        [Authorize(Roles="ADMIN,SupplierCreate")]
        // POST: CmsCore/Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.CreatedBy = User.Identity.Name ?? "username";
                supplier.CreateDate = DateTime.Now;
                supplier.UpdatedBy = User.Identity.Name ?? "username";
                supplier.UpdateDate = DateTime.Now;
                supplier.AppTenantId = tenant.AppTenantId;
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(supplier);
        }
   
        [Authorize(Roles="ADMIN,SupplierEdit")]
    // GET: CmsCore/Suppliers/Edit/5
    public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.SingleOrDefaultAsync(m => m.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }
          
            return View(supplier);
        }
        [Authorize(Roles="ADMIN,SupplierEdit")]
        // POST: CmsCore/Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                supplier.UpdatedBy = User.Identity.Name ?? "username";
                supplier.UpdateDate = DateTime.Now;
                supplier.AppTenantId = tenant.AppTenantId;
                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.Id))
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

            return View(supplier);
        }
        [Authorize(Roles="ADMIN,SupplierDelete")]

        // GET: CmsCore/Suppliers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }
        [Authorize(Roles="ADMIN,SupplierDelete")]
        // POST: CmsCore/Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var supplier = await _context.Suppliers.SingleOrDefaultAsync(m => m.Id == id);
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SupplierExists(long id)
        {
            return _context.Suppliers.Any(e => e.Id == id);
        }
    }
}
