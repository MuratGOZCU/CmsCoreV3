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
    [Authorize(Roles = "ADMIN,Supplier,COUPON")]
    [Area("CmsCore")]
    public class CouponsController : ControllerBase
    {
        public CouponsController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {
                
        }
        [Authorize(Roles="ADMIN,CouponIndex")]
        // GET: CmsCore/Coupons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coupons.ToListAsync());
        }
        [Authorize(Roles="ADMIN,CouponDetails")]
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
        [Authorize(Roles="ADMIN,CouponCreate")]
        // GET: CmsCore/Coupons/Create
        public IActionResult Create()
        {
            var coupon = new Coupon();
            coupon.CreatedBy = User.Identity.Name ?? "username";
            coupon.CreateDate = DateTime.Now;
            coupon.UpdatedBy = User.Identity.Name ?? "username";
            coupon.UpdateDate = DateTime.Now;
            coupon.AppTenantId = tenant.AppTenantId;
            ViewBag.Products = new MultiSelectList(_context.Products.ToList(),"Id","Name");
            ViewBag.ProductCategories = new MultiSelectList(_context.ProductCategories.ToList(),"Id","Name");
            return View(coupon);
        }
        [Authorize(Roles="ADMIN,CouponCreate")]
        // POST: CmsCore/Coupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LimitPerCoupon,LimitUse,LimitPerUser,DiscountType,CouponCode,Description,CouponAmount,AllowFreeShipping,ExpirationDate,MinimumSpending,MaximumSpending,OnlyIndividualUse,ExcludeDiscountProduct,RestrictedEmails,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Coupon coupon,long[] CouponProductId, long[] ExcludeCouponProductId, long[] CouponCategoryId, long[] ExcludeCouponCategoryId)
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
                coupon = _context.Coupons.Include(i=>i.CouponProducts).Include(i=>i.ExcludeCouponProducts).Include(i=>i.CouponProductCategories).Include(i=>i.ExcludeCouponProductCategories).FirstOrDefault(f=>f.Id == coupon.Id);
                coupon.CouponProducts.Clear();
                await _context.SaveChangesAsync();
                foreach (var item in CouponProductId) {
                    coupon.CouponProducts.Add(new CouponProduct() {CouponId = coupon.Id, ProductId = item });
                }
                await _context.SaveChangesAsync();
                coupon.ExcludeCouponProducts.Clear();
                await _context.SaveChangesAsync();
                foreach (var item in ExcludeCouponProductId) {
                    coupon.ExcludeCouponProducts.Add(new ExcludeCouponProduct() {CouponId = coupon.Id, ProductId = item});
                }
                await _context.SaveChangesAsync();
                coupon.CouponProductCategories.Clear();
                await _context.SaveChangesAsync();
                foreach (var item in CouponCategoryId) {
                    coupon.CouponProductCategories.Add(new CouponProductCategory() {CouponId = coupon.Id,ProductCategoryId = item });
                }
                await _context.SaveChangesAsync();
                coupon.ExcludeCouponProductCategories.Clear();
                await _context.SaveChangesAsync();
                foreach (var item in ExcludeCouponCategoryId) {
                    coupon.ExcludeCouponProductCategories.Add(new ExcludeCouponProductCategory() {CouponId = coupon.Id,ProductCategoryId = item });
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Products = new MultiSelectList(_context.Products.ToList(),"Id","Name");
            ViewBag.ProductCategories = new MultiSelectList(_context.ProductCategories.ToList(),"Id","Name");
            return View(coupon);
        }
        [Authorize(Roles="ADMIN,CouponEdit")]
        // GET: CmsCore/Coupons/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupons.Include(i=>i.CouponProducts).Include(i=>i.ExcludeCouponProducts).Include(i=>i.CouponProductCategories).Include(i=>i.ExcludeCouponProductCategories).SingleOrDefaultAsync(m => m.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }
            coupon.UpdatedBy = User.Identity.Name ?? "username";
            coupon.UpdateDate = DateTime.Now;
            coupon.AppTenantId = tenant.AppTenantId;
            ViewBag.Products = new MultiSelectList(_context.Products.ToList(),"Id","Name",coupon.CouponProducts.Select(c=>c.ProductId).ToList());
            ViewBag.Products2 = new MultiSelectList(_context.Products.ToList(),"Id","Name",coupon.ExcludeCouponProducts.Select(c=>c.ProductId).ToList());
            ViewBag.ProductCategories = new MultiSelectList(_context.ProductCategories.ToList(),"Id","Name",coupon.CouponProductCategories.Select(c=>c.ProductCategoryId).ToList());
            ViewBag.ProductCategories2 = new MultiSelectList(_context.ProductCategories.ToList(),"Id","Name",coupon.ExcludeCouponProductCategories.Select(c=>c.ProductCategoryId).ToList());
            return View(coupon);
        }
        [Authorize(Roles="ADMIN,CouponEdit")]
        // POST: CmsCore/Coupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("LimitPerCoupon,LimitUse,LimitPerUser,DiscountType,CouponCode,Description,CouponAmount,AllowFreeShipping,ExpirationDate,MinimumSpending,MaximumSpending,OnlyIndividualUse,ExcludeDiscountProduct,RestrictedEmails,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Coupon coupon, long[] CouponProductId, long[] ExcludeCouponProductId, long[] CouponCategoryId, long[] ExcludeCouponCategoryId)
        {
            if (id != coupon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                
                    coupon.UpdatedBy = User.Identity.Name ?? "username";
                    coupon.UpdateDate = DateTime.Now;
                    coupon.AppTenantId = tenant.AppTenantId;
                    _context.Update(coupon);
                    await _context.SaveChangesAsync();
                    coupon = _context.Coupons.Include(i=>i.CouponProducts).Include(i=>i.ExcludeCouponProducts).Include(i=>i.CouponProductCategories).Include(i=>i.ExcludeCouponProductCategories).FirstOrDefault(f=>f.Id == coupon.Id);
                coupon.CouponProducts.Clear();
                await _context.SaveChangesAsync();
                foreach (var item in CouponProductId) {
                    coupon.CouponProducts.Add(new CouponProduct() {CouponId = coupon.Id, ProductId = item });
                }
                await _context.SaveChangesAsync();
                coupon.ExcludeCouponProducts.Clear();
                await _context.SaveChangesAsync();
                foreach (var item in ExcludeCouponProductId) {
                    coupon.ExcludeCouponProducts.Add(new ExcludeCouponProduct() {CouponId = coupon.Id, ProductId = item});
                }
                await _context.SaveChangesAsync();
                coupon.CouponProductCategories.Clear();
                await _context.SaveChangesAsync();
                foreach (var item in CouponCategoryId) {
                    coupon.CouponProductCategories.Add(new CouponProductCategory() {CouponId = coupon.Id,ProductCategoryId = item });
                }
                await _context.SaveChangesAsync();
                coupon.ExcludeCouponProductCategories.Clear();
                await _context.SaveChangesAsync();
                foreach (var item in ExcludeCouponCategoryId) {
                    coupon.ExcludeCouponProductCategories.Add(new ExcludeCouponProductCategory() {CouponId = coupon.Id,ProductCategoryId = item });
                }
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
            ViewBag.Products = new MultiSelectList(_context.Products.ToList(),"Id","Name",coupon.CouponProducts.Select(c=>c.ProductId).ToList());
            ViewBag.Products2 = new MultiSelectList(_context.Products.ToList(),"Id","Name",coupon.ExcludeCouponProducts.Select(c=>c.ProductId).ToList());
            ViewBag.ProductCategories = new MultiSelectList(_context.ProductCategories.ToList(),"Id","Name",coupon.CouponProductCategories.Select(c=>c.ProductCategoryId).ToList());
            ViewBag.ProductCategories2 = new MultiSelectList(_context.ProductCategories.ToList(),"Id","Name",coupon.ExcludeCouponProductCategories.Select(c=>c.ProductCategoryId).ToList());
            return View(coupon);
        }
        [Authorize(Roles="ADMIN,CouponDelete")]
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
        [Authorize(Roles="ADMIN,CouponDelete")]
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
