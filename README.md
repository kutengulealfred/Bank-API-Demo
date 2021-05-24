# BankAPIDemo
**Summary**
<p>The purpose of this project is to create a prototypical core framework to integrate into a banks new API</p>

**Application Features**
<ul>
  <li>Creating New Bank Accounts</li>
  <li>Update Accounts</li>
  <li>Make Deposits</li>
  <li>Make Withdraw</li>
  <li>Make Transfer</li>
  <li>View Transactiont History</li>
  <li>Register New User</li>
  <li>Login</li>
 </ul>

**Used Technologies:**
<ul>
  <li>C#</li>
  <li>ASP.NET Core 3.1</li>
  <li> Entity Framework Core</li>
  <li>ASP.NET Core Web API</li>
  <li>Entity Framework Core</li>
  <li>Asymmetric & hybrid encryption</li>
  <li>Microsoft SQL Server</li>
  <li>Swagger UI</li>
</ul>

**System Requirements**
<ul>
<li>ASP.NET Core .NET Core SDK 3.1.101 .Net Core Runtime 3.1.1</li>
<li>Visual Studio or VSCode</li> 
<li>Microsoft SQL Server</li>
</ul> 

**Required NuGet packages**
<ul>
  <li>AutoMapper.Extensions.Microsoft.DependencyInjection</li>
  <li>Microsoft.AspNetCore.Authentication.JwtBearer</li>
  <li>Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore</li>
  <li>ASP.NET Core Web API</li>
  <li>Microsoft.EntityFrameworkCore.SqlServer</li>
  <li>Microsoft.EntityFrameworkCore.Tools</li>
  <li>Swashbuckle.AspNetCore</li>
  <li>Swashbuckle.AspNetCore.Newtonsoft</li>
</ul>

**Steps to run applications locally**
<ol>
  <li>Download project Zip or git clone</li>
  <li>Open solution(Sln) in Visual Studio or any preferred IDE</li>
  <li>Restore Nuget packages</li>
  <li>Restore database by typing "Add-Migration "InitialCreated"" in Package Manager Console</li>
  <li>Then type "Update-Database"</li>
  <li>Once database is restored successfully, hit ctrl+5 or click II Express to run the project</li>
  <li>Go to Url: https://localhost:44365/swagger/index.html to test application using Swagger UI</li>
  
</ol>

**Application Architecture**
<p>The application was built on ASP.NET Core Web API</p>

<p>Folder/Directory Structure:</p>

<pre>
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
</pre>


**Security**

<p>We have adopted the following security features and partterns:</p>
<ol>
  <li>Repository pattern</li>
  <li>Automapper</li>
  <li>Asymmetric & hybrid encryption (Hashing & Salting)</li>
  <li>Jason Web Token(JWT) Authentication</li>
 </ol>

