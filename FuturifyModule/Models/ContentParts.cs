using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuturifyModule.Models
{
    public class Assest : ContentPart
    {
        public TextField Name { get; set; }
    }

    public class AssessmentCriteria : ContentPart
    {
        public TextField Note { get; set; }
        public NumericField Point { get; set; }
        public ContentPickerField AssessmentCriteriaTemplate { get; set; }
    }

    public class AssessmentCriteriaTemplate : ContentPart
    {
        public TextField Name { get; set; }
        public NumericField MaxPoint { get; set; }
    }

    public class Candidate : ContentPart
    {
        public NumericField Status { get; set; }
        public DateField ApplyDate { get; set; }
        public DateField AvailableDate { get; set; }
        public TextField FullName { get; set; }
        public NumericField Sex { get; set; }
        public DateField Dob { get; set; }
        public TextField PlaceOfBirth { get; set; }
        public TextField Nationality { get; set; }
        public TextField Ethnic { get; set; }
        public TextField Religion { get; set; }
        public NumericField MaritalStatus { get; set; }
        public TextField PermanentAddress { get; set; }
        public TextField PresentAddress { get; set; }
        public TextField PhoneNumber { get; set; }
        public TextField Email { get; set; }
        public TextField IDNo { get; set; }
        public DateField DateOfIssue { get; set; }
        public TextField PlaceOfIssue { get; set; }
        public TextField AreYouWillingToGoOnBusinessTrips { get; set; }
        public TextField ListExtraCurriculaAcivities { get; set; }
        public TextField HaveYouEverCommittedToAnyDisciplinaryAction { get; set; }
        public TextField HasCriminalRecord { get; set; }
        public ContentPickerField CandidateInterviewAssessment { get; set; }
    }

    public class ComputerProficiency : ContentPart
    {
        public TextField SoftwareName { get; set; }
        public NumericField Rate { get; set; }
    }

    public class Comment : ContentPart
    {
        public TextField Content { get; set; }
    }

    public class Department : ContentPart
    {
        public TextField Name { get; set; }
    }

    public class Education : ContentPart
    {
        public TextField MainCourseOfStudy { get; set; }
        public DateField AttendedFrom { get; set; }
        public DateField AttendedTo { get; set; }
        public TextField University { get; set; }
        public TextField Place { get; set; }
    }

    public class Employee : ContentPart
    {
        public ContentPickerField AccountId { get; set; }
        public ContentPickerField DepartmentId { get; set; }
        public ContentPickerField Assests { get; set; }
    }

    public class EmploymentRecord : ContentPart
    {
        public TextField Company { get; set; }
        public TextField Position { get; set; }
        public TextField TypeOfBusiness { get; set; }
        public NumericField Salary { get; set; }
        public TextField Description { get; set; }
        public DateField From { get; set; }
        public DateField To { get; set; }
    }

    public class Family : ContentPart
    {
        public TextField Name { get; set; }
        public TextField Occupation { get; set; }
        public DateField DateOfBirth { get; set; }
        public NumericField Relationship { get; set; }
        public NumericField Dependant { get; set; }
    }

    public class InterviewAssessment : ContentPart
    {
        public ContentPickerField RecruitmentId { get; set; }
        public ContentPickerField InterviewerId { get; set; }
        public TextField Comment { get; set; }
        public NumericField IsPass { get; set; }
    }

    public class JobDescription : ContentPart
    {
        public TextField Content { get; set; }
        public NumericField IsApprove { get; set; }
    }

    public class Language : ContentPart
    {
        public TextField Name { get; set; }
        public NumericField Reading { get; set; }
        public NumericField Writing { get; set; }
        public NumericField Listening { get; set; }
        public NumericField Speaking { get; set; }
    }

    public class Media : ContentPart
    {
        public TextField Name { get; set; }
        public TextField Path { get; set; }
        public NumericField Type { get; set; }
    }

    public class Recruitment : ContentPart
    {
        public TextField Position { get; set; }
        public TextField Reason { get; set; }
        public NumericField SalaryMin { get; set; }
        public NumericField SalaryMax { get; set; }
        public DateField DueDate { get; set; }
        public ContentPickerField MediaId { get; set; }
        public ContentPickerField DepartmentId { get; set; }
        public ContentPickerField ReviewId { get; set; }
        public ContentPickerField ChecklistReferenceId { get; set; }
        public ContentPickerField JobDescriptionReferenceId { get; set; }
        public ContentPickerField WritingTest { get; set; }
        public ContentPickerField RecruitmentCandidate { get; set; }
        public ContentPickerField RecruitmentBudgetLineId { get; set; }
        public ContentPickerField RecruitmentTask { get; set; }
    }

    public class RecruitmentCheckList : ContentPart
    {
        public TextField Details { get; set; }
        public TextField Remark { get; set; }
        public ContentPickerField RecruitmentChecklistTemplate { get; set; }
    }

    public class RecruitmentCheckListTemplate : ContentPart
    {
        public TextField Name { get; set; }
    }

    public class References : ContentPart
    {
        public TextField Fullname { get; set; }
        public TextField Position { get; set; }
        public TextField PhoneNumber { get; set; }
        public TextField Email { get; set; }
        public BooleanField IsLineManager { get; set; }
    }

    public class ReferenceCheck : ContentPart
    {
        public TextField Referrer { get; set; }
        public TextField JobTitleOfReferrer { get; set; }
        public TextField HowLongWereHeLeftYourInstitution { get; set; }
        public TextField PositionAtTheTimeHeLeftInstitution { get; set; }
        public TextField ReasonGivenForLeaving { get; set; }
        public NumericField WorkingCapacity { get; set; }
        public TextField PleaseGiveSpecificEvidenceForYourStatements { get; set; }
        public TextField Strength { get; set; }
        public TextField Weakness { get; set; }
        public TextField Personality { get; set; }
        public TextField DidHeCommitToAnyDisciplinaryAction { get; set; }
        public TextField DidHeCommitToAnyAbuseOrSexualHarassmentAction { get; set; }
        public NumericField LevelOfProfessional { get; set; }
        public NumericField AbilityToWorkAsAPartTeam { get; set; }
        public NumericField AbilityToAdjustToNewTask { get; set; }
        public NumericField AbilityToAcceptPersonalResponsibility { get; set; }
        public NumericField AbilityToLeadAndMotivateOthers { get; set; }
        public NumericField AbilityToCommunicateEffectively { get; set; }
        public NumericField AbilityToNegotiateAndPersuade { get; set; }
        public NumericField CommitmentEnthusiasmAndPositiveAttitude { get; set; }
        public NumericField ResilienceAndDetermination { get; set; }
        public NumericField Reliability { get; set; }
        public NumericField WouldYouRehireHim { get; set; }
        public TextField PhoneNumber { get; set; }
        public TextField Email { get; set; }
    }

    public class Review : ContentPart
    {
        public NumericField Status { get; set; }
        public ContentPickerField InterviewAssessmentReview { get; set; }
    }

    public class ReviewApproverHistory : ContentPart
    {
        public NumericField Status { get; set; }
        public NumericField IsCurrent { get; set; }
        public ContentPickerField EmployeeReviewApproverHistory { get; set; }
    }

    public class Task : ContentPart
    {
        public NumericField Status { get; set; }
        public ContentPickerField Assignee { get; set; }
        public ContentPickerField RelatedContentItemId { get; set; }
        public TextField RelatedContentType { get; set; }
    }
}
