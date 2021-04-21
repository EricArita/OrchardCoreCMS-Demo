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

                var recruitmentrequestPartContent = contentItem.As<RecruitmentRequest>();

                var workflowPartContent = contentItem.As<WorkflowPart>();

                return recruitmentrequestPartContent == null || workflowPartContent == null ? null : new RecruitmentRequestIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    Position = recruitmentrequestPartContent.Position.Text,

                    EmployeeId = recruitmentrequestPartContent.EmployeeId.ContentItemIds[0],

                    DepartmentId = recruitmentrequestPartContent.DepartmentId.ContentItemIds[0],

                    PreviousAssignee = workflowPartContent.PreviousAssignee.ContentItemIds[0],

                    CurrentAssignee = workflowPartContent.CurrentAssignee.ContentItemIds[0],

                    ApproveDate = workflowPartContent.ApproveDate.Value.Value,

                    RejectDate = workflowPartContent.RejectDate.Value.Value,

                    Comment = workflowPartContent.Comment.Text,

                };
            });
        }
    }

    public class TaskIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<TaskIndex>().Map(contentItem =>
            {

                var taskPartContent = contentItem.As<Task>();

                return taskPartContent == null ? null : new TaskIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    Title = taskPartContent.Title.Text,

                    Assignee = taskPartContent.Assignee.ContentItemIds[0],

                    ParentContentItemId = taskPartContent.ParentContentItemId.Text,

                    ParentContentType = taskPartContent.ParentContentType.Text,

                };
            });
        }
    }

    public class ProductIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<ProductIndex>().Map(contentItem =>
            {

                var productPartContent = contentItem.As<Product>();

                return productPartContent == null ? null : new ProductIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    Name = productPartContent.Name.Text,

                    CategoryId = productPartContent.CategoryId.ContentItemIds[0],
                };
            });
        }
    }
}
