using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmsCoreV3.Data;
using CmsCoreV3.Models;
using Microsoft.AspNetCore.Authorization;
using SaasKit.Multitenancy;

namespace CmsCoreV3.Areas.CmsCore.Controllers
{
    [Authorize(Roles = "ADMIN")]
    [Area("CmsCore")]
    public class SubscriptionsController : ControllerBase
    {


        public SubscriptionsController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {

        }

        // GET: CmsCore/Subscriptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subscriptions.ToListAsync());
        }

        // GET: CmsCore/Subscriptions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // GET: CmsCore/Subscriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CmsCore/Subscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,FullName,IsSubscribed,SubscriptionDate,UnsubscriptionDate,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Subscription subscription)
        {
            subscription.CreatedBy = User.Identity.Name ?? "username";
            subscription.CreateDate = DateTime.Now;
            subscription.UpdatedBy = User.Identity.Name ?? "username";
            subscription.UpdateDate = subscription.CreateDate;
            subscription.AppTenantId = tenant.AppTenantId;
            subscription.SubscriptionDate = subscription.CreateDate;
            
            if (ModelState.IsValid)
            {
                _context.Add(subscription);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(subscription);
        }

        // GET: CmsCore/Subscriptions/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions.SingleOrDefaultAsync(m => m.Id == id);
            subscription.UpdatedBy = User.Identity.Name ?? "username";
            subscription.UpdateDate = DateTime.Now;
            subscription.AppTenantId = tenant.AppTenantId;
            await _context.SaveChangesAsync();
            if (subscription == null)
            {
                return NotFound();
            }
            return View(subscription);
        }

        // POST: CmsCore/Subscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Email,FullName,IsSubscribed,SubscriptionDate,UnsubscriptionDate,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Subscription subscription)
        {
            if (id != subscription.Id)
            {
                return NotFound();
            }
            subscription.UpdatedBy = User.Identity.Name ?? "username";
            subscription.UpdateDate = DateTime.Now;
            subscription.AppTenantId = tenant.AppTenantId;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionExists(subscription.Id))
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
            return View(subscription);
        }

        // GET: CmsCore/Subscriptions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // POST: CmsCore/Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var subscription = await _context.Subscriptions.SingleOrDefaultAsync(m => m.Id == id);
            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SubscriptionExists(long id)
        {
            return _context.Subscriptions.Any(e => e.Id == id);
        }
    }
}
