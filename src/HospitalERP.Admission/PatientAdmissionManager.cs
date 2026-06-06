using System;

/*
    public class PatientAdmissionManager
    {
        // تابع تقييم حالة قبول المريض - ذو تعقيد حلقي مرتفع
        public string EvaluateAdmissionEligibility(string nationalId, bool hasPriorRecord, bool isRiskProfileComplete, bool isEmergency, int patientAge)
        {
            if (string.IsNullOrEmpty(nationalId))
            {
                if (isEmergency)
                {
                    return "Create Temporary ID"; // مسار الطوارئ عند غياب البيانات الرسمية
                }
                else
                {
                    return "Rejected: Missing National ID";
                }
            }

            if (hasPriorRecord)
            {
                if (isEmergency)
                {
                    return "Proceed to Emergency Ward"; // مريض مسجل سابقاً بحالة طارئة
                }
                else
                {
                    return "Rejected: Duplicate Record Exist"; // يمنع النظام إدخال مريض لديه سجل سابق
                }
            }
            else
            {
                if (isRiskProfileComplete)
                {
                    if (patientAge < 18)
                    {
                        return "Approved: Pediatric Admission";
                    }
                    else
                    {
                        return "Approved: Standard Admission";
                    }
                }
                else
                {
                    if (isEmergency)
                    {
                        return "Create Temporary ID"; // ملف طوارئ مؤقت لحين استكمال البيانات
                    }
                    else
                    {
                        return "Rejected: Incomplete Risk Profile"; // لا يسمح بالقبول دون ملف المخاطر في الحالات العادية
                    }
                }
            }
        }
    }
    
*/


    public class PatientAdmissionManager
    {
        // التابع الرئيسي بعد إعادة الهيكلة - تعقيد حلقي منخفض 
        public string EvaluateAdmissionEligibility(string nationalId, bool hasPriorRecord, bool isRiskProfileComplete, bool isEmergency, int patientAge)
        {
            if (isEmergency)
            {
                return HandleEmergencyFlow(nationalId, hasPriorRecord);
            }

            return HandleStandardFlow(nationalId, hasPriorRecord, isRiskProfileComplete, patientAge);
        }

        // تابع فرعي لمعالجة مسار الطوارئ
        private string HandleEmergencyFlow(string nationalId, bool hasPriorRecord)
        {
            if (string.IsNullOrEmpty(nationalId) || !hasPriorRecord)
            {
                return "Create Temporary ID";
            }
            return "Proceed to Emergency Ward";
        }

        // تابع فرعي لمعالجة مسار القبول الاعتيادي
        private string HandleStandardFlow(string nationalId, bool hasPriorRecord, bool isRiskProfileComplete, int patientAge)
        {
            if (string.IsNullOrEmpty(nationalId))
            {
                return "Rejected: Missing National ID";
            }

            if (hasPriorRecord)
            {
                return "Rejected: Duplicate Record Exist";
            }

            if (!isRiskProfileComplete)
            {
                return "Rejected: Incomplete Risk Profile";
            }

            return patientAge < 18 ? "Approved: Pediatric Admission" : "Approved: Standard Admission";
        }
    }


