using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmsCoreV2.Data;
using CmsCoreV2.Models;
using SaasKit.Multitenancy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CmsCoreV2.Areas.CmsCore.Controllers
{
    [Authorize(Roles = "ADMIN")]
    [Area("CmsCore")]
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        protected readonly AppTenant tenant;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUsersController(ApplicationDbContext context, ITenant<AppTenant> tenant,UserManager<ApplicationUser> _userManager) 
        {
            this.tenant = tenant?.Value;
            this._context = context;
            this._userManager = _userManager;
        }

        // GET: CmsCore/ApplicationUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUser.ToListAsync());
        }

        // GET: CmsCore/ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // GET: CmsCore/ApplicationUsers/Create
        private IActionResult Create()
        {
            var user = new ApplicationUser();
        
            return View(user);
        }

        // POST: CmsCore/ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        private async Task<IActionResult> Create([Bind("AppTenantId,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                applicationUser.AppTenantId = tenant.AppTenantId;
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
           
            return View(applicationUser);
        }

        // GET: CmsCore/ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            applicationUser.AppTenantId = tenant.AppTenantId;
            ViewData["Roles"] = new MultiSelectList(_context.Roles.ToList(), "Name", "Name",await _userManager.GetRolesAsync(applicationUser));
            return View(applicationUser);
        }

        // POST: CmsCore/ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AppTenantId,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,FirstName,LastName,Address,Street,City,Country,County,ZipCode,Phone")] ApplicationUser applicationUser, IEnumerable<string> RoleId)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }
            var user = _context.ApplicationUser.FirstOrDefault(f=>f.Id == id);
            if (ModelState.IsValid)
            {
                try
                {
                    
                    user.FirstName = applicationUser.FirstName;
                    user.LastName = applicationUser.LastName;
                    user.City = applicationUser.City;
                    user.Address = applicationUser.Address;
                    user.Country = applicationUser.Country;
                    user.County = applicationUser.County;
                    user.Phone = applicationUser.Phone;
                    user.Street = applicationUser.Street;
                    user.ZipCode = applicationUser.ZipCode;
                    user.AppTenantId = tenant.AppTenantId;
                    _context.Update(user);
                    await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                    await _context.SaveChangesAsync();
                    await _userManager.AddToRolesAsync(user, RoleId);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
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
            ViewData["Roles"] = new MultiSelectList(_context.Roles.ToList(), "Name", "Name",await _userManager.GetRolesAsync(user));
            return View(applicationUser);
        }

        // GET: CmsCore/ApplicationUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: CmsCore/ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationUser.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
