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

namespace CmsCoreV2.Areas.CmsCore.Controllers
{
    [Authorize(Roles="ADMIN,Supplier")]
    [Area("CmsCore")]
    public class PaymentMethodsController : ControllerBase
    {
        public PaymentMethodsController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {
         
        }

        // GET: CmsCore/PaymentMethods
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaymentMethods.ToListAsync());
        }

        // GET: CmsCore/PaymentMethods/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _context.PaymentMethods
                .SingleOrDefaultAsync(m => m.Id == id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            return View(paymentMethod);
        }

        // GET: CmsCore/PaymentMethods/Create
        public IActionResult Create()
        {  
            PaymentMethod paymentMethod = new PaymentMethod();
            paymentMethod.CreateDate = DateTime.Now;
            paymentMethod.CreatedBy = User.Identity.Name ?? "username";
            paymentMethod.UpdateDate = DateTime.Now;
            paymentMethod.UpdatedBy = User.Identity.Name ?? "username";
            paymentMethod.AppTenantId = tenant.AppTenantId;
            return View(paymentMethod);
        }

        // POST: CmsCore/PaymentMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Code,Enable,Description,ApiUrl,ApiUserName,ApiPassword,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                paymentMethod.CreateDate = DateTime.Now;
                paymentMethod.CreatedBy = User.Identity.Name ?? "username";
                paymentMethod.UpdateDate = DateTime.Now;
                paymentMethod.UpdatedBy = User.Identity.Name ?? "username";
                paymentMethod.AppTenantId = tenant.AppTenantId;
                _context.Add(paymentMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentMethod);
        }

        // GET: CmsCore/PaymentMethods/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _context.PaymentMethods.SingleOrDefaultAsync(m => m.Id == id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return View(paymentMethod);
        }

        // POST: CmsCore/PaymentMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Title,Code,Enable,Description,ApiUrl,ApiUserName,ApiPassword,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    paymentMethod.UpdateDate = DateTime.Now;
                    paymentMethod.UpdatedBy = User.Identity.Name ?? "username";
                    paymentMethod.AppTenantId = tenant.AppTenantId;
                    _context.Update(paymentMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentMethodExists(paymentMethod.Id))
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
            return View(paymentMethod);
        }

        // GET: CmsCore/PaymentMethods/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _context.PaymentMethods
                .SingleOrDefaultAsync(m => m.Id == id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            return View(paymentMethod);
        }

        // POST: CmsCore/PaymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var paymentMethod = await _context.PaymentMethods.SingleOrDefaultAsync(m => m.Id == id);
            _context.PaymentMethods.Remove(paymentMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentMethodExists(long id)
        {
            return _context.PaymentMethods.Any(e => e.Id == id);
        }
    }
}
