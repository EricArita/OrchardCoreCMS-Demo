using System;
using FuturifyModule.GraphQL;
using FuturifyModule.Handlers;
using FuturifyModule.Indexes;
using FuturifyModule.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Apis;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Handlers;
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
            services.AddContentPart<Category>();
            services.AddObjectGraphType<Product, ProductType>();
            services.AddObjectGraphType<ContentItem, CustomContentItemType>();
            services.AddObjectGraphType<Category, CategoryType>();
            services.AddSingleton<IIndexProvider, ProductIndexProvider>();
            services.AddSingleton<IIndexProvider, CategoryIndexProvider>();

            //services.AddSingleton<IIndexProvider, RecruitmentRequestIndexProvider>();
            //services.AddSingleton<IIndexProvider, TaskIndexProvider>();
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }
}