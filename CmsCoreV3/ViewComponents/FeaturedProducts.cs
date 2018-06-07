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
    public class FeaturedProducts : ViewComponent
    {
        private readonly ApplicationDbContext _context;
            
        public FeaturedProducts(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryNames = "", int count = 8)
        {
            var items = await GetItems(categoryNames, count);
            return View(items);
        }
        private async Task<List<Product>> GetItems(string categoryNames, int count)
        {
            categoryNames = categoryNames.ToLower();
            List<Product> products = GetFeaturedProducts(GetCategories(categoryNames), count);
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

        public List<Product> GetFeaturedProducts(string[] categories, int count)
        {
            if (categories.Length > 0)
            {
                return (from pc in _context.ProductProductCategories join p in _context.Products.Include(i=>i.ProductMedias)  on pc.ProductId equals p.Id join c in _context.ProductCategories on pc.ProductCategoryId equals c.Id where (categories.Length > 0 ? categories.Contains(c.Name.ToLower()) : true) && p.IsFeatured == true && p.IsApproved == true  && (p.CatalogVisibility == CatalogVisibility.VisibilityBoth || p.CatalogVisibility == CatalogVisibility.VisibilityCatalog) orderby p.CreateDate descending select p).Take(count).ToList();
            }
            else
            {
                return (from p in _context.Products.Include(i=>i.ProductMedias) where p.IsFeatured==true && p.IsApproved == true  && (p.CatalogVisibility == CatalogVisibility.VisibilityBoth || p.CatalogVisibility == CatalogVisibility.VisibilityCatalog) orderby p.CreateDate descending select p).Take(count).ToList();
            }
        }
        
    }
}
