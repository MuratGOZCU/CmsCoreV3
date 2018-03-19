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
    public class AttributeItemsController : ControllerBase
    {
       
        public AttributeItemsController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {

        }

        // GET: CmsCore/Attributes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AttributeItems.Include(i=>i.Attribute).ToListAsync());
        }

        // GET: CmsCore/Attributes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeItem = await _context.AttributeItems.Include(i=>i.Attribute)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (attributeItem == null)
            {
                return NotFound();
            }

            return View(attributeItem);
        }

        // GET: CmsCore/Attributes/Create
        public IActionResult Create()
        {

            var attributeItem = new Models.AttributeItem();
            attributeItem.CreatedBy = User.Identity.Name ?? "username";
            attributeItem.CreateDate = DateTime.Now;
            attributeItem.UpdatedBy = User.Identity.Name ?? "username";
            attributeItem.UpdateDate = DateTime.Now;
            attributeItem.AppTenantId = tenant.AppTenantId;
            ViewBag.Attributes = new SelectList(_context.Attributes.ToList(),"Id","Name");
            return View(attributeItem);
        }

        // POST: CmsCore/Attributes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.AttributeItem attributeItem)
        {
            if (ModelState.IsValid)
            {
                attributeItem.CreatedBy = User.Identity.Name ?? "username";
                attributeItem.CreateDate = DateTime.Now;
                attributeItem.UpdatedBy = User.Identity.Name ?? "username";
                attributeItem.UpdateDate = DateTime.Now;
                attributeItem.AppTenantId = tenant.AppTenantId;

                _context.Add(attributeItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Attributes = new SelectList(_context.Attributes.ToList(),"Id","Name",attributeItem.AttributeId);
            return View(attributeItem);
        }

        // GET: CmsCore/Attributes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeItem = await _context.AttributeItems.Include(i=>i.Attribute).SingleOrDefaultAsync(m => m.Id == id);
            if (attributeItem == null)
            {
                return NotFound();
            }
            ViewBag.Attributes = new SelectList(_context.Attributes.ToList(),"Id","Name",attributeItem.AttributeId);
            return View(attributeItem);
        }

        // POST: CmsCore/Attributes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Models.AttributeItem attributeItem)
        {
            if (id != attributeItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    attributeItem.UpdatedBy = User.Identity.Name ?? "username";
                    attributeItem.UpdateDate = DateTime.Now;
                    attributeItem.AppTenantId = tenant.AppTenantId;

                    _context.Update(attributeItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributeItemExists(attributeItem.Id))
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
            ViewBag.Attributes = new SelectList(_context.Attributes.ToList(),"Id","Name",attributeItem.AttributeId);
            return View(attributeItem);
        }

        // GET: CmsCore/Attributes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeItem = await _context.AttributeItems.Include(i=>i.Attribute)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (attributeItem == null)
            {
                return NotFound();
            }

            return View(attributeItem);
        }

        // POST: CmsCore/Attributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var attributeItem = await _context.AttributeItems.Include(i=>i.Attribute).SingleOrDefaultAsync(m => m.Id == id);
            _context.AttributeItems.Remove(attributeItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AttributeItemExists(long id)
        {
            return _context.AttributeItems.Any(e => e.Id == id);
        }
    }
}
