using FuturifyModule.Models;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;
using YesSql.Indexes;

namespace FuturifyModule.Indexes
{
    public class AssestIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<AssestIndex>().Map(contentItem =>
            {

                var assestPartContent = contentItem.As<Assest>();

                return assestPartContent == null ? null : new AssestIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    Name = assestPartContent.Name.Text,

                };
            });
        }
    }

    public class AssessmentCriteriaTemplateIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<AssessmentCriteriaTemplateIndex>().Map(contentItem =>
            {

                var assessmentcriteriatemplatePartContent = contentItem.As<AssessmentCriteriaTemplate>();

                return assessmentcriteriatemplatePartContent == null ? null : new AssessmentCriteriaTemplateIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    Name = assessmentcriteriatemplatePartContent.Name.Text,

                    MaxPoint = (int)assessmentcriteriatemplatePartContent.MaxPoint.Value.Value,

                };
            });
        }
    }

    public class CandidateIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<CandidateIndex>().Map(contentItem =>
            {

                var candidatePartContent = contentItem.As<Candidate>();

                return candidatePartContent == null ? null : new CandidateIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    Status = (int)candidatePartContent.Status.Value.Value,

                    ApplyDate = candidatePartContent.ApplyDate.Value.Value,

                    AvailableDate = candidatePartContent.AvailableDate.Value.Value,

                    FullName = candidatePartContent.FullName.Text,

                    Sex = (int)candidatePartContent.Sex.Value.Value,

                    Dob = candidatePartContent.Dob.Value.Value,

                    PlaceOfBirth = candidatePartContent.PlaceOfBirth.Text,

                    Nationality = candidatePartContent.Nationality.Text,

                    Ethnic = candidatePartContent.Ethnic.Text,

                    Religion = candidatePartContent.Religion.Text,

                    MaritalStatus = (int)candidatePartContent.MaritalStatus.Value.Value,

                    PermanentAddress = candidatePartContent.PermanentAddress.Text,

                    PresentAddress = candidatePartContent.PresentAddress.Text,

                    PhoneNumber = candidatePartContent.PhoneNumber.Text,

                    Email = candidatePartContent.Email.Text,

                    IDNo = candidatePartContent.IDNo.Text,

                    DateOfIssue = candidatePartContent.DateOfIssue.Value.Value,

                    PlaceOfIssue = candidatePartContent.PlaceOfIssue.Text,

                    AreYouWillingToGoOnBusinessTrips = candidatePartContent.AreYouWillingToGoOnBusinessTrips.Text,

                    ListExtraCurriculaAcivities = candidatePartContent.ListExtraCurriculaAcivities.Text,

                    HaveYouEverCommittedToAnyDisciplinaryAction = candidatePartContent.HaveYouEverCommittedToAnyDisciplinaryAction.Text,

                    HasCriminalRecord = candidatePartContent.HasCriminalRecord.Text,

                    CandidateInterviewAssessment = string.Join(".", candidatePartContent.CandidateInterviewAssessment.ContentItemIds),

                };
            });
        }
    }

    public class DepartmentIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<DepartmentIndex>().Map(contentItem =>
            {

                var departmentPartContent = contentItem.As<Department>();

                return departmentPartContent == null ? null : new DepartmentIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    Name = departmentPartContent.Name.Text,

                };
            });
        }
    }

    public class EmployeeIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<EmployeeIndex>().Map(contentItem =>
            {

                var employeePartContent = contentItem.As<Employee>();

                return employeePartContent == null ? null : new EmployeeIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    AccountId = employeePartContent.AccountId.ContentItemIds[0],

                    DepartmentId = employeePartContent.DepartmentId.ContentItemIds[0],

                    Assests = string.Join(".", employeePartContent.Assests.ContentItemIds),

                };
            });
        }
    }

    public class InterviewAssessmentIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<InterviewAssessmentIndex>().Map(contentItem =>
            {

                var interviewassessmentPartContent = contentItem.As<InterviewAssessment>();

                return interviewassessmentPartContent == null ? null : new InterviewAssessmentIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    RecruitmentId = interviewassessmentPartContent.RecruitmentId.ContentItemIds[0],

                    InterviewerId = interviewassessmentPartContent.InterviewerId.ContentItemIds[0],

                    Comment = interviewassessmentPartContent.Comment.Text,

                    IsPass = (int)interviewassessmentPartContent.IsPass.Value.Value,

                };
            });
        }
    }

    public class MediaIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<MediaIndex>().Map(contentItem =>
            {

                var mediaPartContent = contentItem.As<Media>();

                return mediaPartContent == null ? null : new MediaIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    Name = mediaPartContent.Name.Text,

                    Path = mediaPartContent.Path.Text,

                    Type = (int)mediaPartContent.Type.Value.Value,

                };
            });
        }
    }

    public class RecruitmentIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<RecruitmentIndex>().Map(contentItem =>
            {

                var recruitmentPartContent = contentItem.As<Recruitment>();

                return recruitmentPartContent == null ? null : new RecruitmentIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    Position = recruitmentPartContent.Position.Text,

                    Reason = recruitmentPartContent.Reason.Text,

                    SalaryMin = (int)recruitmentPartContent.SalaryMin.Value.Value,

                    SalaryMax = (int)recruitmentPartContent.SalaryMax.Value.Value,

                    DueDate = recruitmentPartContent.DueDate.Value.Value,

                    MediaId = recruitmentPartContent.MediaId.ContentItemIds[0],

                    DepartmentId = recruitmentPartContent.DepartmentId.ContentItemIds[0],

                    ReviewId = recruitmentPartContent.ReviewId.ContentItemIds[0],

                    ChecklistReferenceId = recruitmentPartContent.ChecklistReferenceId.ContentItemIds[0],

                    JobDescriptionReferenceId = recruitmentPartContent.JobDescriptionReferenceId.ContentItemIds[0],

                    WritingTest = string.Join(".", recruitmentPartContent.WritingTest.ContentItemIds),

                    RecruitmentCandidate = string.Join(".", recruitmentPartContent.RecruitmentCandidate.ContentItemIds),

                    RecruitmentBudgetLineId = recruitmentPartContent.RecruitmentBudgetLineId.ContentItemIds[0],

                    RecruitmentTask = string.Join(".", recruitmentPartContent.RecruitmentTask.ContentItemIds),

                };
            });
        }
    }

    public class RecruitmentCheckListTemplateIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<RecruitmentCheckListTemplateIndex>().Map(contentItem =>
            {

                var recruitmentchecklisttemplatePartContent = contentItem.As<RecruitmentCheckListTemplate>();

                return recruitmentchecklisttemplatePartContent == null ? null : new RecruitmentCheckListTemplateIndex
                {
                    ContentItemId = contentItem.ContentItemId,

                    Name = recruitmentchecklisttemplatePartContent.Name.Text,

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

                    Status = (int)taskPartContent.Status.Value.Value,

                    Assignee = taskPartContent.Assignee.ContentItemIds[0],

                    RelatedContentItemId = taskPartContent.RelatedContentItemId.ContentItemIds[0],

                    RelatedContentType = taskPartContent.RelatedContentType.Text,

                };
            });
        }
    }
}
