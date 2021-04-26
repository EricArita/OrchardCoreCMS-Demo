using System;
using System.Collections.Generic;
using System.Text;
using YesSql.Indexes;

namespace FuturifyModule.Models
{
    public class RecruitmentRequestIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string Position { get; set; }
        public string EmployeeId { get; set; }
        public string DepartmentId { get; set; }
        public string PreviousAssignee { get; set; }
        public string CurrentAssignee { get; set; }
        public DateTime ApproveDate { get; set; }
        public DateTime RejectDate { get; set; }
        public string Comment { get; set; }
    }

    public class TaskIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string Title { get; set; }
        public string Assignee { get; set; }
        public string ParentContentItemId { get; set; }
        public string ParentContentType { get; set; }
    }

    public class ProductIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
    }
    public class CategoryIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string Name { get; set; }
    }
}
