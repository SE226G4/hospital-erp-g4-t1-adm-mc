# Module Name: Admission & Medical Coding
## Project: Hospital ERP / MediChain
**Module Code:** ADM-MC

---

## 📝 Module Overview
The Admission & Medical Coding (ADM-MC) module serves as the "Central Nucleus" of the MediChain Hospital ERP system
. It acts as the Single Source of Truth, ensuring that every patient has a unified "Digital Medical Identity" linked to their National ID to eliminate record duplication
. This module is a technical prerequisite for all other departments; no medical procedure can be performed without identity verification and a completed "Risk Profile" from this system
 
 ##  Strategic Objectives
 * Zero Duplication: Enforcing the National ID as a unique key to prevent overlapping patient records
.
* Mandatory Risk Profiling: Making data regarding allergies, blood groups, and chronic diseases a technical constraint before any medication or surgery can be scheduled


---

## 👥 Team Members & Responsibilities

| Member Name | Primary Responsibility | Assigned Tasks (Examples) | GitHub Profile |
| :--- | :--- | :--- | :--- |
| **Ali Ali** | Integration & Architecture | Component Diagrams, API Specs, Team Coordination | [https://github.com/aliali29] |
| **Majd Omran** | Requirements & Analysis | Functional Requirements, Use Case Diagrams | [https://github.com/majdomran-it] |
| **Mohammed Dandash** | Process Modeling | Activity Diagrams, Business Rules Validation | [https://github.com/MohamadDandash] |
| **Hussien Mousa** | Data Design | ERD, Database Schema, Class Diagrams | [https://github.com/Husseinm963] |


---

## 🚀 Analysis & Design Progress
- [x] **Requirement Elicitation:** Completed list of FRs/NFRs.
- [x] **UML Behavioral Diagrams:** Use Case and Activity Diagrams.
- [x] **UML Structural Diagrams:** ERD and Class Diagrams.
- [ ] **Dynamic Modeling:** Sequence Diagrams for core processes.

---

## 🔗 Integration Points
*How this module communicates with others:*
* **Inbound:** Data received by ADM-MC
	* National ID: Received during patient registration to verify identity and prevent duplicate records.
	* Medical Risk Data: Received from medical staff to complete the "Risk Profile," including allergies, blood group, and chronic diseases.
	
* **Outbound:** Data sent by ADM-MC
	* Patient ID (Token): Sent to all hospital departments (IPD-BED, SURG-OPT, ER-FLOW) as a mandatory authorization for patient admission and procedures.
	* Allergy Status: Sent to Pharmacy (PHM-LOG) to prevent the dispensing of conflicting medications.
	* Blood Group Verification: Sent to Surgery (SURG-OPT) to allow operation scheduling.
	* Identity Feed: Sent to Finance (FIN-INS) to ensure all services are linked to a single, unified bill for the patient.
	* Bed Allocation Authorization: Sent to Inpatient (IPD-BED) to permit bed assignment based on verified identity.

---
## 🛠 Tools Used
* **Modeling:** Draw.io.
* **Documentation:** Markdown .
* **Version Control:** GitHub.
