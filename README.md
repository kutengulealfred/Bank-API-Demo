Bank API Demo
Summary

The purpose of this project is to create a prototypical core framework to integrate into a banks new API

Application Features

Creating New Bank Accounts
Update Accounts
Make Deposits
Make Withdraw
Make Transfer
View Transactiont History
Register New User
Login
Used Technologies:

C#
ASP.NET Core 3.1
Entity Framework Core
ASP.NET Core Web API
Entity Framework Core
Asymmetric & hybrid encryption
Microsoft SQL Server
Swagger UI
System Requirements

ASP.NET Core .NET Core SDK 3.1.101 .Net Core Runtime 3.1.1
Visual Studio or VSCode
Microsoft SQL Server
Required NuGet packages

AutoMapper.Extensions.Microsoft.DependencyInjection
Microsoft.AspNetCore.Authentication.JwtBearer
Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
ASP.NET Core Web API
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore
Swashbuckle.AspNetCore.Newtonsoft
Steps to run applications locally

Download project Zip or git clone
Open solution(Sln) in Visual Studio or any preferred IDE
Restore Nuget packages
Restore database by typing "Add-Migration "InitialCreated"" in Package Manager Console
Then type "Update-Database"
Once database is restored successfully, hit ctrl+5 or click II Express to run the project
Go to Url: https://localhost:44365/swagger/index.html to test application using Swagger UI
Application Architecture

The application was built on ASP.NET Core Web API

Folder/Directory Structure:

├── Controllers
│   ├── AccountsController.cs
|   ├── AuthController.cs
│   ├── TransactionsController
│
├── Data
│   ├── ApplicationDbContext.cs
│
├── Models
│   ├── Account.cs
│   ├── AuthentiateModel.cs
│   ├── GetAccountModel.cs
│   ├── RegisterNewAccountModel.cs
│   ├── Response.cs
│   ├── Transaction.cs
│   ├── TransactionRequestDto.cs
│   ├── UpdateAccountModel.cs
│   ├── User.cs
│   ├── UserForLoginDto.cs
│   ├── UserForRegisterDto.cs
│    
│
├── Profiles
│   ├── AutomapperProfiles
│
├── Services
│   ├── Implementations
│   │    ├── AccountService.cs
│   │    ├── AuthService.cs
│   │    ├── TransactionService.cs
│   │
│   ├── Interfaces
│        ├── IAccountService.cs
│        ├── IAuthService.cs
│        ├── ITransactionService.cs
│
├── Utils
│   ├── AppSettings
│   
│
├── appsettings.json
├── Program.cs
├── Startup.cs
Security

We have adopted the following security features and partterns:

Repository pattern
Automapper
Asymmetric & hybrid encryption (Hashing & Salting)
Jason Web Token(JWT) Authentication
