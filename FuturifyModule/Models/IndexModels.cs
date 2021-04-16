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
        public string Description { get; set; }
        public string EmployeeId { get; set; }
        public string DepartmentId { get; set; }
        public string PreviousAssignee { get; set; }
        public string CurrentAssignee { get; set; }
        public DateTime? ApproveDate { get; set; }
        public DateTime? RejectDate { get; set; }
        public string Comment { get; set; }
    }
}
