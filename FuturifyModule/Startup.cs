using System;
using FuturifyModule.Drivers;
using FuturifyModule.GraphQL;
using FuturifyModule.Handlers;
using FuturifyModule.Indexes;
using FuturifyModule.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Apis;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.GraphQL.Options;
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
            services.AddContentPart<RecruitmentRequest>();
            services.AddContentPart<Task>();
            services.AddContentPart<WorkflowPart>();
            services.AddContentPart<Product>();
            services.AddObjectGraphType<Product, ProductQueryObjectType>();
            services.AddInputObjectGraphType<Product, ProductInputObjectType>();

            services.Configure<GraphQLContentOptions>(options =>
            {
                options.ConfigurePart<Product>(partOptions =>
                {
                    partOptions.Hidden = true;
                });
            });
            //services.AddSingleton<IIndexProvider, RecruitmentRequestIndexProvider>();
            //services.AddSingleton<IIndexProvider, TaskIndexProvider>();
            services.AddSingleton<IIndexProvider, ProductIndexProvider>();
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }
}