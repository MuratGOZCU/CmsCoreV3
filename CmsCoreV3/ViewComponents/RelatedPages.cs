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

    public class RelatedPages : ViewComponent
    {

        private readonly ApplicationDbContext context;
        
        public RelatedPages(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task<IViewComponentResult> InvokeAsync(long Id)
        {
            var items = await RelatedPage(Id);
            Console.WriteLine();
            return View(items);
        }

        public async Task<List<Page>> RelatedPage(long Id)
        {
            return await Task.FromResult(ChildPagesWeb(Id,true).ToList());
        }
        
        public IEnumerable<Page> ChildPagesWeb(long id,bool isPublished)
        {
            Page page = context.Pages.Include(g=>g.ParentPage).Where(p => p.Id == id).FirstOrDefault();
            IEnumerable<Page> childs;
            if (page.ParentPageId == null)
            {
                childs = context.Pages.Include(p => p.ChildPages).Where(p => p.Id == id && p.IsPublished == isPublished).AsEnumerable<Page>();
                childs = childs.OrderBy(p => p.Position);
            }
            else
            {
                childs = context.Pages.Include(p=>p.ParentPage).Where(w => w.ParentPageId == page.ParentPageId && w.IsPublished == isPublished).ToList();
                childs = childs.OrderBy(p => p.Position);
            }
            ViewBag.CurrentPageId = id;
            return childs;
        }
    }
}