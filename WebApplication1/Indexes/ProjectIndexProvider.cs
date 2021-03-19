using YessqlApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using YesSql.Indexes;

namespace YessqlApi.Indexes
{
    public class ProjectIndexProvider : IndexProvider<ProjectModel>
    {
        public override void Describe(DescribeContext<ProjectModel> context)
        {
            context.For<ProjectIndex>().Map(project => new ProjectIndex { 
                Code = project.Code,
                Name = project.Name,
                IsDeleted = project.IsDeleted
            });
        }
    }

    public class ApiProjectIndexProvider : IndexProvider<ApiProjectModel>
    {
        public override void Describe(DescribeContext<ApiProjectModel> context)
        {
            context.For<ApiProjectIndex>().Map(project => new ApiProjectIndex
            {
                Name = project.Name,
                IsDeleted = project.IsDeleted,
                LeaderId = project.LeaderId
            });
        }
    }
}
