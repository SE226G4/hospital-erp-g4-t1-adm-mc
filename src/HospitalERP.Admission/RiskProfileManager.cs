using System;

namespace HospitalERP.Admission
{
/*     
// تابع التحقق من اكتمال ملف المخاطر ذو تعقيد حلقي مرتفع

public class RiskProfileManager
{
        public string VerifyRiskProfile(bool hasBloodType, bool hasAllergies, bool hasChronicDiseases, bool isEmergency)
        {
            if (isEmergency) 
            {
                return "Profile Skipped: Emergency Flow"; // يسمح بتجاوز الفحص لإنقاذ حياة المريض في الحالات الحرجة .
            }
            else
            {
                if (hasBloodType) 
                {
                    if (hasAllergies && hasChronicDiseases) 
                    {
                        return "Profile Complete: Ready for Admission"; // يؤكد اكتمال البيانات الحيوية المطلوبة للأقسام الأخرى .
                    }
                    else
                    {
                        return "Profile Incomplete: Missing Allergies or Chronic Diseases"; //ينبه لنقص التاريخ المرضي لضمان سلامة صرف الدواء 
                    }
                }
                else
                {
                    return "Profile Incomplete: Missing Blood Type"; // يمنع القبول العادي لغياب فصيلة الدم 
                }
            }
        }
}

 */


    public class RiskProfileManager
    {
        //  التابع الرئيسي بعد إعادة الهيكلية - تعقيد حلقي منخفض

        public string VerifyRiskProfile(bool hasBloodType, bool hasAllergies, bool hasChronicDiseases, bool isEmergency)
        {
            if (isEmergency)
            {
                return HandleEmergencyFlow();
            }

            return ValidateStandardProfile(hasBloodType, hasAllergies, hasChronicDiseases);
        }

        // تابع فرعي لمعالجة مسار الطوارئ
        private string HandleEmergencyFlow()
        {
            return "Profile Skipped: Emergency Flow";
        }

        // تابع فرعي للتحقق من تكامل البيانات الصحية 
        private string ValidateStandardProfile(bool hasBloodType, bool hasAllergies, bool hasChronicDiseases)
        {
            if (!hasBloodType)
            {
                return "Profile Incomplete: Missing Blood Type";
            }

            if (hasAllergies && hasChronicDiseases)
            {
                return "Profile Complete: Ready for Admission";
            }

            return "Profile Incomplete: Missing Allergies or Chronic Diseases";
        }
    }
}





public class RiskProfileManager
{
        public string VerifyRiskProfile(bool hasBloodType, bool hasAllergies, bool hasChronicDiseases, bool isEmergency)
        {
            if (isEmergency) 
            {
                return "Profile Skipped: Emergency Flow"; // يسمح بتجاوز الفحص لإنقاذ حياة المريض في الحالات الحرجة .
            }
            else
            {
                if (hasBloodType) 
                {
                    if (hasAllergies && hasChronicDiseases) 
                    {
                        return "Profile Complete: Ready for Admission"; // يؤكد اكتمال البيانات الحيوية المطلوبة للأقسام الأخرى .
                    }
                    else
                    {
                        return "Profile Incomplete: Missing Allergies or Chronic Diseases"; //ينبه لنقص التاريخ المرضي لضمان سلامة صرف الدواء 
                    }
                }
                else
                {
                    return "Profile Incomplete: Missing Blood Type"; // يمنع القبول العادي لغياب فصيلة الدم 
                }
            }
        }
}
