using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.Security.Permissions;

namespace FuturifyModule
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataMigration, Migrations>();
            services.AddScoped<IPermissionProvider, AAVPermissionProvider>();
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }
}