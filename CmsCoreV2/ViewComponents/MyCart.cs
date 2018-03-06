using CmsCoreV2.Data;
using CmsCoreV2.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View(cart);
        }
        private async Task<Cart> GetMyCart(string owner)
        {
            var cart = await _context.Carts.Include(i=>i.CartItems).ThenInclude(t=>t.Product).FirstOrDefaultAsync(c=> c.Owner == owner);
            return cart;
        }
        
    }
}
