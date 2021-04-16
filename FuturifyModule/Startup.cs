using System;
using FuturifyModule.Drivers;
using FuturifyModule.Handlers;
using FuturifyModule.Indexes;
using FuturifyModule.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.Security.Permissions;
using YesSql.Indexes;

namespace FuturifyModule
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataMigration, Migrations>();
            services.AddScoped<IPermissionProvider, AAVPermissionProvider>();
            services.AddScoped<IContentHandler, AAVHandler>();
            services.AddContentPart<RecruitmentRequestPart>();
            services.AddContentPart<WorkflowPart>();
            services.AddContentPart<TaskPart>();
            services.AddSingleton<IIndexProvider, RecruitmentRequestIndexProvider>();
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }
}