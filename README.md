# 📋 Recruitment Biodata Management System

A modern recruitment biodata management system developed using **ASP.NET Core MVC (.NET 8)** and **PostgreSQL**. This application allows job applicants to register, submit their biodata once, while administrators can manage applicant data through a centralized dashboard.

---

## ✨ Overview

This project was developed as part of a technical assessment to demonstrate understanding of:

* ASP.NET Core MVC (.NET 8)
* Entity Framework Core
* PostgreSQL
* Service Layer Architecture
* Repository-style separation using Interfaces & Services
* Session Authentication
* Responsive UI with Bootstrap 5

---

# 🚀 Features

## Applicant

* Register Account
* Login
* Create Biodata (One Time Only)
* View Submitted Biodata (Read Only)
* Logout

### Biodata Includes

* Personal Information
* Educational History
* Training History
* Employment History
* Skills
* Placement Availability
* Expected Salary

---

## Administrator

Administrator authentication is handled separately.

Current administrator features:

* Login as Administrator
* View All Applicants
* View Applicant Detail
* Edit Applicant Biodata
* Delete Applicant Biodata

---

# 🛠 Technology Stack

| Technology            | Version    |
| --------------------- | ---------- |
| ASP.NET Core MVC      | .NET 8     |
| Entity Framework Core | EF Core 8  |
| PostgreSQL            | Latest     |
| Bootstrap             | 5          |
| C#                    | .NET 8     |
| HTML5                 | ✔          |
| CSS3                  | ✔          |
| JavaScript            | Vanilla JS |

---

# 🏗 Project Architecture

```
Controllers
│
├── AuthController
├── FormController
└── AdminController

Interface
│
└── ViewModels
      ├── IFormService
      └── IAdminService

Services
│
├── FormService
└── AdminService

Models
│
├── Db
├── Data
└── ViewModels

Views
│
├── Auth
├── Form
├── Admin
└── Shared

wwwroot
│
├── css
├── js
└── images
```

---

# 🗄 Database

Database Engine:

```
PostgreSQL
```

ORM:

```
Entity Framework Core
```

Tables:

* Users
* Biodata
* Pendidikan
* Pelatihan
* Pekerjaan

Relationship

```
Users
   │
   └──── Biodata
             │
      ┌──────┼────────┐
      │      │        │
 Pendidikan Pelatihan Pekerjaan
```

---

# ⚙ Installation

## Clone Repository

```bash
git clone https://github.com/IQBALNAFIS1310/Mock-Up-Application-Test.git
```

```
cd Mock-Up-Application-Test
```

---

## Configure Database

Open

```
appsettings.json
```

Configure your PostgreSQL Connection String.

Example

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=RecruitmentDB;Username=postgres;Password=yourpassword"
}
```

---

## Install Entity Framework Tools

```bash
dotnet tool install --global dotnet-ef
```

or update

```bash
dotnet tool update --global dotnet-ef
```

---

## Restore Packages

```bash
dotnet restore
```

---

## Create Database

If migration does not exist

```bash
dotnet ef migrations add InitialCreate
```

Apply migration

```bash
dotnet ef database update
```

---

## Run Application

```bash
dotnet run
```

or

```
Visual Studio

Ctrl + F5
```

---

# 👤 User Flow

```
Register
      │
      ▼
Login
      │
      ▼
Dashboard
      │
      ▼
Create Biodata
      │
      ▼
Readonly Biodata
```

---

# 🔐 Roles

## Applicant

* Register
* Login
* Submit Biodata
* View Biodata

Applicant cannot:

* Edit Biodata
* Delete Biodata

---

## Administrator

* Login
* View Applicant List
* View Detail
* Edit Biodata
* Delete Biodata

---

# 📌 Future Improvements

* Export Biodata to PDF
* Email Notification
* File Upload (CV & Photo)
* Dashboard Statistics
* Search & Filter
* Pagination
* Authentication using ASP.NET Identity
* Role Based Authorization
* Audit Log

---

# 📷 Screenshots

You can place screenshots inside

```
docs/
```

Example

```
docs/login.png
docs/register.png
docs/dashboard.png
docs/create.png
docs/admin.png
```

---

# 👨‍💻 Author

**Iqbal Nafis**

Programmer | .NET Developer

GitHub

https://github.com/IQBALNAFIS1310

---

Thank you for visiting this repository.
