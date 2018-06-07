using CmsCoreV3.Data;
using CmsCoreV3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.ViewComponents
{
    public class ProductCategories : ViewComponent
    {
        private readonly ApplicationDbContext _context;
            
        public ProductCategories(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryNames = "", int count = 8, string title = "En Son Ürünler")
        {
            ViewBag.ComponentTitle = title;
            var items = await GetItems(categoryNames, count);
            return View(items);
        }
        private async Task<List<ProductCategory>> GetItems(string categoryNames, int count)
        {
            categoryNames = categoryNames.ToLower();
            List<ProductCategory> pc = GetProductCategories(GetCategories(categoryNames), count);
            return await Task.FromResult(pc);
        }

        private string[] GetCategories(string categoryNames)
        {
            string[] categories;
            if (categoryNames == "")
            {
                categories = new string[0];
            }
            else
            {
                categories = categoryNames.Split(',');
            }

            for (var i = 0; i < categories.Length; i++)
            {
                categories[i] = categories[i].Trim().ToLower();
            }
            return categories;
        }       

        public List<ProductCategory> GetProductCategories(string[] categories, int count)
        {
            if (categories.Length > 0)
            {
                return (from c in _context.ProductCategories.Include("ProductProductCategories") where (categories.Length > 0 && c.ParentCategory != null ? categories.Contains(c.ParentCategory.Name.ToLower()) : true)  orderby c.CreateDate descending select c).Take(count).ToList();
            }
            else
            {
                return (from p in _context.ProductCategories.Include("ProductProductCategories") orderby p.CreateDate descending select p).Take(count).ToList();
            }
        }
        
    }
}
