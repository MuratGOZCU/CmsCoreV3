using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmsCoreV2.Data;
using CmsCoreV2.Models;
using Microsoft.AspNetCore.Authorization;

namespace CmsCoreV2.Areas.CmsCore.Controllers
{
    [Authorize(Roles = "ADMIN")]
    [Area("CmsCore")]
    public class PopupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PopupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CmsCore/Popups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Popups.ToListAsync());
        }

        // GET: CmsCore/Popups/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var popup = await _context.Popups
                .SingleOrDefaultAsync(m => m.Id == id);
            if (popup == null)
            {
                return NotFound();
            }

            return View(popup);
        }

        // GET: CmsCore/Popups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CmsCore/Popups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,PageSlug,Photo,Url,Target,IsPublished,PublishDate,FinishDate,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Popup popup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(popup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(popup);
        }

        // GET: CmsCore/Popups/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var popup = await _context.Popups.SingleOrDefaultAsync(m => m.Id == id);
            if (popup == null)
            {
                return NotFound();
            }
            return View(popup);
        }

        // POST: CmsCore/Popups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,PageSlug,Photo,Url,Target,IsPublished,PublishDate,FinishDate,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Popup popup)
        {
            if (id != popup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(popup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PopupExists(popup.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(popup);
        }

        // GET: CmsCore/Popups/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var popup = await _context.Popups
                .SingleOrDefaultAsync(m => m.Id == id);
            if (popup == null)
            {
                return NotFound();
            }

            return View(popup);
        }

        // POST: CmsCore/Popups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var popup = await _context.Popups.SingleOrDefaultAsync(m => m.Id == id);
            _context.Popups.Remove(popup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PopupExists(long id)
        {
            return _context.Popups.Any(e => e.Id == id);
        }
    }
}
