﻿using CmsCoreV3.Data;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaasKit.Multitenancy;
using Microsoft.AspNetCore.Http;
using CmsCoreV3.Models;
using Microsoft.EntityFrameworkCore;

namespace CmsCoreV3
{
    public class CachingAppTenantResolver : MemoryCacheTenantResolver<AppTenant>
    {
        private readonly HostDbContext _dbContext;

        public CachingAppTenantResolver(HostDbContext dbContext, IMemoryCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            _dbContext = dbContext;
        }

        protected override string GetContextIdentifier(HttpContext context)
        {
            return context.Request.Host.Value.ToLower();
        }

        protected override IEnumerable<string> GetTenantIdentifiers(TenantContext<AppTenant> context)
        {
            return new[] { context.Tenant.Hostname };
        }

        protected override Task<TenantContext<AppTenant>> ResolveAsync(HttpContext context)
        {
            TenantContext<AppTenant> tenantContext = null;
            var hostName = context.Request.Host.Value.ToLower();

            var tenant = _dbContext.AppTenants.Include(t => t.Theme).FirstOrDefault(
               t => t.Hostname.Equals(hostName));


            if (tenant != null)
            {
                tenantContext = new TenantContext<AppTenant>(tenant);
            }

            return Task.FromResult(tenantContext);
        }
    }
}
