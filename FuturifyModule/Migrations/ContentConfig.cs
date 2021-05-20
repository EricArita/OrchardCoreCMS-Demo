using System.Collections.Generic;
using System.Linq;
using AAVModule.Constants;
using AAVModule.Models;
using FuturifyModule.Models;
using OrchardCore.ContentFields.Settings;

namespace AAVModule.Migrations
{
    public static class ContentConfig
    {
        static ContentConfig()
        {
            ContentTypes = new List<ContentTypeDefinition>
            {
                #region Assest
                new ContentTypeDefinition
                {
                    Name = "Assest",
                    DefaultContentPart = new ContentPartDefinition
                    {
                        Name = "Assest",
                        ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Name",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Content",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                        }
                    },
                },
                #endregion

                #region AssessmentCriteria
                new ContentTypeDefinition
                {
                    Name = "AssessmentCriteria",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "AssessmentCriteria",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Note",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Note",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Point",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Point",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "AssessmentCriteriaTemplate",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "AssessmentCriteriaTemplate",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = true, DisplayedContentTypes = new string[] { "AssessmentCriteriaTemplate" } }
                                },
                            }
                        },
                },
                #endregion

                #region AssessmentCriteriaTemplate
                new ContentTypeDefinition
                {
                    Name = "AssessmentCriteriaTemplate",
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "AssessmentCriteriaTemplate",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Name",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Name",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "MaxPoint",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "MaxPoint",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                            }
                        },
                },
                #endregion
            
                #region Candidate
                new ContentTypeDefinition
                {
                    Name = "Candidate",
                    DefaultContentPart = new ContentPartDefinition
                    {
                            Name = "Candidate",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Status",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Status",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "ApplyDate",
                                    Type = ContentFieldTypes.DateField,
                                    DisplayName = "Apply Date",
                                    Settings = new DateFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "AvailableDate",
                                    Type = ContentFieldTypes.DateField,
                                    DisplayName = "Available Date",
                                    Settings = new DateFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "FullName",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Full Name",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Sex",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Sex",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Dob",
                                    Type = ContentFieldTypes.DateField,
                                    DisplayName = "Date of Birthday",
                                    Settings = new DateFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "PlaceOfBirth",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Place Of Birth",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Nationality",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Nationality",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Ethnic",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Ethnic",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Religion",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Religion",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "MaritalStatus",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Marital Status",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "PermanentAddress",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Permanent Address",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "PresentAddress",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Present Address",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "PhoneNumber",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Phone Number",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Email",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Email",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "IDNo",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "IDNo",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "DateOfIssue",
                                    Type = ContentFieldTypes.DateField,
                                    DisplayName = "Date Of Issue",
                                    Settings = new DateFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "PlaceOfIssue",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Place Of Issue",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "AreYouWillingToGoOnBusinessTrips",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Are You Willing To Go On Business Trips",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "ListExtraCurriculaAcivities",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "List Extra Curricula Acivities",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "HaveYouEverCommittedToAnyDisciplinaryAction",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Have You Ever Committed To Any Disciplinary Action",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "HasCriminalRecord",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Has Criminal Record",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "CandidateInterviewAssessment",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "CandidateInterviewAssessment",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = true, DisplayedContentTypes = new string[] { "InterviewAssessment" } }
                                },
                            }
                    },
                },
                #endregion

                #region ComputerProficiency
                new ContentTypeDefinition
                {
                    Name = "ComputerProficiency",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "ComputerProficiency",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "SoftwareName",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Software Name",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Rate",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Rate",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                            }
                        },
                },
                #endregion            

                #region Comment
                new ContentTypeDefinition
                {
                    Name = "Comment",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                    {
                        Name = "Comment",
                        ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Content",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Content",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                        }
                    },
                },
                #endregion

                #region Department
                new ContentTypeDefinition
                {
                    Name = "Department",
                    DefaultContentPart = new ContentPartDefinition
                    {
                        Name = "Department",
                        ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Name",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Name",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                        }
                    },
                },
                #endregion

                #region Education
                new ContentTypeDefinition
                {
                    Name = "Education",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "Education",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "MainCourseOfStudy",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Main Course Of Study",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "AttendedFrom",
                                    Type = ContentFieldTypes.DateField,
                                    DisplayName = "Attended From",
                                    Settings = new DateFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "AttendedTo",
                                    Type = ContentFieldTypes.DateField,
                                    DisplayName = "Attended To",
                                    Settings = new DateFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "University",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "University",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Place",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Place",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                            }
                        },
                },
                #endregion

                #region Employee
                new ContentTypeDefinition
                {
                    Name = "Employee",
                    DefaultContentPart = new ContentPartDefinition
                    {
                        Name = "Employee",
                        ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "AccountId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "AccountId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "DepartmentId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "DepartmentId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false, DisplayedContentTypes = new string[] { "Department" } }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Assests",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "Assests",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = true, DisplayedContentTypes = new string[] { "Assest" } }
                                },
                        }
                    },
                },
                #endregion

                #region EmploymentRecord
                new ContentTypeDefinition
                {
                    Name = "EmploymentRecord",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                    {
                        Name = "EmploymentRecord",
                        ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Company",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Company",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Position",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Position",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "TypeOfBusiness",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "TypeOfBusiness",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Salary",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Salary",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Description",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Description",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "From",
                                    Type = ContentFieldTypes.DateField,
                                    DisplayName = "From",
                                    Settings = new DateFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "To",
                                    Type = ContentFieldTypes.DateField,
                                    DisplayName = "To",
                                    Settings = new DateFieldSettings{ Required = true }
                                },
                        }
                    },
                },
                #endregion

                #region Family
                new ContentTypeDefinition
                {
                    Name = "Family",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "Family",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Name",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Name",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Occupation",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Occupation",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "DateOfBirth",
                                    Type = ContentFieldTypes.DateField,
                                    DisplayName = "Date Of Birth",
                                    Settings = new DateFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Relationship",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Relationship",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Dependant",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Dependant",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                            }
                        },
                },
                #endregion

                #region InterviewAssessment
                new ContentTypeDefinition
                {
                    Name = "InterviewAssessment",
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "InterviewAssessment",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "RecruitmentId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "RecruitmentId",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = false, DisplayedContentTypes = new string[] { "Recruitment" } }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "InterviewerId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "InterviewerId",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Comment",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Comment",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "IsPass",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "IsPass",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                            }
                        },
                },
                #endregion

                #region JobDescription
                new ContentTypeDefinition
                {
                    Name = "JobDescription",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                    {
                        Name = "JobDescription",
                        ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Content",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Content",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "IsApprove",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "IsApprove",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                        }
                    },
                },
                #endregion

                #region Language
                new ContentTypeDefinition
                {
                    Name = "Language",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "Language",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Name",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Name",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Reading",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Reading",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Writing",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Writing",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Listening",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Listening",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Speaking",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Speaking",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                            }
                        },
                },
                #endregion

                #region Media
                new ContentTypeDefinition
                {
                    Name = "Media",
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "Media",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Name",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Name",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Path",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Path",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Type",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Type",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                            }
                        },
                },
                #endregion

                #region Recruitment
                new ContentTypeDefinition
                {
                    Name = "Recruitment",
                    DefaultContentPart = new ContentPartDefinition
                    {
                            Name = "Recruitment",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Position",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Position",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Reason",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Reason",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "SalaryMin",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "SalaryMin",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "SalaryMax",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "SalaryMax",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "DueDate",
                                    Type = ContentFieldTypes.DateField,
                                    DisplayName = "DueDate",
                                    Settings = new DateFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "MediaId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "MediaId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false, DisplayedContentTypes = new string[] { "Media" } }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "DepartmentId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "DepartmentId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "ReviewId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "ReviewId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "ChecklistReferenceId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "ChecklistReferenceId",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "JobDescriptionReferenceId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "JobDescriptionReferenceId",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "WritingTest",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "WritingTest",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = true, DisplayedContentTypes = new string[] { "Media" } }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "RecruitmentCandidate",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "RecruitmentCandidate",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = true, DisplayedContentTypes = new string[] { "Candidate" } }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "RecruitmentBudgetLineId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "RecruitmentBudgetLineId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false, DisplayedContentTypes = new string[] { "BudgetLine" } }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "RecruitmentTask",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "RecruitmentTask",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = true, DisplayedContentTypes = new string[] { "Task" } }
                                },
                            }
                    },
                },
                #endregion         

                #region RecruitmentCheckList
                new ContentTypeDefinition
                {
                    Name = "RecruitmentCheckList",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                    {
                            Name = "RecruitmentCheckList",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Details",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Details",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Remark",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Remark",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "RecruitmentChecklistTemplate",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "RecruitmentChecklistTemplate",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = true, DisplayedContentTypes = new string[] { "RecruitmentCheckListTemplate" }}
                                },
                            }
                    },

                },
                #endregion

                #region RecruitmentCheckListTemplate
                new ContentTypeDefinition
                {
                    Name = "RecruitmentCheckListTemplate",
                    DefaultContentPart = new ContentPartDefinition
                    {
                            Name = "RecruitmentCheckListTemplate",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Name",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Name",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                            }
                    },

                },
                #endregion

                #region References
                new ContentTypeDefinition
                {
                    Name = "References",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "References",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Fullname",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Fullname",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Position",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Position",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "PhoneNumber",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "PhoneNumber",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Email",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Email",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "IsLineManager",
                                    Type = ContentFieldTypes.BooleanField,
                                    DisplayName = "IsLineManager",
                                    Settings = new BooleanFieldSettings{ DefaultValue = false }
                                },
                            }
                        },
                },
                #endregion

                #region ReferenceCheck
                new ContentTypeDefinition
                {
                    Name = "ReferenceCheck",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "ReferenceCheck",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Referrer",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Referrer",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "JobTitleOfReferrer",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Job Title Of Referrer",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "HowLongWereHeLeftYourInstitution",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "How Long Were He Left Your Institution",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "PositionAtTheTimeHeLeftInstitution",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Position At The Time He Left Institution",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "ReasonGivenForLeaving",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Reason Given For Leaving",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "WorkingCapacity",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Working Capacity",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "PleaseGiveSpecificEvidenceForYourStatements",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Please Give Specific Evidence For Your Statements",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Strength",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Strength",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Weakness",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Weakness",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Personality",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Personality",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "DidHeCommitToAnyDisciplinaryAction",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Did HeCommit To Any Disciplinary Action",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "DidHeCommitToAnyAbuseOrSexualHarassmentAction",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Did He Commit To Any Abuse Or Sexual Harassment Action",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "LevelOfProfessional",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Level Of Professional",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "AbilityToWorkAsAPartTeam",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "AbilityToWorkAsAPartTeam",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "AbilityToAdjustToNewTask",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "AbilityToAdjustToNewTask",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "AbilityToAcceptPersonalResponsibility",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Ability To Accept Personal Responsibility",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "AbilityToLeadAndMotivateOthers",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Ability To Lead And Motivate Others",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "AbilityToCommunicateEffectively",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Ability To Communicate Effectively",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "AbilityToNegotiateAndPersuade",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Ability To Negotiate And Persuade",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "CommitmentEnthusiasmAndPositiveAttitude",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Commitment Enthusiasm And Positive Attitude",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "ResilienceAndDetermination",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Resilience And Determination",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Reliability",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Reliability",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "WouldYouRehireHim",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Would You Rehire Him",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "PhoneNumber",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Phone Number",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Email",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Email",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                            }
                        },
                },
                #endregion

                #region Review
                new ContentTypeDefinition
                {
                    Name = "Review",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "Review",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Status",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Status",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "InterviewAssessmentReview",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "InterviewAssessmentReview",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = true, DisplayedContentTypes = new string[] { "InterviewAssessment" } }
                                },
                            }
                        },
                },
                #endregion

                #region ReviewApproverHistory
                new ContentTypeDefinition
                {
                    Name = "ReviewApproverHistory",
                    InBagPart = true,
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "ReviewApproverHistory",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Status",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Status",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "IsCurrent",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "IsCurrent",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "EmployeeReviewApproverHistory",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "EmployeeReviewApproverHistory",
                                    Settings = new ContentPickerFieldSettings{ Required = false, Multiple = true, DisplayedContentTypes = new string[] { "Employee" } }
                                },
                            }
                        },
                },
                #endregion

                #region Task
                new ContentTypeDefinition
                {
                    Name = "Task",
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "Task",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Status",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Status",
                                    Settings = new NumericFieldSettings{ Required = true }
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
                                    Name = "RelatedContentItemId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "RelatedContentItemId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false, DisplayedContentTypes = new string[]{ "Task" } }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "RelatedContentType",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "RelatedContentType",
                                    Settings = new TextFieldSettings{ Required = false }
                                },
                            }
                        },
                },
                #endregion
            };

            ContentParts = new List<ContentPartDefinition>
            {               
            };

            ContentPartRegisters = new List<ContentPartRegisterModel>
            {
               new ContentPartRegisterModel("Candidate", "Bag"),
               new ContentPartRegisterModel("InterviewAssessment", "Bag"),
               new ContentPartRegisterModel("Recruitment", "Bag"),
               new ContentPartRegisterModel("Review", "Bag"),
            };
        }

        public static IEnumerable<ContentTypeDefinition> ContentTypes { get; }

        public static IEnumerable<ContentPartDefinition> ContentParts { get; }

        public static IEnumerable<ContentPartRegisterModel> ContentPartRegisters { get; }
    }
}
