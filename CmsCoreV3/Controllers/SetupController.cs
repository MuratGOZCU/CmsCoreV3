using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmsCoreV3.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsCoreV3.Controllers
{
    public class SetupController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor accessor;
        public SetupController(ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            this._context = context;
            this.accessor = accessor;
        }

        public IActionResult Index(int migrate = 0)
        {
            _context.Database.EnsureCreated();
            _context.Seed(accessor);
            return Content("Done!");
        }
    }
}