API Specifications (Module 1: ADM-MC) - مركز الهوية الرقمية

## 1. Overview (نظرة عامة)
Overview (نظرة عامة)

يُمثل موديول القبول والترميز الطبي (ADM-MC) "النواة المركزية" (Central Nucleus) لنظام MediChain ERP والمصدر المرجعي والوحيد للبيانات (Single Source of Truth) داخل المنشأة الطبية. تكمن الوظيفة الجوهرية لهذا الموديول في إدارة دورة حياة هوية المريض وضمان دقة البيانات المتبادلة بين الأقسام المختلفة.

تتركز الأهداف الأساسية للموديول في المحاور التالية:

   * منع تكرار سجلات المرضى (Duplication Prevention): يفرض الموديول نظام تحقق صارم يعتمد على الرقم الوطني (national_id) كمعرف قانوني فريد؛ حيث يمنع النظام بشكل قطعي إنشاء أي سجل مريض جديد في حال وجود سجل سابق، مما يضمن وجود "ملف موحد" لكل مريض وتفادي تشتت البيانات السريرية.

   * إنشاء وإدارة الهوية الرقمية الموحدة (Digital Identity Management): يتولى الموديول مسؤولية توليد "هوية طبية رقمية" (digital_id_token) فريدة لكل مريض. تعمل هذه الهوية كـ "Token" أمان معتمد، وهي المفتاح الوحيد الذي تعتمد عليه كافة الموديولات الأخرى (مثل الصيدلية، العمليات، والإقامة) للتحقق من هوية المريض والوصول إلى بياناته السريرية والمالية بأمان.

   * مركزية البيانات الحرجة والترميز الطبي: يعمل الموديول كحلقة وصل تقنية لتزويد الأقسام الأخرى ببيانات "ملف المخاطر" (Risk Profile) والترميز التشخيصي (ICD-10)، مما يضمن سلامة المريض عند صرف الأدوية أو إجراء العمليات، ويحقق الدقة والموثوقية في عملية الفوترة المالية اللاحقة.
---

## 2. Main Endpoints (واجهات البرمجة الرئيسية)

Endpoint 1: National Identity Verification & Token Retrieval

    Method: GET

    الوظيفة: التحقق من وجود سجل مسبق للمريض باستخدام الرقم الوطني لمنع تكرار السجلات.

    المدخلات: national_id (المعرف القانوني الفريد من جدول patients).

    المخرجات: digital_id_token (المعرف الرقمي للتعاملات الداخلية)، full_name، و registration_status.

    الهدف: تزويد الموديولات الأخرى بـ Token المريض بدلاً من بياناته الحساسة.

---

Endpoint 2: Patient Registration & Token Generation

    Method: POST

    الوظيفة: تسجيل مريض جديد وتوليد digital_id_token فريد وتلقائي له.

    المدخلات (من جدول patients): national_id, full_name, date_of_birth, gender, contact_info.

    المخرجات: digital_id_token (يتم تخزينه في جميع الأنظمة اللاحقة كمرجع أساسي للمريض).

---

Endpoint 3: Risk Profile Access (The Safety Hub)

    Method: GET

    الوظيفة: توفير البيانات السريرية الحرجة (فصيلة الدم، الحساسية) للصيدلية والعمليات لضمان سلامة المريض.

    المدخلات: digital_id_token.

    المخرجات (من جدول risk_profiles): blood_type, allergies, chronic_diseases، وحالة اكتمال الملف is_risk_profile_complete.

    ملاحظة: لا يُسمح للصيدلية بصرف دواء دون استدعاء هذا الـ API للتحقق من التداخلات الدوائية مع الحساسية المسجلة.

---

Endpoint 4: Admission Syncing & Billing Status

    Method: POST

    الوظيفة: ربط المريض بعملية قبول رسمية وتحديد القسم المسؤول، مما يفتح ملفاً مالياً له.

    المدخلات: patient_id (المرتبط بالـ Digital ID), staff_id (الموظف المسؤول), assigned_department.

    المخرجات: admission_id وحالة الفوترة الابتدائية billing_status.

---

Endpoint 5: Staff RBAC Authorization

    Method: POST

    الوظيفة: التحقق من صلاحيات الوصول المستندة إلى الأدوار (RBAC) قبل السماح بتعديل البيانات الطبية.

    المدخلات (من جدول staff): staff_id, requested_action.

    المخرجات: role, permissions_level (مثل: طبيب، ممرض، أو مرمز طبي) لضمان أمن البيانات.

---

Endpoint 6: Emergency Temporary Identity Handover

    Method: POST

    الوظيفة: إنشاء هوية مؤقتة لحالات الطوارئ المجهولة لضمان استمرارية العمل السريري.

    المدخلات (من جدول emergency_logs): arrival_time, condition_summary.

    المخرجات: temp_id (يُستخدم كـ Token مؤقت في موديول الطوارئ حتى يتم تحديثه لاحقاً لـ digital_id_token رسمي).

---

Endpoint 7: Medical Coding Integration (ICD-10)

    Method: POST

    الوظيفة: توثيق التشخيص النهائي باستخدام أكواد ICD-10 وربطه بالقبول لضمان دقة الفوترة.

    المدخلات (من جدول medical_codes): admission_id, icd_10_code, diagnosis_description.

    المخرجات: coding_status (تأكيد الحفظ للبدء بإصدار الفاتورة النهائية)