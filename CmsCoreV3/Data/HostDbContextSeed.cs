using CmsCoreV3.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Data
{
    public static class HostDbContextSeed
    {
        public static void Seed(this HostDbContext context)
        {
            // apply migrations to database
            context.Database.Migrate();

            // Look for any tenants record
            if (context.AppTenants.Any())
            {
                return;   // DB has been seeded
            }
            // Perform seed operations
            
            // add themes
            var edugateTheme = AddEdugateTheme(context);
            var poloCorporate5Theme = AddPoloCorporate5Theme(context);
            var poloShop3Theme = AddPoloShop3Theme(context);

            // add app tenants
            AddBilgiKolejiAppTenants(context, edugateTheme); // https://www.bilgikoleji.com and additional campuses (optional)
            AddBirInsanBelgeAppTenant(context, poloCorporate5Theme); // https://www.birinsanbelge.com
            AddBilgiStoreAppTenant(context, poloShop3Theme); // https://store.bilgikoleji.com
        }

        public static Theme AddEdugateTheme(HostDbContext context)
        {
            var theme = new Theme();
            theme.Name = "Edugate";
            theme.Logo = "/edugate/images/logo.png";
            theme.ImageUrl = "";
            theme.MetaDescription = "";
            theme.MetaTitle = "";
            theme.MetaKeywords = "";
            theme.CreateDate = DateTime.Now;
            theme.UpdateDate = DateTime.Now;
            theme.CreatedBy = "UserName";
            theme.UpdatedBy = "UserName";
            theme.CustomCSS = "";

            theme.MenuLocations = "Primary";
            theme.ComponentTemplates = "Default,Gallery,MiniGallery,ContactForm,JobApplicationForm,PreRegistrationForm,SurveyForm,LogoSlider,Secondary";
            theme.PageTemplates = "Page,Blog,Contact,Gallery,Index,JobApplication,Post,Posts,PreRegistration,Search,SiteMap,Survey";

            context.Themes.Add(theme);
            context.SaveChanges();

            return theme;
        }
        public static Theme AddPoloCorporate5Theme(HostDbContext context)
        {
            var theme = new Theme();
            theme.Name = "PoloCorporate5";
            theme.Logo = "";
            theme.ImageUrl = "";
            theme.MetaDescription = "";
            theme.MetaTitle = "";
            theme.MetaKeywords = "";
            theme.CreateDate = DateTime.Now;
            theme.UpdateDate = DateTime.Now;
            theme.CreatedBy = "UserName";
            theme.UpdatedBy = "UserName";
            theme.CustomCSS = "";

            theme.MenuLocations = "Primary";
            theme.ComponentTemplates = "Default,Gallery,MiniGallery,ContactForm,JobApplicationForm,PreRegistrationForm,SurveyForm,LogoSlider,Secondary";
            theme.PageTemplates = "Page,Blog,Contact,Gallery,Index,JobApplication,Post,Posts,PreRegistration,Search,SiteMap,Survey";

            context.Themes.Add(theme);
            context.SaveChanges();

            return theme;

        }
        public static Theme AddPoloShop3Theme(HostDbContext context)
        {
            var theme = new Theme();
            theme.Name = "PoloShop3";
            theme.Logo = "";
            theme.ImageUrl = "";
            theme.MetaDescription = "";
            theme.MetaTitle = "";
            theme.MetaKeywords = "";
            theme.CreateDate = DateTime.Now;
            theme.UpdateDate = DateTime.Now;
            theme.CreatedBy = "UserName";
            theme.UpdatedBy = "UserName";
            theme.CustomCSS = "";

            theme.MenuLocations = "Primary";
            theme.ComponentTemplates = "Default,Gallery,MiniGallery,ContactForm,JobApplicationForm,PreRegistrationForm,SurveyForm,LogoSlider,Secondary";
            theme.PageTemplates = "Page,Blog,Contact,Gallery,Index,JobApplication,Post,Posts,PreRegistration,Search,SiteMap,Survey";

            context.Themes.Add(theme);
            context.SaveChanges();

            return theme;

        }

        public static void AddBilgiKolejiAppTenants(HostDbContext context, Theme theme)
        {
            // add main BilgiKoleji website
            var bilgiKolejiAppTenant = new AppTenant();
            bilgiKolejiAppTenant.Name = "BilgiKoleji";
            bilgiKolejiAppTenant.Title = "Bilgi Koleji";
            bilgiKolejiAppTenant.Hostname = "localhost:60002";
            bilgiKolejiAppTenant.ThemeName = theme.Name;
            bilgiKolejiAppTenant.ConnectionString = $"Server=.;Database={bilgiKolejiAppTenant.Name};Trusted_Connection=True;MultipleActiveResultSets=true";
            bilgiKolejiAppTenant.Folder = "bilgikoleji";
            bilgiKolejiAppTenant.Theme = theme;
            bilgiKolejiAppTenant.ThemeId = theme.Id;
            context.AppTenants.Add(bilgiKolejiAppTenant);

            // add additional campus websites (optional)
            /*
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
            */

            context.SaveChanges();
        }
        public static void AddBirInsanBelgeAppTenant(HostDbContext context, Theme theme)
        {
            var birInsanBelgeAppTenant = new AppTenant();
            birInsanBelgeAppTenant.Name = "BirInsanBelge";
            birInsanBelgeAppTenant.Title = "Bir İnsan Belgelendirme";
            birInsanBelgeAppTenant.Hostname = "localhost:60005";
            birInsanBelgeAppTenant.ThemeName = theme.Name;
            birInsanBelgeAppTenant.ConnectionString = $"Server=.;Database={birInsanBelgeAppTenant.Name};Trusted_Connection=True;MultipleActiveResultSets=true";
            birInsanBelgeAppTenant.Folder = "birinsanbelge";
            birInsanBelgeAppTenant.Theme = theme;
            birInsanBelgeAppTenant.ThemeId = theme.Id;

            context.AppTenants.Add(birInsanBelgeAppTenant);
            context.SaveChanges();
        }
        public static void AddBilgiStoreAppTenant(HostDbContext context, Theme theme)
        {
            var bilgiStoreAppTenant = new AppTenant();
            bilgiStoreAppTenant.Name = "BilgiStore";
            bilgiStoreAppTenant.Title = "Bilgi Store";
            bilgiStoreAppTenant.Hostname = "localhost:60005";
            bilgiStoreAppTenant.ThemeName = theme.Name;
            bilgiStoreAppTenant.ConnectionString = $"Server=.;Database={bilgiStoreAppTenant.Name};Trusted_Connection=True;MultipleActiveResultSets=true";
            bilgiStoreAppTenant.Folder = "bilgistore";
            bilgiStoreAppTenant.Theme = theme;
            bilgiStoreAppTenant.ThemeId = theme.Id;

            context.AppTenants.Add(bilgiStoreAppTenant);
            context.SaveChanges();
        }
    }
}
