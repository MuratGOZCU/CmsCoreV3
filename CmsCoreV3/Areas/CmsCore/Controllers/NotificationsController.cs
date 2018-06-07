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
using Z.EntityFramework.Plus;
using Microsoft.AspNetCore.Authorization;

namespace CmsCoreV3.Areas.CmsCore.Controllers
{
    [Authorize(Roles = "ADMIN,NOTIFICATION")]
    [Area("CmsCore")]
    public class NotificationsController : ControllerBase
    {

        public NotificationsController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        { 

        }

        // GET: CmsCore/Menus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SetFiltered<Notification>().Where(x => x.AppTenantId == tenant.AppTenantId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CmsCore/Menus/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .SingleOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // GET: CmsCore/Menus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CmsCore/Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Notification notification)
        {
            notification.CreatedBy = User.Identity.Name ?? "username";
            notification.CreateDate = DateTime.Now;
            notification.UpdatedBy = User.Identity.Name ?? "username";
            notification.UpdateDate = DateTime.Now;
            notification.AppTenantId = tenant.AppTenantId;
            if (ModelState.IsValid)
            {
                _context.Add(notification);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
               
            }

            return View(notification);
        }

        // GET: CmsCore/Menus/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications.SingleOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }
           
            return View(notification);
        }

        // POST: CmsCore/Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Notification notification)
        {
            if (id != notification.Id)
            {
                return NotFound();
            }
            notification.UpdatedBy = User.Identity.Name ?? "username";
            notification.UpdateDate = DateTime.Now;
            notification.AppTenantId = tenant.AppTenantId;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(notification.Id))
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
            return View(notification);
        }

        // GET: CmsCore/Menus/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .SingleOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: CmsCore/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var notification = await _context.Notifications.SingleOrDefaultAsync(m => m.Id == id);
            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool NotificationExists(long id)
        {
            return _context.Notifications.Any(e => e.Id == id);
        }
    }
}
