using System;

namespace HospitalERP.Admission
/*الكود قبل Refactoring
{
    public class MedicalCodingManager
    {
        // تابع مزامنة الترميز الطبي - قبل إعادة الهيكلة (CC = 6)
        public string SyncMedicalCoding(string admissionId, string icd10Code, bool isPatientDischarged, bool hasPreviousCode, bool isChronicDisease)
        {
            // القرار 1 و 2 (if و ||)
            if (string.IsNullOrEmpty(admissionId) || string.IsNullOrEmpty(icd10Code))
            {
                return "Failed: Missing Data";
            }

            // القرار 3
            if (isPatientDischarged)
            {
                // القرار 4
                if (hasPreviousCode)
                {
                    return "Failed: Patient Discharged and Code Exists"; 
                }
                else
                {
                    return "Success: Late Coding Applied";
                }
            }
            else
            {
                // القرار 5
                if (hasPreviousCode)
                {
                    return "Updated: Previous Code Overwritten";
                }
                else
                {
                    // القرار 6
                    if (isChronicDisease)
                    {
                        return "Success: Chronic Disease Registered";
                    }
                    return "Success: Standard Coding Applied";
                }
            }
        }
    }
}
*/

//الكود بعد إعادة الهيكلة
{
    public class MedicalCodingManager
    {
        // التابع الرئيسي بعد إعادة الهيكلة - التعقيد الحلقي انخفض إلى (3)
        public string SyncMedicalCoding(string admissionId, string icd10Code, bool isPatientDischarged, bool hasPreviousCode, bool isChronicDisease)
        {
            if (string.IsNullOrEmpty(admissionId) || string.IsNullOrEmpty(icd10Code))
                return "Failed: Missing Data";

            if (isPatientDischarged)
                return HandleDischargedPatient(hasPreviousCode);

            return HandleActivePatient(hasPreviousCode, isChronicDisease);
        }

        // تابع فرعي 1 (CC = 2)
        private string HandleDischargedPatient(bool hasPreviousCode)
        {
            return hasPreviousCode ? "Failed: Patient Discharged and Code Exists" : "Success: Late Coding Applied";
        }

        // تابع فرعي 2 (CC = 3)
        private string HandleActivePatient(bool hasPreviousCode, bool isChronicDisease)
        {
            if (hasPreviousCode) 
                return "Updated: Previous Code Overwritten";
                
            return isChronicDisease ? "Success: Chronic Disease Registered" : "Success: Standard Coding Applied";
        }
    }
}

