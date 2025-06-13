
# 🏋️ FinalMVCProjectGym

This is a Gym Management System built using **ASP.NET MVC** with **Entity Framework (Code First)** and **SQL Server**. It allows admins to manage gym operations like trainee registration, subscriptions, coaches, and gym packages. The system also includes role-based authentication for admins, Coaches, and trainees.

---

## 📌 Features

- ✅ Admin,Coach, and Trainee authentication
- ✅ Role-based access control
- ✅ Manage trainees and their subscriptions
- ✅ Assign and manage gym coaches
- ✅ Create and track gym packages
- ✅ Data validation with annotations
- ✅ Repository pattern for clean architecture

---

## 💻 Technologies Used

| Tech                     | Description                                 |
|--------------------------|---------------------------------------------|
| ASP.NET MVC              | Web development framework                   |
| Entity Framework (Code First) | ORM for database access             |
| SQL Server               | Relational database                         |
| Bootstrap 5              | Frontend styling                            |
| Identity                 | Authentication and Authorization            |
| LINQ & EF Migrations     | Data querying and schema management         |

---

## 🚀 Getting Started

### ✅ Prerequisites

- Visual Studio 2022 or later
- .NET Core
- SQL Server 
- Git

---

### 🧰 Installation & Setup

1. **Clone the Repository**

```bash
git clone https://github.com/somayayasser3/FinalMVCProjectGym.git
```

2. **Open the Solution**

Open the `FinalMVCProjectGym.sln` file in Visual Studio.

3. **Configure the Database Connection**

In `appsettings.json`, update the `connectionStrings` section to match your local SQL Server setup:

{
  "ConnectionStrings": {
    "GymCon": "Data Source=YourServerName;Initial Catalog=GymManagement;Integrated Security=True;Trust Server Certificate=True"
  },
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
      }
    },
    "AllowedHosts": "*"
  }

> 🔁 Replace `YOUR_SERVER_NAME` with your actual SQL Server instance name.

4. **Apply Migrations**

Open **Package Manager Console** and run:

```powershell
Update-Database
```

> This will create the database and apply the latest schema.

5. **Run the Application**

Click the green ▶️ (Start) button in Visual Studio or press `F5`.

---

## 📂 Project Structure

```
FinalMVCProjectGym/
│
├── Controllers/         → Handle user requests
├── Models/              → Entity and classes
├── ViewModels/          → For Views for UI [More Secured]
├── Views/               → Razor pages for UI
├── Migrations/          → EF DB Context & Seeding
├── Repositories/        → Business logic & DB access
├── wwwroot/             → Static files (JS, CSS, Images)
└── AddSettings.json     → Config file for connection strings & settings
```

---
