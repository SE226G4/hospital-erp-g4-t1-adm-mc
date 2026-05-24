# Database Schema
## 1. Entity-Relationship Diagram (ERD)
<img src="Diagrams/FinalERDDDD.drawio.png" width="800">

## 2. Tables List

List the main tables in your database
| Table Name | Purpose / Description |
| :--- | :--- |
| Patients |يمثل المستودع المركزي لبيانات المرضى؛    
||حيث يستخدم (NationalID) كمفتاح أساسي (PK) فريد لمنع تكرار السجلات نهائياً 
|  |
| Risk_Profiles | ملف صحي مرتبط بكل مريض، يحتوي على (فصيلة الدم، الحساسية، الأمراض المزمنة). لا يمكن إجراء أي عملية سريرية بدون استكمال هذا الجدول لضمان سلامة المرضى . |
| Staff |يدعم إدارة صلاحيات الوصول ؛ ويمكن تمييز صلاحيات الأطباء عن موظفي الاستقبال |
| Admissions |يوثق تفاصيل الزيارات والأقسام؛ وهو المسؤول عن توليد رقم الزيارة  الذي تعتمد عليه أنظمة الفوترة والإقامة. |
| Medical_Coding |يسجل أكواد ICD-10 التشخيصية، مع حقل diagnosisStatus (مبدئي/نهائي) لضمان دقة البيانات المرسلة للصيدلية والعمليات|
| Emergency_Logs |يعالج حالات الطوارئ مجهولة الهوية عبر "هوية مؤقتة" تضمن استمرارية العمل (Fallback Logic) حتى يتم التعرف على الرقم الوطني. |

## 3. Shared Data (Integration Points)
Which tables or data you share whit other teams ?

*   **Shared Table/ID:** `Patients` (specifically **`NationalID`**)
    *   **Shared With:** All Hospital Modules (2, 3, 4, 5, 6 ,7).
 ارسال المعرّف القانوني الفريد لضمان إنشاء "ملف موحد" للمريض في كامل المشفى ومنع تكرار السجلات بين الأقسام.

*   **Shared Table/ID:** `Admissions` (specifically **`AdmissionID`** / Digital Medical ID)
    *   **Shared With:** **Module 2 (Finance & Insurance)**
    .
ارسال رمز الهوية
 الرقمية الخاص بالزيارة الحالية 
لربط كل خدمة طبية مقدمة (دواء، عملية، إقامة) برقم زيارة محدد، مما يسمح لنظام المالية بجمع كافة التكاليف في فاتورة واحدة دقيقة. 

    *   **Shared With:** **Module 3 (Inpatient & Bed Management)**.
 لتزويدهم بـ "هوية طبية رقمية" موثقة؛ حيث لا يسمح نظام الإقامة بإدخال أي مريض أو تخصيص سرير له دون التحقق من وجود عملية قبول نشطة في موديولنا .

*   **Shared Table/ID:** Risk_Profiles (specifically Allergies)
    *   **Shared With:** Module 4 (Pharmacy Logistics).    
    لتزويدهم ببيانات الحساسية؛ حيث يستهلك نظام الصيدلية هذه البيانات لإجراء "فحص الحساسية" وحظر صرف أي دواء يتعارض مع حالة المريض لضمان سلامته

*   **Shared Table/ID:** Risk_Profiles (specifically BloodGroup)
    *  **Shared With:** Module 5 (Surgical Optimization).        
 لتزويدهم بفصيلة الدم المؤكدة؛ حيث يمنع نظام العمليات جدولة أي جراحة ما لم يتم التحقق من بيانات مخاطر المريض وهويته عبر موديول القبول 


*  **Shared Table/ID:** Emergency_Logs (specifically tempID)
  *  **Shared With:** Module 6 (Emergency Flow).   
لاستقبال بيانات الحالات الحرجة التي دخلت بهوية مؤقتة؛ لكي يتولى موديولنا لاحقاً عملية تحويلها إلى سجل مريض دائم (Admission) فور التعرف على الرقم الوطني لضمان استمرارية الملف الطبي

*   **Shared Table/ID:** Staff (specifically staffID)
   *  **Shared With:** Module 7 (Inventory & Supplies Management).  
 لتزويدهم ببيانات هوية الموظفين المسموح لهم بالوصول؛ حيث يحتاج موظفو المخازن للتحقق من صلاحياتهم عبر نظام الأمان (RBAC) الذي يديره موديولنا عند معالجة طلبات التزويد
***
