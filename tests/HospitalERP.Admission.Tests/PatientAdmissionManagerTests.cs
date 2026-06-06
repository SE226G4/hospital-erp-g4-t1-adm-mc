using Xunit;
using System;


namespace HospitalERP.Admission.Tests
{
    public class PatientAdmissionManagerTests
    {
        [Fact]
        public void EvaluateAdmission_Should_CreateTemporaryID_When_EmergencyAndNoNationalID()
        {
            // 1. Arrange (التهيئة)
            var manager = new PatientAdmissionManager();
            string nationalId = null;
            bool hasPriorRecord = false;
            bool isRiskProfileComplete = false;
            bool isEmergency = true;
            int age = 25;

            // 2. Act (التنفيذ)
            string result = manager.EvaluateAdmissionEligibility(nationalId, hasPriorRecord, isRiskProfileComplete, isEmergency, age);

            // 3. Assert (التحقق)
            Assert.Equal("Create Temporary ID", result);
        }

        [Fact]
        public void EvaluateAdmission_Should_Reject_When_StandardFlowAndDuplicateRecord()
        {
            // Arrange
            var manager = new PatientAdmissionManager();
            string nationalId = "02010045568";
            bool hasPriorRecord = true;
            bool isRiskProfileComplete = true;
            bool isEmergency = false;
            int age = 30;

            // Act
            string result = manager.EvaluateAdmissionEligibility(nationalId, hasPriorRecord, isRiskProfileComplete, isEmergency, age);

            // Assert
            Assert.Equal("Rejected: Duplicate Record Exist", result);
        }

        [Fact]
        public void EvaluateAdmission_Should_Reject_When_StandardFlowAndIncompleteRiskProfile()
        {
            // Arrange
            var manager = new PatientAdmissionManager();
            string nationalId = "02010045568";
            bool hasPriorRecord = false;
            bool isRiskProfileComplete = false; // غير مكتمل
            bool isEmergency = false;
            int age = 45;

            // Act
            string result = manager.EvaluateAdmissionEligibility(nationalId, hasPriorRecord, isRiskProfileComplete, isEmergency, age);

            // Assert
            Assert.Equal("Rejected: Incomplete Risk Profile", result);
        }

        [Fact]
        public void EvaluateAdmission_Should_ApprovePediatric_When_ValidDataAndAgeUnder18()
        {
            // Arrange
            var manager = new PatientAdmissionManager();
            string nationalId = "02010099887";
            bool hasPriorRecord = false;
            bool isRiskProfileComplete = true;
            bool isEmergency = false;
            int age = 12; // طفل

            // Act
            string result = manager.EvaluateAdmissionEligibility(nationalId, hasPriorRecord, isRiskProfileComplete, isEmergency, age);

            // Assert
            Assert.Equal("Approved: Pediatric Admission", result);
        }
    }
}