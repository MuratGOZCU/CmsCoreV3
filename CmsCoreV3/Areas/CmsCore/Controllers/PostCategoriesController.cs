using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmsCoreV3.Data;
using CmsCoreV3.Models;
using SaasKit.Multitenancy;
using Z.EntityFramework.Plus;
using Microsoft.AspNetCore.Authorization;

namespace CmsCoreV3.Areas.CmsCore.Controllers
{
    [Authorize(Roles = "ADMIN,Supplier,PRODUCTCATEGORY")]
    [Area("CmsCore")]
    public class PostCategoriesController : ControllerBase
    {
        public PostCategoriesController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {
        }
        [Authorize(Roles="ADMIN,ProductCategoryIndex")]
        // GET: CmsCore/PostCategories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SetFiltered<PostCategory>().Where(x => x.AppTenantId == tenant.AppTenantId).Include(p => p.Language).Include(p => p.ParentCategory);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles="ADMIN,ProductCategoryDetails")]
        // GET: CmsCore/PostCategories/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategory = await _context.PostCategories
                .Include(p => p.Language)
                .Include(p => p.ParentCategory)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (postCategory == null)
            {
                return NotFound();
            }

            return View(postCategory);
        }
        [Authorize(Roles="ADMIN,ProductCategoryCreate")]
        // GET: CmsCore/PostCategories/Create
        public IActionResult Create()
        {
            var postCategory = new PostCategory();
            postCategory.CreatedBy = User.Identity.Name ?? "username";
            postCategory.CreateDate = DateTime.Now;
            postCategory.UpdatedBy = User.Identity.Name ?? "username";
            postCategory.UpdateDate = DateTime.Now;
            postCategory.AppTenantId = tenant.AppTenantId;
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "NativeName");
            ViewData["ParentCategoryId"] = new SelectList(_context.PostCategories, "Id", "Name");
            var parentPost = _context.PostCategories.ToList();
            var result = "";
            recursePost(ref parentPost, null, 0,null, ref result);
            ViewBag.ParentPostOptions = result;

           
            return View(postCategory);
        }
        static void recursePost(ref List<PostCategory> cl, PostCategory start, int level, long? selected, ref string result)
        {
            foreach (PostCategory child in cl)
            {
                if (child.ParentCategory == start)
                {
                    result += "<option " + (selected.HasValue && child.Id == selected.Value ? "selected" : "") + " value='" + child.Id.ToString() + "'>" + (new String(' ', level * 2)).Replace(" ", "&nbsp&nbsp;") + child.Name + "</option>";
                    recursePost(ref cl, child, level + 1,selected, ref result);
                }
            }

        }
        [Authorize(Roles="ADMIN,ProductCategoryCreate")]
        // POST: CmsCore/PostCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Slug,ParentCategoryId,Description,LanguageId,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] PostCategory postCategory)
        {
            if (ModelState.IsValid)
            {
                postCategory.CreatedBy = User.Identity.Name ?? "username";
                postCategory.CreateDate = DateTime.Now;
                postCategory.UpdatedBy = User.Identity.Name ?? "username";
                postCategory.UpdateDate = DateTime.Now;
                postCategory.AppTenantId = tenant.AppTenantId;

                _context.Add(postCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "NativeName", postCategory.LanguageId);

            var parentPost = _context.PostCategories.ToList();
            var result = "";
            recursePost(ref parentPost, null, 0, postCategory.ParentCategoryId, ref result);
            ViewBag.ParentPostOptions = result;

            return View(postCategory);
        }
        [Authorize(Roles="ADMIN,ProductCategoryEdit")]
        // GET: CmsCore/PostCategories/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategory = await _context.PostCategories.SingleOrDefaultAsync(m => m.Id == id);
            if (postCategory == null)
            {
                return NotFound();
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "NativeName", postCategory.LanguageId);

            ViewData["ParentCategoryId"] = new SelectList(_context.PostCategories, "Id", "Name", postCategory.ParentCategoryId);
            var parentPost = _context.PostCategories.ToList();
            var result = "";
            recursePost(ref parentPost, null, 0, postCategory.ParentCategoryId, ref result);
            ViewBag.ParentPostOptions = result;

            postCategory.UpdatedBy = User.Identity.Name ?? "username";
            postCategory.UpdateDate = DateTime.Now;
            postCategory.AppTenantId = tenant.AppTenantId;

           
            return View(postCategory);
        }
        [Authorize(Roles="ADMIN,ProductCategoryEdit")]
        // POST: CmsCore/PostCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,Slug,ParentCategoryId,Description,LanguageId,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] PostCategory postCategory)
        {
            if (id != postCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    postCategory.UpdatedBy = User.Identity.Name ?? "username";
                    postCategory.UpdateDate = DateTime.Now;
                    postCategory.AppTenantId = tenant.AppTenantId;

                    _context.Update(postCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostCategoryExists(postCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "NativeName", postCategory.LanguageId);
            ViewData["ParentCategoryId"] = new SelectList(_context.PostCategories, "Id", "Name", postCategory.ParentCategoryId);
            var parentPost = _context.PostCategories.ToList();
            var result = "";
            recursePost(ref parentPost, null, 0, postCategory.ParentCategoryId, ref result);
            ViewBag.ParentPostOptions = result;
            return View(postCategory);
        }
        [Authorize(Roles="ADMIN,ProductCategoryDelete")]
        // GET: CmsCore/PostCategories/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategory = await _context.PostCategories
                .Include(p => p.Language)
                .Include(p => p.ParentCategory)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (postCategory == null)
            {
                return NotFound();
            }

            return View(postCategory);
        }
        [Authorize(Roles="ADMIN,ProductCategoryDelete")]

        // POST: CmsCore/PostCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var postCategory = await _context.PostCategories.SingleOrDefaultAsync(m => m.Id == id);
            _context.PostCategories.Remove(postCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PostCategoryExists(long id)
        {
            return _context.PostCategories.Any(e => e.Id == id);
        }
    }
}
