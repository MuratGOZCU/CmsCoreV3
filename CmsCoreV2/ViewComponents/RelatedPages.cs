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
            }
            else
            {
                childs = context.Pages.Include(p=>p.ParentPage).Where(w => w.ParentPageId == page.ParentPageId && w.IsPublished == isPublished).ToList();
            }
            return childs;
        }
    }
}