using FuturifyModule.Models;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;
using YesSql.Indexes;

namespace FuturifyModule.Indexes
{
    public class RecruitmentRequestIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<RecruitmentRequestIndex>().Map(contentItem =>
            {
                var content = contentItem.As<RecruitmentRequestPart>();

                return content == null ? null : new RecruitmentRequestIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    Position = content.Position.Text,

                    Description = content.Description.Text,

                    EmployeeId = content.EmployeeId.ContentItemIds[0],

                    DepartmentId = content.DepartmentId.ContentItemIds[0],

                };
            });
        }
    }
}
