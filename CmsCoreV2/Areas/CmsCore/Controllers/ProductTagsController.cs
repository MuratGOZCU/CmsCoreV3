using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmsCoreV2.Data;
using CmsCoreV2.Models;
using Microsoft.AspNetCore.Authorization;
using SaasKit.Multitenancy;
using Z.EntityFramework.Plus;

namespace CmsCoreV2.Areas.CmsCore.Controllers
{
    [Authorize(Roles = "ADMIN,PRODUCTTAG")]
    [Area("CmsCore")]
    public class ProductTagsController : ControllerBase
    {
        public ProductTagsController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {

        }



        // GET: CmsCore/ProductTags
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SetFiltered<ProductTag>().Where(x => x.AppTenantId == tenant.AppTenantId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CmsCore/ProductTags/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTag = await _context.ProductTags
                .SingleOrDefaultAsync(m => m.Id == id);
            if (productTag == null)
            {
                return NotFound();
            }

            return View(productTag);
        }

        // GET: CmsCore/ProductTags/Create
        public IActionResult Create()
        {
            var productTag = new ProductTag();
            ViewData["LanguageId"] = new SelectList(_context.Languages.ToList(), "Id", "NativeName");
            productTag.CreatedBy = User.Identity.Name ?? "username";
            productTag.CreateDate = DateTime.Now;
            productTag.UpdatedBy = User.Identity.Name ?? "username";
            productTag.UpdateDate = DateTime.Now;
            productTag.AppTenantId = tenant.AppTenantId;
           

            return View(productTag);
        }

        // POST: CmsCore/ProductTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Slug,Description,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] ProductTag productTag)
        {
            if (ModelState.IsValid)
            {
                productTag.CreatedBy = User.Identity.Name ?? "username";
                productTag.CreateDate = DateTime.Now;
                productTag.UpdatedBy = User.Identity.Name ?? "username";
                productTag.UpdateDate = DateTime.Now;
                productTag.AppTenantId = tenant.AppTenantId;

                _context.Add(productTag);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productTag);
        }

        // GET: CmsCore/ProductTags/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTag = await _context.ProductTags.SingleOrDefaultAsync(m => m.Id == id);
            if (productTag == null)
            {
                return NotFound();
            }
            productTag.UpdatedBy = User.Identity.Name ?? "username";
            productTag.UpdateDate = DateTime.Now;
            productTag.AppTenantId = tenant.AppTenantId;
            return View(productTag);
        }

        // POST: CmsCore/ProductTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,Slug,Description,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] ProductTag productTag)
        {
            if (id != productTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                productTag.UpdatedBy = User.Identity.Name ?? "username";
                productTag.UpdateDate = DateTime.Now;
                productTag.AppTenantId = tenant.AppTenantId;

                try
                {
                    _context.Update(productTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTagExists(productTag.Id))
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
            return View(productTag);
        }

        // GET: CmsCore/ProductTags/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTag = await _context.ProductTags
                .SingleOrDefaultAsync(m => m.Id == id);
            if (productTag == null)
            {
                return NotFound();
            }

            return View(productTag);
        }

        // POST: CmsCore/ProductTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var productTag = await _context.ProductTags.SingleOrDefaultAsync(m => m.Id == id);
            _context.ProductTags.Remove(productTag);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductTagExists(long id)
        {
            return _context.ProductTags.Any(e => e.Id == id);
        }
    }
}
