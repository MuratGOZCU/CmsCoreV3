using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaasKit.Multitenancy;
using CmsCoreV3.Models;
using CmsCoreV3.Data;
using Microsoft.AspNetCore.Authorization;

namespace CmsCoreV3.Areas.CmsCore.Controllers
{
    [Authorize(Roles = "ADMIN,Supplier")]
    [Area("CmsCore")]

    public class DashboardController: ControllerBase
    {
        public DashboardController( ITenant<AppTenant> tenant, ApplicationDbContext context) : base(context, tenant)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
