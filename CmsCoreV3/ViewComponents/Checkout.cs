using CmsCoreV3.Data;
using CmsCoreV3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.ViewComponents
{
    public class Checkout : ViewComponent
    {
        private readonly ApplicationDbContext _context;
            
        public Checkout(ApplicationDbContext context)
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
            var cvm = new CheckoutViewModel();
            cvm.Cart = cart;
            ViewBag.Countries = new SelectList(_context.Regions.Where(r => r.RegionType == RegionType.Country).OrderBy(o=>o.Name).ToList(),"Code","Name","TR");
            ViewBag.PaymentMethods = await _context.PaymentMethods.ToListAsync();
            return View(cvm);
        }
        private async Task<Cart> GetMyCart(string owner)
        {
            var cart = await _context.Carts.Include(i=>i.CartItems).ThenInclude(t=>t.Product).FirstOrDefaultAsync(c=> c.Owner == owner);
            return cart;
        }
        
    }
}
