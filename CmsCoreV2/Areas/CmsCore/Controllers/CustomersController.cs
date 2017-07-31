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

namespace CmsCoreV2.Areas.CmsCore.Controllers
{
    [Area("CmsCore")]
    public class CustomersController : ControllerBase
    {
        public CustomersController(ApplicationDbContext context, ITenant<AppTenant> tenant) : base(context, tenant)
        {

        }
        // GET: CmsCore/Customers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Customers.Include(c => c.BillingCity).Include(c => c.BillingCountry).Include(c => c.BillingDistrict).Include(c => c.ShippingCity).Include(c => c.ShippingCountry).Include(c => c.ShippingDistrict);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CmsCore/Customers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.BillingCity)
                .Include(c => c.BillingCountry)
                .Include(c => c.BillingDistrict)
                .Include(c => c.ShippingCity)
                .Include(c => c.ShippingCountry)
                .Include(c => c.ShippingDistrict)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: CmsCore/Customers/Create
        public IActionResult Create()
        {
            var customer = new Customer();
            customer.CreatedBy = User.Identity.Name ?? "username";
            customer.CreateDate = DateTime.Now;
            customer.UpdatedBy = User.Identity.Name ?? "username";
            customer.UpdateDate = DateTime.Now;
            customer.AppTenantId = tenant.AppTenantId;


            ViewData["BillingCityId"] = new SelectList(_context.Regions, "Id", "Name");
            ViewData["BillingCountryId"] = new SelectList(_context.Regions, "Id", "Name");
            ViewData["BillingDistrictId"] = new SelectList(_context.Regions, "Id", "Name");
            ViewData["ShippingCityId"] = new SelectList(_context.Regions, "Id", "Name");
            ViewData["ShippingCountryId"] = new SelectList(_context.Regions, "Id", "Name");
            ViewData["ShippingDistrictId"] = new SelectList(_context.Regions, "Id", "Name");
            return View(customer);
        }

        // POST: CmsCore/Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillingAddress,BillingFirstName,BillingLastName,BillingCompanyName,BillingDistrictId,BillingCityId,BillingZipCode,BillingCountryId,ShippingAddress,ShippingFirstName,ShippingLastName,ShippingCompanyName,ShippingDistrictId,ShippingCityId,ShippingCountryId,ShippingZipCode,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CreatedBy = User.Identity.Name ?? "username";
                customer.CreateDate = DateTime.Now;
                customer.UpdatedBy = User.Identity.Name ?? "username";
                customer.UpdateDate = DateTime.Now;
                customer.AppTenantId = tenant.AppTenantId;

                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BillingCityId"] = new SelectList(_context.Regions, "Id", "Name", customer.BillingCityId);
            ViewData["BillingCountryId"] = new SelectList(_context.Regions, "Id", "Name", customer.BillingCountryId);
            ViewData["BillingDistrictId"] = new SelectList(_context.Regions, "Id", "Name", customer.BillingDistrictId);
            ViewData["ShippingCityId"] = new SelectList(_context.Regions, "Id", "Name", customer.ShippingCityId);
            ViewData["ShippingCountryId"] = new SelectList(_context.Regions, "Id", "Name", customer.ShippingCountryId);
            ViewData["ShippingDistrictId"] = new SelectList(_context.Regions, "Id", "Name", customer.ShippingDistrictId);
            return View(customer);
        }

        // GET: CmsCore/Customers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.SingleOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.UpdatedBy = User.Identity.Name ?? "username";
            customer.UpdateDate = DateTime.Now;
            customer.AppTenantId = tenant.AppTenantId;

            ViewData["BillingCityId"] = new SelectList(_context.Regions, "Id", "Name", customer.BillingCityId);
            ViewData["BillingCountryId"] = new SelectList(_context.Regions, "Id", "Name", customer.BillingCountryId);
            ViewData["BillingDistrictId"] = new SelectList(_context.Regions, "Id", "Name", customer.BillingDistrictId);
            ViewData["ShippingCityId"] = new SelectList(_context.Regions, "Id", "Name", customer.ShippingCityId);
            ViewData["ShippingCountryId"] = new SelectList(_context.Regions, "Id", "Name", customer.ShippingCountryId);
            ViewData["ShippingDistrictId"] = new SelectList(_context.Regions, "Id", "Name", customer.ShippingDistrictId);
            return View(customer);
        }

        // POST: CmsCore/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BillingAddress,BillingFirstName,BillingLastName,BillingCompanyName,BillingDistrictId,BillingCityId,BillingZipCode,BillingCountryId,ShippingAddress,ShippingFirstName,ShippingLastName,ShippingCompanyName,ShippingDistrictId,ShippingCityId,ShippingCountryId,ShippingZipCode,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy,AppTenantId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    customer.UpdatedBy = User.Identity.Name ?? "username";
                    customer.UpdateDate = DateTime.Now;
                    customer.AppTenantId = tenant.AppTenantId;

                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["BillingCityId"] = new SelectList(_context.Regions, "Id", "Name", customer.BillingCityId);
            ViewData["BillingCountryId"] = new SelectList(_context.Regions, "Id", "Name", customer.BillingCountryId);
            ViewData["BillingDistrictId"] = new SelectList(_context.Regions, "Id", "Name", customer.BillingDistrictId);
            ViewData["ShippingCityId"] = new SelectList(_context.Regions, "Id", "Name", customer.ShippingCityId);
            ViewData["ShippingCountryId"] = new SelectList(_context.Regions, "Id", "Name", customer.ShippingCountryId);
            ViewData["ShippingDistrictId"] = new SelectList(_context.Regions, "Id", "Name", customer.ShippingDistrictId);
            return View(customer);
        }

        // GET: CmsCore/Customers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.BillingCity)
                .Include(c => c.BillingCountry)
                .Include(c => c.BillingDistrict)
                .Include(c => c.ShippingCity)
                .Include(c => c.ShippingCountry)
                .Include(c => c.ShippingDistrict)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: CmsCore/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(m => m.Id == id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CustomerExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
