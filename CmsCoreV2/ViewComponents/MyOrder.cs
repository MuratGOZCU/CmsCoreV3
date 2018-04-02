using CmsCoreV2.Data;
using CmsCoreV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.ViewComponents
{
    public class MyOrder : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;
            
        public MyOrder(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            long orderId = 0;
            string email = "";
            if (httpContextAccessor.HttpContext.Request.Method == "POST")
            { 
                string oid = httpContextAccessor.HttpContext.Request.Form["OrderId"];
                
                if (string.IsNullOrEmpty(oid))
                {
                    orderId = 0;
                }
                else
                {
                    orderId = Convert.ToInt64(oid);
                }
               email = httpContextAccessor.HttpContext.Request.Form["Email"];
            }

            var order = await GetMyOrder(orderId, email);
            return View(order);
        
        }
        private async Task<Order> GetMyOrder(long orderId, string email)
        {
            var order = await _context.Orders.Include(i=>i.OrderItems).ThenInclude(t=>t.Product).FirstOrDefaultAsync(c=> c.Id == orderId && c.BillingEmail == email);
            return order;
        }
        
    }
}
