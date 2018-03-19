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
    public class ProductCategoriesController : ControllerBase
    {
       
        public ProductCategoriesController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {

        }
        // GET: CmsCore/ProductCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductCategories.ToListAsync());
        }

        // GET: CmsCore/ProductCategories/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategories
                .SingleOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // GET: CmsCore/ProductCategories/Create
        public IActionResult Create()
        {

            var productCategory = new ProductCategory();
            productCategory.CreatedBy = User.Identity.Name ?? "username";
            productCategory.CreateDate = DateTime.Now;
            productCategory.UpdatedBy = User.Identity.Name ?? "username";
            productCategory.UpdateDate = DateTime.Now;
            productCategory.AppTenantId = tenant.AppTenantId;
            var parentCategoryOptions = _context.ProductCategories.ToList();
            var result = "";
            recurseParentCategoryOptions(ref parentCategoryOptions, null, 0,null, ref result);
            ViewBag.ParentCategoryOptions = result;
            return View(productCategory);
        }
        private void recurseParentCategoryOptions(ref List<ProductCategory> cl, ProductCategory start, int level, long? selected, ref string result)
        {
            foreach (ProductCategory child in cl)
            {
                if (child.ParentCategory == start)
                {
                    result += "<option " + (selected.HasValue && child.Id == selected.Value ? "selected" : "") + " value='" + child.Id.ToString() + "'>" + (new String(' ', level * 2)).Replace(" ", "&nbsp&nbsp;") + child.Name + "</option>";
                    recurseParentCategoryOptions(ref cl, child, level + 1,selected, ref result);
                }
            }

        }
        // POST: CmsCore/ProductCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentCategoryId,Name,Slug,Description,SmallImage,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                productCategory.CreatedBy = User.Identity.Name ?? "username";
                productCategory.CreateDate = DateTime.Now;
                productCategory.UpdatedBy = User.Identity.Name ?? "username";
                productCategory.UpdateDate = DateTime.Now;
                productCategory.AppTenantId = tenant.AppTenantId;

                _context.Add(productCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var parentCategoryOptions = _context.ProductCategories.ToList();
            var result = "";
            recurseParentCategoryOptions(ref parentCategoryOptions, null, 0,productCategory.ParentCategoryId, ref result);
            ViewBag.ParentCategoryOptions = result;
            return View(productCategory);
        }

        // GET: CmsCore/ProductCategories/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategories.SingleOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            productCategory.UpdatedBy = User.Identity.Name ?? "username";
            productCategory.UpdateDate = DateTime.Now;
            productCategory.AppTenantId = productCategory.AppTenantId;
            var parentCategoryOptions = _context.ProductCategories.ToList();
            var result = "";
            recurseParentCategoryOptions(ref parentCategoryOptions, null, 0,productCategory.ParentCategoryId, ref result);
            ViewBag.ParentCategoryOptions = result;
            return View(productCategory);
        }

        // POST: CmsCore/ProductCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ParentCategoryId,Name,Slug,Description,SmallImage,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    productCategory.UpdatedBy = User.Identity.Name ?? "username";
                    productCategory.UpdateDate = DateTime.Now;
                    productCategory.AppTenantId = productCategory.AppTenantId;

                    _context.Update(productCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryExists(productCategory.Id))
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
            var parentCategoryOptions = _context.ProductCategories.ToList();
            var result = "";
            recurseParentCategoryOptions(ref parentCategoryOptions, null, 0,productCategory.ParentCategoryId, ref result);
            ViewBag.ParentCategoryOptions = result;
            return View(productCategory);
        }

        // GET: CmsCore/ProductCategories/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategories
                .SingleOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // POST: CmsCore/ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var productCategory = await _context.ProductCategories.SingleOrDefaultAsync(m => m.Id == id);
            _context.ProductCategories.Remove(productCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductCategoryExists(long id)
        {
            return _context.ProductCategories.Any(e => e.Id == id);
        }
    }
}
