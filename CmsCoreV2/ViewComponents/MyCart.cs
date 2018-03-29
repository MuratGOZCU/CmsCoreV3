using CmsCoreV2.Data;
using CmsCoreV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.ViewComponents
{
    public class MyCart : ViewComponent
    {
        private readonly ApplicationDbContext _context;
            
        public MyCart(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                owner = HttpContext.Session.Id;
            }
            var cart = await GetMyCart(owner);
            if (cart!=null) {
                if (Request.Query["CityId"].ToString()!=null) {
                    cart.DestinationCityCode = Request.Query["CityId"].ToString();
                }
            }
            if (Request.Query["status"].ToString()!=null) {
                if (Request.Query["status"].ToString()=="0") {
                    ViewBag.CouponMessage = "Kupon kodu geçersiz!";
                } else if  (Request.Query["status"].ToString()=="1") {
                    ViewBag.CouponMessage = "Kupon kodu başarıyla uygulandı.";
                } else {
                    ViewBag.CouponMessage = "İndirim için geçerli bir kupon ya da promosyon kodu giriniz.";
                }

            }
            ViewBag.Countries = new SelectList(_context.Regions.Where(r => r.RegionType == RegionType.Country).OrderBy(o=>o.Name).ToList(),"Code","Name","TR");
            return View(cart);
        }
        private async Task<Cart> GetMyCart(string owner)
        {
            var cart = await _context.Carts.Include(i=>i.CartCoupons).ThenInclude(t=>t.Coupon).Include(i=>i.CartItems).ThenInclude(t=>t.Product).ThenInclude(k=>k.ShippingPrices).ThenInclude(j=>j.ShippingZone).ThenInclude(Z=>Z.ShippingZoneRegions).ThenInclude(r=>r.Region).FirstOrDefaultAsync(c=> c.Owner == owner);
            return cart;
        }
        
    }
}
