using CmsCoreV2.Data;
using CmsCoreV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsCoreV2.ViewComponents
{
    public class EmbedForm : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public EmbedForm(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string template, string name="", string slug="")
        {
            var form = await GetForm(name, template, slug);
            if (form == null)
            {
                form = new Form();
            }
            if (String.IsNullOrEmpty(template))
            {
                template = form.Template;
            }
            return View(template, form);

        }

        public Form GetById(long id, params string[] navigations)
        {
            var set = _context.Forms.AsQueryable();
            foreach (string nav in navigations)
                set = set.Include(nav);

            return set.FirstOrDefault(f => f.Id == id);
        }

        public Form Get(Expression<Func<Form, bool>> where, params string[] navigations)
        {
            var set = _context.Forms.AsQueryable();
            foreach (string nav in navigations)
                set = set.Include(nav);
            return set.Where(where).FirstOrDefault<Form>();
        }

        public Form GetForm(long id)
        {
            var form = GetById(id, "FormFields");
            return form;
        }
        public Form GetForm(string name, string slug)
        {
            Form form; 
            if (slug == "")
            {
                name = name.ToLower();
                form = Get(f => f.FormName.ToLower() == name, "FormFields");
                
            }
            else
            {
                slug = slug.ToLower();
                form = Get(f => f.Slug.ToLower() == slug, "FormFields");
                
            }
            return form;
        }

        private async Task<CmsCoreV2.Models.Form> GetForm(string formName, string template, string slug)
        {
            return await Task.FromResult(GetForm(formName, slug));
        }
    }
}
