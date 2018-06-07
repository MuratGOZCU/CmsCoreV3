using CmsCoreV3.Data;
using CmsCoreV3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SaasKit.Multitenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Services
{
    public class LanguageService:ILanguageService
    {
        public readonly IList<Language> Languages;
        public readonly IList<Resource> Resources;
        private readonly AppTenant Tenant;
        public LanguageService(ApplicationDbContext context, ITenant<AppTenant> tenant)
        {
            Languages = context.Languages.ToList();
            Resources = context.Resources.ToList();
            Tenant = tenant.Value;
        }
        public LocalizedString GetResource(string name, string currentCulture, params object[] arguments)
        {
            var langId = Languages.FirstOrDefault(l => l.Culture == currentCulture && l.AppTenantId == Tenant.AppTenantId).Id;            
            var resource = Resources.FirstOrDefault(r => r.Name == name && r.LanguageId == langId && r.AppTenantId == Tenant.AppTenantId);
            var value = name;
            if (resource != null)
            {
                value = resource.Value;
            }
            return new LocalizedString(name, value, resource == null);
        }
        public LocalizedString GetResource(string name, string currentCulture)
        {
            var langId = Languages.FirstOrDefault(l => l.Culture == currentCulture && l.AppTenantId == Tenant.AppTenantId).Id;
            var resource = Resources.FirstOrDefault(r => r.Name == name && r.LanguageId == langId && r.AppTenantId == Tenant.AppTenantId);
            var value = name;
            if (resource != null)
            {
                value = resource.Value;
            }
            return new LocalizedString(name, value, resource == null);
        }
    }
    public interface ILanguageService
    {
        LocalizedString GetResource(string name, string currentCulture, params object[] arguments);
        LocalizedString GetResource(string name, string currentCulture);

    }
}
