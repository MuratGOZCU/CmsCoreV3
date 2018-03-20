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
    [Authorize(Roles = "ADMIN,Supplier,ATTRIBUTE")]
    [Area("CmsCore")]
    public class AttributesController : ControllerBase
    {
       
        public AttributesController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {

        }
        [Authorize(Roles="ADMIN,AttributeIndex")]
        // GET: CmsCore/Attributes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attributes.ToListAsync());
        }
        [Authorize(Roles="ADMIN,AttributeDetails")]
        // GET: CmsCore/Attributes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (attribute == null)
            {
                return NotFound();
            }

            return View(attribute);
        }
        [Authorize(Roles="ADMIN,AttributeCreate")]
        // GET: CmsCore/Attributes/Create
        public IActionResult Create()
        {

            var attribute = new Models.Attribute();
            attribute.CreatedBy = User.Identity.Name ?? "username";
            attribute.CreateDate = DateTime.Now;
            attribute.UpdatedBy = User.Identity.Name ?? "username";
            attribute.UpdateDate = DateTime.Now;
            attribute.AppTenantId = tenant.AppTenantId;

            return View(attribute);
        }
        [Authorize(Roles="ADMIN,AttributeCreate")]
        // POST: CmsCore/Attributes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Slug,IsVisible,Variations,AttributeType,AttributePosition,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Models.Attribute attribute)
        {
            if (ModelState.IsValid)
            {
                attribute.CreatedBy = User.Identity.Name ?? "username";
                attribute.CreateDate = DateTime.Now;
                attribute.UpdatedBy = User.Identity.Name ?? "username";
                attribute.UpdateDate = DateTime.Now;
                attribute.AppTenantId = tenant.AppTenantId;

                _context.Add(attribute);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(attribute);
        }
        [Authorize(Roles="ADMIN,AttributeEdit")]
        // GET: CmsCore/Attributes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes.SingleOrDefaultAsync(m => m.Id == id);
            if (attribute == null)
            {
                return NotFound();
            }
            return View(attribute);
        }
        [Authorize(Roles="ADMIN,AttributeEdit")]
        // POST: CmsCore/Attributes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,Slug,IsVisible,Variations,AttributeType,AttributePosition,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Models.Attribute attribute)
        {
            if (id != attribute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    attribute.UpdatedBy = User.Identity.Name ?? "username";
                    attribute.UpdateDate = DateTime.Now;
                    attribute.AppTenantId = tenant.AppTenantId;

                    _context.Update(attribute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributeExists(attribute.Id))
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
            return View(attribute);
        }
        [Authorize(Roles="ADMIN,AttributeDelete")]
        // GET: CmsCore/Attributes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (attribute == null)
            {
                return NotFound();
            }

            return View(attribute);
        }
        [Authorize(Roles="ADMIN,AttributeDelete")]
        // POST: CmsCore/Attributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var attribute = await _context.Attributes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Attributes.Remove(attribute);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AttributeExists(long id)
        {
            return _context.Attributes.Any(e => e.Id == id);
        }
    }
}
