using CmsCoreV2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Data
{
    public static class HostDbContextSeed
    {
        public static void Seed(this HostDbContext context)
        {
            // migration'ları veritabanına uygula
            context.Database.Migrate();

            // Look for any tenants record.
            if (context.AppTenants.Any())
            {
                return;   // DB has been seeded
            }
            // Perform seed operations
            
            var theme = AddTheme(context);
            AddAppTenants(context, theme);

        }

        public static void AddAppTenants(HostDbContext context, Theme theme)
        {
            var appTenant = new AppTenant();
            appTenant.Name = "BilgiKoleji";
            appTenant.Title = "Bilgi Koleji";
            appTenant.Hostname = "localhost:60002";
            appTenant.ThemeName = theme.Name;
            appTenant.ConnectionString = $"Server=.;Database={appTenant.Name};Trusted_Connection=True;MultipleActiveResultSets=true";
            appTenant.Folder = "bilgikoleji";
            appTenant.Theme = theme;
            appTenant.ThemeId = theme.Id;
            context.AppTenants.Add(appTenant);

            var appTenant2 = new AppTenant();
            appTenant2.Name = "Atasehir";
            appTenant2.Title = "Bilgi Koleji Ataşehir";
            appTenant2.Hostname = "localhost:60001";
            appTenant2.ThemeName = theme.Name;
            appTenant2.ConnectionString = $"Server=.;Database={appTenant2.Name};Trusted_Connection=True;MultipleActiveResultSets=true";
            appTenant2.Folder = "atasehir";
            appTenant2.Theme = theme;
            appTenant2.ThemeId = theme.Id;
            context.AppTenants.Add(appTenant2);

            var appTenant3 = new AppTenant();
            appTenant3.Name = "Maltepe";
            appTenant3.Title = "Bilgi Koleji Maltepe";
            appTenant3.Hostname = "localhost:60003";
            appTenant3.ThemeName = theme.Name;
            appTenant3.ConnectionString = $"Server=.;Database={appTenant3.Name};Trusted_Connection=True;MultipleActiveResultSets=true";
            appTenant3.Folder = "maltepe";
            appTenant3.Theme = theme;
            appTenant3.ThemeId = theme.Id;
            context.AppTenants.Add(appTenant3);

            var appTenant4 = new AppTenant();
            appTenant4.Name = "Mersin";
            appTenant4.Title = "Bilgi Koleji Mersin";
            appTenant4.Hostname = "localhost:60004";
            appTenant4.ThemeName = theme.Name;
            appTenant4.ConnectionString = $"Server=.;Database={appTenant4.Name};Trusted_Connection=True;MultipleActiveResultSets=true";
            appTenant4.Folder = "mersin";
            appTenant4.Theme = theme;
            appTenant4.ThemeId = theme.Id;
            context.AppTenants.Add(appTenant4);
            context.SaveChanges();
        }
        public static Theme AddTheme(HostDbContext context)
        {
            var defaultTheme = new Theme();
            defaultTheme.Name = "edugate";
            defaultTheme.Logo = "/edugate/images/logo.png";
            defaultTheme.ImageUrl = "";
            defaultTheme.MetaDescription = "";
            defaultTheme.MetaTitle = "";
            defaultTheme.MetaKeywords = "";
            defaultTheme.CreateDate = DateTime.Now;
            defaultTheme.UpdateDate = DateTime.Now;
            defaultTheme.CreatedBy = "UserName";
            defaultTheme.UpdatedBy = "UserName";
            defaultTheme.CustomCSS = "";

            defaultTheme.MenuLocations = "Primary";
            defaultTheme.ComponentTemplates = "Default,Gallery,MiniGallery,ContactForm,JobApplicationForm,PreRegistrationForm,SurveyForm,LogoSlider,Secondary";
            defaultTheme.PageTemplates = "Page,Blog,Contact,Gallery,Index,JobApplication,Post,Posts,PreRegistration,Search,SiteMap,Survey";
            context.Themes.Add(defaultTheme);
            context.SaveChanges();
            return defaultTheme;
        }


    }
}
