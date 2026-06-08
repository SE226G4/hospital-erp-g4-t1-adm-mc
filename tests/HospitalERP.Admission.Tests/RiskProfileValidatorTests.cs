using Xunit;
using System;

namespace HospitalERP.Admission.Tests
{
    public class RiskProfileValidatorTests
    {
        [Fact]
        public void VerifyRiskProfile_Should_SkipProfile_When_EmergencyFlow()
        {
            // 1. Arrange (التهيئة) 
            var validator = new RiskProfileManager();
            bool hasBloodType = false;
            bool hasAllergies = false;
            bool hasChronicDiseases = false;
            bool isEmergency = true;

            // 2. Act (التنفيذ)
            string result = validator.VerifyRiskProfile(hasBloodType, hasAllergies, hasChronicDiseases, isEmergency);

            // 3. Assert (التحقق) 
            Assert.Equal("Profile Skipped: Emergency Flow", result);
        }

        [Fact]
        public void VerifyRiskProfile_Should_Approve_When_ProfileIsComplete()
        {
            // Arrange 
            var validator = new RiskProfileManager();
            bool hasBloodType = true;
            bool hasAllergies = true;
            bool hasChronicDiseases = true;
            bool isEmergency = false;

            // Act
            string result = validator.VerifyRiskProfile(hasBloodType, hasAllergies, hasChronicDiseases, isEmergency);

            // Assert 
            Assert.Equal("Profile Complete: Ready for Admission", result);
        }

        [Fact]
        public void VerifyRiskProfile_Should_Reject_When_BloodTypeIsMissing()
        {
            // Arrange 
            var validator = new RiskProfileManager();
            bool hasBloodType = false; 
            bool hasAllergies = true;
            bool hasChronicDiseases = true;
            bool isEmergency = false;

            // Act
            string result = validator.VerifyRiskProfile(hasBloodType, hasAllergies, hasChronicDiseases, isEmergency);

            // Assert 
            Assert.Equal("Profile Incomplete: Missing Blood Type", result);
        }

        [Fact]
        public void VerifyRiskProfile_Should_Reject_When_AllergiesAreMissing()
        {
            // Arrange 
            var validator = new RiskProfileManager();
            bool hasBloodType = true;
            bool hasAllergies = false; 
            bool hasChronicDiseases = true;
            bool isEmergency = false;

            // Act
            string result = validator.VerifyRiskProfile(hasBloodType, hasAllergies, hasChronicDiseases, isEmergency);

            // Assert 
            Assert.Equal("Profile Incomplete: Missing Allergies or Chronic Diseases", result);
        }

        [Fact]
        public void VerifyRiskProfile_Should_Reject_When_ChronicDiseasesAreMissing()
        {
            // Arrange 
            var validator = new RiskProfileManager();
            bool hasBloodType = true;
            bool hasAllergies = true;
            bool hasChronicDiseases = false; 
            bool isEmergency = false;

            // Act
            string result = validator.VerifyRiskProfile(hasBloodType, hasAllergies, hasChronicDiseases, isEmergency);

            // Assert
            Assert.Equal("Profile Incomplete: Missing Allergies or Chronic Diseases", result);
        }
    }
}
