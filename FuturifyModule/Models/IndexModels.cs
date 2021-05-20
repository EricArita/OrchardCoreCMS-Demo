using System;
using System.Collections.Generic;
using System.Text;
using YesSql.Indexes;

namespace FuturifyModule.Models
{
    public class AssestIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string Name { get; set; }
    }

    public class AssessmentCriteriaTemplateIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string Name { get; set; }
        public int MaxPoint { get; set; }
    }

    public class CandidateIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public int Status { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime AvailableDate { get; set; }
        public string FullName { get; set; }
        public int Sex { get; set; }
        public DateTime Dob { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Ethnic { get; set; }
        public string Religion { get; set; }
        public int MaritalStatus { get; set; }
        public string PermanentAddress { get; set; }
        public string PresentAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string IDNo { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string AreYouWillingToGoOnBusinessTrips { get; set; }
        public string ListExtraCurriculaAcivities { get; set; }
        public string HaveYouEverCommittedToAnyDisciplinaryAction { get; set; }
        public string HasCriminalRecord { get; set; }
        public string CandidateInterviewAssessment { get; set; }
    }

    public class DepartmentIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string Name { get; set; }
    }

    public class EmployeeIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string AccountId { get; set; }
        public string DepartmentId { get; set; }
        public string Assests { get; set; }
    }

    public class InterviewAssessmentIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string RecruitmentId { get; set; }
        public string InterviewerId { get; set; }
        public string Comment { get; set; }
        public int IsPass { get; set; }
    }

    public class MediaIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int Type { get; set; }
    }

    public class RecruitmentIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string Position { get; set; }
        public string Reason { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public DateTime DueDate { get; set; }
        public string MediaId { get; set; }
        public string DepartmentId { get; set; }
        public string ReviewId { get; set; }
        public string ChecklistReferenceId { get; set; }
        public string JobDescriptionReferenceId { get; set; }
        public string WritingTest { get; set; }
        public string RecruitmentCandidate { get; set; }
        public string RecruitmentBudgetLineId { get; set; }
        public string RecruitmentTask { get; set; }
    }

    public class RecruitmentCheckListTemplateIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string Name { get; set; }
    }

    public class TaskIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public int Status { get; set; }
        public string Assignee { get; set; }
        public string RelatedContentItemId { get; set; }
        public string RelatedContentType { get; set; }
    }
}
