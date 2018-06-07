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
    public class Menu:ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public Menu(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string menuLocation)
        {

            var items = await GetItems(menuLocation);
            return View(items);
        }
        private async Task<List<MenuItem>> GetItems(string menuLocation)
        {
            return await Task.FromResult(GetMenuItemsByLocationName(menuLocation).Where(w => w.IsPublished == true).ToList());
        }
        public IEnumerable<MenuItem> GetMenuItemsByLocationName(string menuLocation)
        {
            List<Language> language = _context.Languages.ToList();
            var culture = (string)HttpContext.Items["Culture"];
            var menu = _context.Menus.Include(m => m.MenuItems).Include(l=>l.Language).Where(m => m.MenuLocation == menuLocation && m.Language.Culture == culture).FirstOrDefault();
            IList<MenuItem> menuItems;
            if (menu != null && menu.MenuItems != null)
            {
                menuItems = menu.MenuItems.Where(mi => mi.ParentMenuItem == null).ToList();
            }
            else
            {
                menuItems = new List<MenuItem>();
            }
            return menuItems;
        }
    }
}
