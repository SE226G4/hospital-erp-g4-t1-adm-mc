using Xunit;
using HospitalERP.Admission;

namespace HospitalERP.Admission.Tests
{
    public class MedicalCodingManagerTests
    {
        [Fact]
        public void SyncMedicalCoding_MissingData_ReturnsFailed()
        {
            // Arrange
            var manager = new MedicalCodingManager();
            string admissionId = "";
            string icd10Code = "A09";

            // Act
            var result = manager.SyncMedicalCoding(admissionId, icd10Code, false, false, false);

            // Assert
            Assert.Equal("Failed: Missing Data", result);
        }

        [Fact]
        public void SyncMedicalCoding_DischargedWithPreviousCode_ReturnsFailed()
        {
            // Arrange
            var manager = new MedicalCodingManager();
            
            // Act
            var result = manager.SyncMedicalCoding("ADM123", "J01.90", true, true, false);

            // Assert
            Assert.Equal("Failed: Patient Discharged and Code Exists", result);
        }

        [Fact]
        public void SyncMedicalCoding_ActiveWithChronicDisease_ReturnsSuccess()
        {
            // Arrange
            var manager = new MedicalCodingManager();
            
            // Act
            var result = manager.SyncMedicalCoding("ADM123", "E11.9", false, false, true);

            // Assert
            Assert.Equal("Success: Chronic Disease Registered", result);
        }
    }
}

