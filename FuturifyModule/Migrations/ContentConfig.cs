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
                #region RecruitmentRequest
                new ContentTypeDefinition
                {
                    Name = "RecruitmentRequest",
                    DefaultContentPart =  new ContentPartDefinition
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
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            }
                    },
                },
                #endregion

                #region RecruitmentProcedureCheckList
                new ContentTypeDefinition
                {
                    Name = "RecruitmentProcedureCheckList",
                    DefaultContentPart = new ContentPartDefinition
                    {
                        Name = "RecruitmentProcedureCheckList",
                        ContentFields = new List<ContentFieldDefinition> {
                            new ContentFieldDefinition
                                {
                                    Name = "RecruitmentId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "RecruitmentId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            new ContentFieldDefinition
                                {
                                    Name = "PreparedById",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "PreparedById",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            new ContentFieldDefinition
                                {
                                    Name = "ReviewedById",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "ReviewedById",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            new ContentFieldDefinition
                                {
                                    Name = "ApprovedById",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "ApprovedById",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                        }
                    },
                },
                #endregion

                #region RecruitmentCheckList
                new ContentTypeDefinition
                {
                    Name = "RecruitmentCheckList",
                    DefaultContentPart = new ContentPartDefinition
                    {
                            Name = "RecruitmentCheckList",
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
                                    Name = "Availability",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Availability",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Detail",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Detail",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Remark",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Remark",
                                    Settings = new TextFieldSettings{ Required = true }
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
                                    Name = "ApplyLink",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Apply Link",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "RecruitmentRequestId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "Recruitment Request Id",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "JobDescription",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Job Description",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "SkillAndExperience",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Skill And Experience",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Skills",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Skills",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "WhyYouLoveWorkingHere",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Why You Love Working Here",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "Location",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Location",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "QuestionForCandidate",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Question For Candidate",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "EmailForApplications",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "Email For Applications",
                                    Settings = new TextFieldSettings{ Required = true }
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
                                    Name = "EmployeeId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "EmployeeId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "FamilyId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "FamilyId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            }
                    },
                },
                #endregion

                #region Family
                new ContentTypeDefinition
                {
                    Name = "Family",
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

                #region Education
                new ContentTypeDefinition
                {
                    Name = "Education",
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
                                new ContentFieldDefinition
                                {
                                    Name = "CandidateId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "CandidateId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            }
                        },
                },
                #endregion

                #region Language
                new ContentTypeDefinition
                {
                    Name = "Language",
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
                                new ContentFieldDefinition
                                {
                                    Name = "Candidate",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "Candidate",
                                    Settings = new ContentPickerFieldSettings{ Required = true }
                                },
                            }
                        },
                },
                #endregion

                #region ComputerProficiency
                new ContentTypeDefinition
                {
                    Name = "ComputerProficiency",
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
                                new ContentFieldDefinition
                                {
                                    Name = "CandidateId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "CandidateId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            }
                        },
                },
                #endregion

                #region EmploymentRecord
                new ContentTypeDefinition
                {
                    Name = "EmploymentRecord",
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
                                    DisplayName = "CandidateId",
                                    Settings = new TextFieldSettings{ Required = true }
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
                                new ContentFieldDefinition
                                {
                                    Name = "CandidateId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "CandidateId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            }
                        },
                },
                #endregion

                #region References
                new ContentTypeDefinition
                {
                    Name = "References",
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
                                    Name = "CandidateId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "CandidateId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            }
                        },
                },
                #endregion

                #region ReferenceCheck
                new ContentTypeDefinition
                {
                    Name = "ReferenceCheck",
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
                                new ContentFieldDefinition
                                {
                                    Name = "CandidateId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "Candidate Id",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            }
                        },
                },
                #endregion

                #region Contract
                new ContentTypeDefinition
                {
                    Name = "Contract",
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "Contract",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Type",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Type",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "FileUrl",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Position",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "EmployeeId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "EmployeeId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "TORId",
                                     Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "TORId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "ContractTemplateId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "ContractTemplateId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            }
                        },
                },
                #endregion

                #region ContractTemplate
                new ContentTypeDefinition
                {
                    Name = "ContractTemplate",
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "ContractTemplate",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "FileUrl",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "FileUrl",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "MetadataKeyValue",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Metadata-key-value",
                                    Settings = new NumericFieldSettings{ Required = true }
                                },
                            }
                        },
                },
                #endregion

                #region Event
                new ContentTypeDefinition
                {
                    Name = "Event",
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "Event",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "Type",
                                    Type = ContentFieldTypes.NumericField,
                                    DisplayName = "Type",
                                    Settings = new NumericFieldSettings{ Required = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "RecruitmentId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "Recruitment Id",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "CandidateId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "Candidate Id",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            }
                        },
                },
                #endregion

                #region Room
                new ContentTypeDefinition
                {
                    Name = "Room",
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "Room",
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
                                    Name = "EventId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "Event Id",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                            }
                        },
                },
                #endregion

                #region Associate
                new ContentTypeDefinition
                {
                    Name = "Associate",
                    DefaultContentPart = new ContentPartDefinition
                        {
                            Name = "Associate",
                            ContentFields = new List<ContentFieldDefinition> {
                                new ContentFieldDefinition
                                {
                                    Name = "EmployeeId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "EmployeeId",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "RecruitmentId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "Recruitment Id",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "EventId",
                                    Type = ContentFieldTypes.ContentPickerField,
                                    DisplayName = "Event Id",
                                    Settings = new ContentPickerFieldSettings{ Required = true, Multiple = false }
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
                                    Name = "ParentContentItemId",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "ParentContentItemId",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                                new ContentFieldDefinition
                                {
                                    Name = "ParentContentType",
                                    Type = ContentFieldTypes.TextField,
                                    DisplayName = "ParentContentType",
                                    Settings = new TextFieldSettings{ Required = true }
                                },
                            }
                        },
                },
                #endregion
            };

            ContentParts = new List<ContentPartDefinition>
            {
                 new ContentPartDefinition
                 {
                        Name = "Workflow",
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
                 }
            };

            ContentPartRegisters = new List<ContentPartRegisterModel>
            {
               new ContentPartRegisterModel("RecruitmentRequest", "Workflow"),
            };
        }

        public static IEnumerable<ContentTypeDefinition> ContentTypes { get; }

        public static IEnumerable<ContentPartDefinition> ContentParts { get; }

        public static IEnumerable<ContentPartRegisterModel> ContentPartRegisters { get; }
    }
}
