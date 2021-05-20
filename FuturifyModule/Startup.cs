using System;
using FuturifyModule.GraphQL;
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
            //services.AddScoped<IContentHandler, AAVHandler>();
            //services.AddContentPart<RecruitmentRequest>();
            //services.AddContentPart<Task>();
            //services.AddContentPart<WorkflowPart>();
            //services.AddContentPart<Product>();
            //services.AddContentPart<Category>();
            //services.AddObjectGraphType<Product, ProductType>();
            //services.AddObjectGraphType<ContentItem, CustomContentItemType>();
            //services.AddObjectGraphType<Category, CategoryType>();
            //services.AddSingleton<IIndexProvider, ProductIndexProvider>();
            //services.AddSingleton<IIndexProvider, CategoryIndexProvider>();

            //services.AddSingleton<IIndexProvider, RecruitmentRequestIndexProvider>();
            //services.AddSingleton<IIndexProvider, TaskIndexProvider>();
            RegisterContentParts(services);
            RegisterIndexProviders(services);
        }


        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }

        private void RegisterContentParts(IServiceCollection services)
        {
            services.AddContentPart<Assest>();
            services.AddContentPart<AssessmentCriteria>();
            services.AddContentPart<AssessmentCriteriaTemplate>();
            services.AddContentPart<Candidate>();
            services.AddContentPart<ComputerProficiency>();
            services.AddContentPart<Comment>();
            services.AddContentPart<Department>();
            services.AddContentPart<Education>();
            services.AddContentPart<Employee>();
            services.AddContentPart<EmploymentRecord>();
            services.AddContentPart<Family>();
            services.AddContentPart<InterviewAssessment>();
            services.AddContentPart<JobDescription>();
            services.AddContentPart<Language>();
            services.AddContentPart<Media>();
            services.AddContentPart<Recruitment>();
            services.AddContentPart<RecruitmentCheckList>();
            services.AddContentPart<RecruitmentCheckListTemplate>();
            services.AddContentPart<References>();
            services.AddContentPart<ReferenceCheck>();
            services.AddContentPart<Review>();
            services.AddContentPart<ReviewApproverHistory>();
            services.AddContentPart<Task>();
        }

        private void RegisterIndexProviders(IServiceCollection services)
        {
            services.AddSingleton<IIndexProvider, AssestIndexProvider>();
            services.AddSingleton<IIndexProvider, AssessmentCriteriaTemplateIndexProvider>();
            services.AddSingleton<IIndexProvider, CandidateIndexProvider>();
            services.AddSingleton<IIndexProvider, DepartmentIndexProvider>();
            services.AddSingleton<IIndexProvider, EmployeeIndexProvider>();
            services.AddSingleton<IIndexProvider, InterviewAssessmentIndexProvider>();
            services.AddSingleton<IIndexProvider, MediaIndexProvider>();
            services.AddSingleton<IIndexProvider, RecruitmentIndexProvider>();
            services.AddSingleton<IIndexProvider, RecruitmentCheckListTemplateIndexProvider>();
            services.AddSingleton<IIndexProvider, TaskIndexProvider>();
        }
    }
}