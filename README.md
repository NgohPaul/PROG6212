# Contract Monthly Claim System (CMCS)

The Contract Monthly Claim System (CMCS) is a web-based application developed using ASP.NET Core MVC. It is designed to streamline the monthly claim submission, review, and approval process for lecturers, coordinators, and managers.  

---

## Features

Role-Based Dashboards  
- Lecturer: Submit new claims with details such as month, year, hours worked, and hourly rate.  
- Coordinator: Review lecturer claims and provide feedback or approvals.  
- Manager: Final review and authorization of claims.  

Claims Management  
- Submit new claims via an online form.  
- View submitted claims.  
- Track claim statuses throughout the workflow.  

Security  
- Role-based access ensures users can only access the features relevant to their role.  

---

## Technologies Used

ASP.NET Core MVC 7.0  
C#  
Entity Framework Core  
Razor Views  
Bootstrap 5  
SQL Server / LocalDB  

---

## Project Structure

CMCS/  
├── Controllers/        MVC Controllers (Home, Claims, Coordinator, Manager)  
├── Models/             Domain models (e.g., ClaimViewModel, Claim)  
├── Views/              Razor Views for each controller  
│   ├── Home/  
│   ├── Claims/  
│   ├── Coordinator/  
│   └── Manager/  
├── wwwroot/            Static files (CSS, JS, Bootstrap, images)  
├── appsettings.json    Database connection strings and configuration  
└── Program.cs          Application entry point  

---

## Getting Started

### Prerequisites
Visual Studio 2022 or VS Code  

### Installation
1. Clone the repository:  
   git clone https://github.com/your-username/CMCS.git  
   cd CMCS  

2. Restore dependencies:  
   dotnet restore  

3. Run the application:  
   dotnet run  

---

## Usage

Lecturer Dashboard → Submit a new monthly claim  
Coordinator Dashboard → Review submitted claims  
Manager Dashboard → Finalize claim approvals  

---

## Future Improvements

Authentication and Authorization (Identity)  
Email notifications for claim status updates  
Export claim reports to PDF or Excel  
Integration with payroll systems  

---

