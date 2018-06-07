using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CmsCoreV3.Data;
using CmsCoreV3.Models;
using Microsoft.EntityFrameworkCore;

namespace CmsCoreV3.ViewComponents
{
    public class SiteMap : ViewComponent
    {
        private readonly ApplicationDbContext context;

        public SiteMap(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long? parentPageId)
        {
            var items = await GetItems(parentPageId);
            return View(items);
        }

        private async Task<List<Page>> GetItems(long? parentPageId)
        {
            var culture = (string)HttpContext.Items["Culture"];
            List<Page> pages = context.Pages.Include("Language").Include("ChildPages").Include("ChildPages.ChildPages").Where(p => p.ParentPageId == parentPageId && p.Language.Culture == culture).ToList<Page>();
            return await Task.FromResult(pages);
        }
    }
}
