# 🚀 Demo E-commerce Application

This is a **Demo E-commerce** application built using **C#**, **.NET Core MVC**, **Entity Framework**, **LINQ**, and **SQL Server**. The goal of this project is to demonstrate key backend development practices such as **CRUD operations**, **Authentication & Authorization**, and the use of the **Repository Pattern** and **DTOs** for data management.

## 🔧 Key Features

- **CRUD Operations**: Create, Read, Update, and Delete operations for product management with **data validation**.
- **Authentication & Authorization**: User management with **roles** (Guest, User, Admin) for **secure access control**.
- **Repository Pattern**: Ensures clean and scalable architecture by separating data access logic.
- **DTOs (Data Transfer Objects)**: Used for transferring data between layers and ensuring separation of concerns.
- **Entity Framework**: Seamlessly integrates with SQL Server for **data management** and **LINQ** for querying.
- **Razor Pages**: Provides dynamic and efficient views with minimal code.
- **SOLID Principles**: Follows **best practices** for clean, maintainable, and scalable code.
- **User Identity Management**: Secure and flexible user authentication and authorization.
- **Services Layer**: Encapsulates business logic for easier management and testing.

## 💻 Database Setup
1- SQL Server: Ensure that you have SQL Server installed and running And Add Product-Contro-DB.bak File To Your Data Base


## 💻 Installation


1. Clone the repo:
   git clone https://github.com/AmrMagdy00/Product-Control.git

2. Navigate to the project folder:
   cd Product-Control

3. Restore the NuGet dependencies:
   dotnet restore

4. Build the project:
   dotnet build

5. Run the application:
   dotnet run


## 🛠️ Technologies Used
C#

.NET Core MVC

Entity Framework

LINQ

SQL Server

Razor Pages

SOLID Principles

Dependency Injection

Repository Pattern


 ## 📄 Project Structure
/Controllers      # Contains application logic, interacts with services and manages requests

/Models           # Data models (representing DB structure)

/Services         # Business logic encapsulation, acts as an intermediary between the repository and controllers

/Repositories     # Data access layer using Repository Pattern for clean and efficient data retrieval

/DTOs             # Data Transfer Objects for clean data management, used for data transformation

/Views            # Razor Pages for dynamic and efficient UI

/Helpers          # Contains utility classes such as RoleInitializer that handle different tasks for the application


## 📈 Contributing
We welcome contributions to this project! Please feel free to submit issues or pull requests. Here are the steps to contribute:
Fork the repo.
Create a new branch (git checkout -b feature-name).
Commit your changes (git commit -am 'Add new feature').
Push to the branch (git push origin feature-name).
Submit a pull request.

## 🔗 Links
GitHub: [Product-Control](https://github.com/AmrMagdy00/Product-Control.git)


## 💬 Contact
If you have any questions or suggestions, feel free to reach out!
