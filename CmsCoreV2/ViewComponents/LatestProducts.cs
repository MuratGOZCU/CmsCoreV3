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
    public class LatestProducts : ViewComponent
    {
        private readonly ApplicationDbContext _context;
            
        public LatestProducts(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryNames = "", int count = 8, string title = "En Son Ürünler", string template = "Default")
        {
            ViewBag.ComponentTitle = title;
            var items = await GetItems(categoryNames, count);
            return View(template,items);
        }
        private async Task<List<Product>> GetItems(string categoryNames, int count)
        {
            categoryNames = categoryNames.ToLower();
            List<Product> products = GetProducts(GetCategories(categoryNames), count);
            return await Task.FromResult(products);
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

        public List<Product> GetProducts(string[] categories, int count)
        {
            if (categories.Length > 0)
            {
                return (from pc in _context.ProductProductCategories join p in _context.Products on pc.ProductId equals p.Id join c in _context.ProductCategories on pc.ProductCategoryId equals c.Id where (categories.Length > 0 ? categories.Contains(c.Name.ToLower()) : true) && p.IsApproved == true  && (p.CatalogVisibility == CatalogVisibility.VisibilityBoth || p.CatalogVisibility == CatalogVisibility.VisibilityCatalog) orderby p.CreateDate descending select p).Take(count).ToList();
            }
            else
            {
                return (from p in _context.Products.Include(i=>i.ProductProductCategories).ThenInclude(t=>t.ProductCategory) where p.IsApproved == true && (p.CatalogVisibility == CatalogVisibility.VisibilityBoth || p.CatalogVisibility == CatalogVisibility.VisibilityCatalog) orderby p.CreateDate descending select p).Take(count).ToList();
            }
        }
        
    }
}
