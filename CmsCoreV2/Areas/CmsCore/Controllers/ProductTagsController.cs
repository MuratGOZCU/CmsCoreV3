using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CmsCoreV2.Data;
using Microsoft.EntityFrameworkCore;
using CmsCoreV2.Models;
using SaasKit.Multitenancy;

namespace CmsCoreV2.Areas.CmsCore.Controllers
{
    [Area("CmsCore")]
    public class ProductTagsController : ControllerBase
    {
     
        public ProductTagsController(ApplicationDbContext context, ITenant<AppTenant> tenant):base(context, tenant)
        {
          
        }

        public async Task<IActionResult> Index()
        {
            var productTags = await _context.ProductTags.ToListAsync();
            return View(productTags);
        }

        public async Task<IActionResult> Create()
        {
            var productTag = new ProductTag();
            return View(productTag);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductTag productTag)
        {
            if (ModelState.IsValid)
            {
                _context.ProductTags.Add(productTag);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productTag);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var productTag = await _context.ProductTags.FirstOrDefaultAsync(pt => pt.Id == id);
            if (productTag == null)
            {
                return NotFound();
            }
            return View(productTag);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductTag productTagVM)
        {
            if (ModelState.IsValid) {
                // _context.Entry<ProductTag>(productTagVM).State = EntityState.Modified;
                _context.Update(productTagVM);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productTagVM);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var productTag = await _context.ProductTags.FirstOrDefaultAsync(pt => pt.Id == id);
            if (productTag == null)
            {
                return NotFound();
            }
            _context.ProductTags.Remove(productTag);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}