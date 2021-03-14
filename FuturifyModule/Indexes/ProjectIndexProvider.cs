using FuturifyModule.Models;
using System;
using System.Collections.Generic;
using System.Text;
using YesSql.Indexes;

namespace FuturifyModule.Indexes
{
    public class ProjectIndexProvider : IndexProvider<ProjectModel>
    {
        public override void Describe(DescribeContext<ProjectModel> context)
        {
            // for each BlogPost, create a BlogPostByAuthor index
            context.For<ProjectIndex>().Map(project => new ProjectIndex { 
                Code = project.Code,
                Name = project.Name,
                IsDeleted = project.IsDeleted
            });
        }
    }
}
