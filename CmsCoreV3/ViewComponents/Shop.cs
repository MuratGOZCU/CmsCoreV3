using CmsCoreV3.Data;
using CmsCoreV3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.ViewComponents
{
    public class Shop : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public Shop(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryNames, int pageSize = 9)
        {
            int pageNumber = 1;

            string ob = Request.Query["orderby"];
            string pr = Request.Query["price"];
            ViewBag.OrderBy = ob ?? "date";
            ViewBag.Price = pr ?? "Tümü";
            int minPrice = 0;
            int maxPrice = 0;
            if (ViewBag.Price != "Tümü") { 
            minPrice = int.Parse(((string)ViewBag.Price).Substring(0, ((string)ViewBag.Price).IndexOf("-")));
            maxPrice = int.Parse(((string)ViewBag.Price).Substring(((string)ViewBag.Price).IndexOf("-")+1));
            }
            if (!String.IsNullOrEmpty(Request.Query["page"]))
            {
                pageNumber = Convert.ToInt32(Request.Query["page"]);
            }

            var items = await GetItems(categoryNames);
            var maxPageNumber = (items.Count() / pageSize) + 1;
            ViewBag.is404 = false;
            if (pageNumber > maxPageNumber)
            {
                pageNumber = maxPageNumber;
                ViewBag.is404 = true;
            }
            if (pageNumber < 1)
            {
                pageNumber = 1;
                ViewBag.is404 = true;
            }
            var orderby = (string)ViewBag.OrderBy;
            var pagedData = items;
                if (maxPrice > 0) { 
                pagedData = pagedData.Where(p => (p.SalePrice.HasValue ? minPrice <= p.SalePrice.Value && maxPrice >= p.SalePrice.Value : true));
            }
            if (orderby != "price-desc") {
                pagedData = pagedData.OrderBy(o => (orderby == "popularity" ? o.SaleCount : (orderby == "price" ? o.SalePrice : o.CreateDate.Ticks)));
                } else
            {
                pagedData = pagedData.OrderByDescending(o => o.SalePrice);
            }
                return View(pagedData.ToPagedList(pageSize, pageNumber));
          
        }
        public async Task<IQueryable<Product>> GetItems(string categoryNames)
        {
            if (categoryNames != null)
            {
                return await Task.FromResult(GetProductsByCategoryNames(categoryNames, 1000));
            }
            else
            {
                return await Task.FromResult(GetProducts());
            }
        }
        public IQueryable<Product> GetProducts()
        {
            var posts = GetAll("ProductMedias","ProductProductCategories","ProductProductCategories.ProductCategory");
            return posts;
        }
        public IQueryable<Product> GetAll(params string[] navigations)
        {
            var set = _context.Products.Where(p=>p.IsApproved==true  && (p.CatalogVisibility == CatalogVisibility.VisibilityBoth || p.CatalogVisibility == CatalogVisibility.VisibilityCatalog)).AsQueryable();
            foreach (string nav in navigations)
                set = set.Include(nav);
            return set;
        }
        public IQueryable<Product> GetProductsByCategoryNames(string categoryNames, int count)
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
            var products = GetProductsByCategoryNames(categories, count);
            return products;
        }


        public IQueryable<Product> GetProductsByCategoryNames(string[] categories, int count)
        {
            
            if (categories.Length > 0)
            {
                ViewBag.ProductCategory = _context.ProductCategories.FirstOrDefault(c => c.Name.ToLower() == categories[0]);
                return (from pc in _context.ProductProductCategories join p in _context.Products.Include(i=>i.ProductMedias).Include("ProductProductCategories").Include("ProductProductCategories.ProductCategory") on pc.ProductId equals p.Id join c in _context.ProductCategories on pc.ProductCategoryId equals c.Id where (categories.Length > 0 ? categories.Contains(c.Name.ToLower()) : true) && p.IsApproved == true && (p.CatalogVisibility == CatalogVisibility.VisibilityBoth || p.CatalogVisibility == CatalogVisibility.VisibilityCatalog) orderby p.CreateDate descending select p);
            }
            else
            {
                return (from p in _context.Products.Include(i=>i.ProductMedias).Include("ProductProductCategories").Include("ProductProductCategories.ProductCategory") where p.IsApproved == true  && (p.CatalogVisibility == CatalogVisibility.VisibilityBoth || p.CatalogVisibility == CatalogVisibility.VisibilityCatalog) orderby p.CreateDate descending select p);
            }
        }
    }
}