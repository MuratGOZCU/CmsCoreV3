using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmsCoreV2.Data;
using CmsCoreV2.Models;

namespace CmsCoreV2.Areas.CmsCore.Controllers
{
    [Area("CmsCore")]
    public class CouponsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CouponsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CmsCore/Coupons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coupons.ToListAsync());
        }

        // GET: CmsCore/Coupons/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupons
                .SingleOrDefaultAsync(m => m.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // GET: CmsCore/Coupons/Create
        public IActionResult Create()
        {
            var coupon = new Coupon();
            coupon.CreatedBy = User.Identity.Name ?? "username";
            coupon.CreateDate = DateTime.Now;
            coupon.UpdatedBy = User.Identity.Name ?? "username";
            coupon.UpdateDate = DateTime.Now;
            return View(coupon);
        }

        // POST: CmsCore/Coupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LimitPerCoupon,LimitUse,LimitPerUser,DiscountType,CouponCode,Description,CouponAmount,AllowFreeShipping,ExpirationDate,MinimumSpending,MaximumSpending,OnlyIndividualUse,ExcludeDiscountProduct,RestrictedEmails,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Coupon coupon,AppTenant tenant)
        {
            if (ModelState.IsValid)
            {
                coupon.CreatedBy = User.Identity.Name ?? "username";
                coupon.CreateDate = DateTime.Now;
                coupon.UpdatedBy = User.Identity.Name ?? "username";
                coupon.UpdateDate = DateTime.Now;
                coupon.AppTenantId = tenant.AppTenantId;
                _context.Add(coupon);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(coupon);
        }

        // GET: CmsCore/Coupons/Edit/5
        public async Task<IActionResult> Edit(long? id, AppTenant tenant)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupons.SingleOrDefaultAsync(m => m.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }
            coupon.CreatedBy = User.Identity.Name ?? "username";
            coupon.CreateDate = DateTime.Now;
            coupon.UpdatedBy = User.Identity.Name ?? "username";
            coupon.UpdateDate = DateTime.Now;
            coupon.AppTenantId = tenant.AppTenantId;
            return View(coupon);
        }

        // POST: CmsCore/Coupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("LimitPerCoupon,LimitUse,LimitPerUser,DiscountType,CouponCode,Description,CouponAmount,AllowFreeShipping,ExpirationDate,MinimumSpending,MaximumSpending,OnlyIndividualUse,ExcludeDiscountProduct,RestrictedEmails,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Coupon coupon, AppTenant tenant)
        {
            if (id != coupon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    coupon.CreatedBy = User.Identity.Name ?? "username";
                    coupon.CreateDate = DateTime.Now;
                    coupon.UpdatedBy = User.Identity.Name ?? "username";
                    coupon.UpdateDate = DateTime.Now;
                    coupon.AppTenantId = tenant.AppTenantId;
                    _context.Update(coupon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouponExists(coupon.Id))
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
            return View(coupon);
        }

        // GET: CmsCore/Coupons/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupons
                .SingleOrDefaultAsync(m => m.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // POST: CmsCore/Coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var coupon = await _context.Coupons.SingleOrDefaultAsync(m => m.Id == id);
            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CouponExists(long id)
        {
            return _context.Coupons.Any(e => e.Id == id);
        }
    }
}
