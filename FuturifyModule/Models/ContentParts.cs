using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuturifyModule.Models
{
    public class RecruitmentRequestPart : ContentPart
    {
        public TextField Position { get; set; }
        public TextField Description { get; set; }
        public ContentPickerField EmployeeId { get; set; }
        public ContentPickerField DepartmentId { get; set; }
    }

    public class TaskPart : ContentPart
    {
        public TextField Title { get; set; }
        public TextField Description { get; set; }
        public ContentPickerField Assignee { get; set; }
        public TextField ContentItemId { get; set; }
        public TextField ContentType { get; set; }
    }

    public class WorkflowPart : ContentPart
    {
        public ContentPickerField PreviousAssignee { get; set; }
        public ContentPickerField CurrentAssignee { get; set; }
        public DateField ApproveDate { get; set; }
        public DateField RejectDate { get; set; }
        public TextField Comment { get; set; }
    }
}
