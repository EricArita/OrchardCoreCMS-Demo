using System.Collections.Generic;
using System.Linq;
using AAVModule.Constants;
using AAVModule.Models;
using OrchardCore.ContentFields.Settings;

namespace AAVModule.Migrations
{
    public static class ContentConfig
    {
        static ContentConfig()
        {
            ContentTypesNeedsWorkflowPart = new List<string>
            {
                "RecruitmentRequest",
            };
            ContentTypes = new List<ContentTypeDefinition>
            {
                #region RecruitmentRequest
                new ContentTypeDefinition
                {
                    Name = "RecruitmentRequest",
                    ContentParts = new List<ContentPartDefinition>
                    {
                        new ContentPartDefinition
                        {
                            Name = "RecruitmentRequest",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Position",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Position",
                                    Settings = null
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Description",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Description",
                                    Settings = null
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "EmployeeId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "EmployeeId",
                                    Settings = new ContentPickerFieldSettings { Required = true, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "DepartmentId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "DepartmentId",
                                    Settings = new ContentPickerFieldSettings { Required = true, Multiple = false }
                                },
                            }
                        },
                    }
                },
                
                #endregion

                #region Task
                new ContentTypeDefinition
                {
                    Name = "Task",
                    ContentParts = new List<ContentPartDefinition>
                    {
                        new ContentPartDefinition
                        {
                            Name = "Task",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Title",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Title",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Description",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Description",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Assignee",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "Assignee",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "ContentItemId",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "ContentItemId",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "ContentType",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "ContentType",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                            }
                        },
                    }
                },
                #endregion
            };
            ContentTypes = AddWorkflowPart();
        }

        public static List<ContentTypeDefinition> ContentTypes { get; set; }

        public static List<string> ContentTypesNeedsWorkflowPart { get; set; }

        public static ContentPartDefinition WorkflowPart
        {
            get
            {
                return new ContentPartDefinition
                {
                    Name = "WorkflowPart",
                    ContentFields = new List<ContentFieldDefinition>
                    {
                        new ContentFieldDefinition
                        {
                            Name = "PreviousAssignee",
                            Type = ContentFieldTypes.ContentPickerField,
                            DisplayName = "Previous Assignee",
                            Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false}
                        },
                        new ContentFieldDefinition
                        {
                            Name = "CurrentAssignee",
                            Type = ContentFieldTypes.ContentPickerField,
                            DisplayName = "Current Assignee",
                            Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false}
                        },
                        new ContentFieldDefinition
                        {
                            Name = "ApproveDate",
                            Type = ContentFieldTypes.DateField,
                            DisplayName = "Approve Date",
                            Settings = new DateFieldSettings{ Required = false }
                        },
                        new ContentFieldDefinition
                        {
                            Name = "RejectDate",
                            Type = ContentFieldTypes.DateField,
                            DisplayName = "Reject Date",
                            Settings = new DateFieldSettings{ Required = false }
                        },
                        new ContentFieldDefinition
                        {
                            Name = "Comment",
                            Type = ContentFieldTypes.TextField,
                            DisplayName = "Comment",
                            Settings = new TextFieldSettings{ Required = false }
                        },
                    },
                };
            }
        }

        private static List<ContentTypeDefinition> AddWorkflowPart()
        {
            var contentTypes = ContentTypes;
            foreach (var contentType in contentTypes)
            {
                if (ContentTypesNeedsWorkflowPart.Contains(contentType.Name))
                {
                    contentType.ContentParts.Add(WorkflowPart);
                }
            }

            return contentTypes;
        }
    }
}
