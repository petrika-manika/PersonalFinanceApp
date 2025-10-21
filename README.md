# Personal Finance Application 💰

[![.NET Version](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![License](https://img.shields.io/badge/License-MIT-green.svg?style=flat-square)](LICENSE)
[![Build Status](https://img.shields.io/badge/build-passing-brightgreen?style=flat-square)](https://github.com/yourusername/PersonalFinanceApp)

A modern, full-featured **Personal Finance Management API** built with **.NET 8**, following **Clean Architecture** principles and **Domain-Driven Design** patterns. Manage your income, expenses, and categories with a secure, scalable, and maintainable RESTful API.

---

## 📋 Table of Contents

- [Project Overview](#-project-overview)
- [Features](#-features)
- [Architecture](#-architecture)
- [Technologies](#-technologies)
- [Getting Started](#-getting-started)
- [Project Structure](#-project-structure)
- [API Endpoints](#-api-endpoints)
- [Database Schema](#-database-schema)
- [Authentication](#-authentication)
- [Validation](#-validation)
- [Error Handling](#-error-handling)
- [Future Enhancements](#-future-enhancements)
- [Contributing](#-contributing)
- [License](#-license)

---

## 🎯 Project Overview

**Personal Finance Application** is a robust .NET 8 Web API designed to help users manage their personal finances efficiently. Built with industry best practices, the application provides a solid foundation for tracking income, expenses, and financial categories.

### Key Highlights:
- ✅ **Clean Architecture** - Clear separation of concerns across layers
- ✅ **CQRS Pattern** - Segregation of command and query responsibilities
- ✅ **Domain-Driven Design** - Rich domain models with business logic
- ✅ **JWT Authentication** - Secure, stateless authentication
- ✅ **Entity Framework Core** - Code-first database approach
- ✅ **FluentValidation** - Comprehensive input validation
- ✅ **Global Exception Handling** - Consistent error responses
- ✅ **Swagger/OpenAPI** - Interactive API documentation

---

## ✨ Features

### 🔐 Authentication & Authorization
- **User Registration** - Create new accounts with email and password
- **User Login** - JWT-based authentication
- **Password Hashing** - Secure password storage using BCrypt
- **Token Validation** - Automatic JWT token validation for protected endpoints

### 📁 Category Management
- **Create Categories** - Define custom income/expense categories
- **List Categories** - View all user categories
- **Update Categories** - Modify category names and types
- **Delete Categories** - Remove unused categories
- **Category Types** - Separate income and expense categories

### 💵 Transaction Management
- **Create Transactions** - Record income and expenses
- **List Transactions** - View all transactions with optional filters
- **Filter Transactions** - By month, year, or category
- **Update Transactions** - Modify transaction details
- **Delete Transactions** - Remove transactions
- **Category Assignment** - Link transactions to categories
- **Type Validation** - Ensure transaction types match category types

### ✅ Data Validation
- **FluentValidation** - Declarative validation rules
- **Business Rules** - Domain-level validation (amount > 0, type matching)
- **Async Validation** - Database uniqueness checks
- **Detailed Error Messages** - Clear validation feedback

### 🛡️ Error Handling
- **Global Exception Middleware** - Catches all unhandled exceptions
- **Consistent Error Format** - Standardized JSON error responses
- **HTTP Status Codes** - Appropriate status codes (400, 401, 404, 500)
- **Validation Errors** - Grouped by property name

---

## 🏗️ Architecture

This project follows **Clean Architecture** principles, ensuring maintainability, testability, and independence from frameworks.

### Layers:

```
┌─────────────────────────────────────────────────────────────┐
│                        API Layer                             │
│  Controllers, Middleware, Program.cs, Swagger Config        │
│  ↓ Depends on Application                                   │
└─────────────────────────────────────────────────────────────┘
                            ↓
┌─────────────────────────────────────────────────────────────┐
│                    Application Layer                         │
│  Commands, Queries, Handlers, Validators, DTOs,             │
│  Interfaces, MediatR Pipeline Behaviors                      │
│  ↓ Depends on Domain                                        │
└─────────────────────────────────────────────────────────────┘
                            ↓
┌─────────────────────────────────────────────────────────────┐
│                      Domain Layer                            │
│  Entities, Value Objects, Domain Exceptions,                │
│  Business Logic, Enums                                       │
│  (No dependencies on other layers)                           │
└─────────────────────────────────────────────────────────────┘
                            ↑
┌─────────────────────────────────────────────────────────────┐
│                  Infrastructure Layer                        │
│  EF Core, DbContext, Configurations, Services               │
│  (BCrypt, JWT), Data Access                                  │
│  ↓ Implements Application interfaces                        │
└─────────────────────────────────────────────────────────────┘
```

### Design Patterns:
- **CQRS** (Command Query Responsibility Segregation) - Separates read and write operations
- **MediatR** - Decouples request/response handling
- **Repository Pattern** - Abstraction over data access (via EF Core DbContext)
- **Dependency Injection** - Loose coupling and testability
- **Unit of Work** - EF Core DbContext transaction management

---

## 🛠️ Technologies

### Core Framework
- **[.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)** - Latest LTS version of .NET
- **[ASP.NET Core 8](https://docs.microsoft.com/aspnet/core)** - Web API framework
- **[C# 12](https://docs.microsoft.com/dotnet/csharp/whats-new/csharp-12)** - Latest C# language features

### Database & ORM
- **[Entity Framework Core 8.0](https://docs.microsoft.com/ef/core/)** - Object-Relational Mapper
- **[SQL Server](https://www.microsoft.com/sql-server)** - Relational database
- **[EF Core Migrations](https://docs.microsoft.com/ef/core/managing-schemas/migrations/)** - Database version control

### Authentication & Security
- **[JWT Bearer Authentication](https://jwt.io/)** - Stateless authentication
- **[BCrypt.Net-Next 4.0](https://github.com/BcryptNet/bcrypt.net)** - Password hashing
- **[Microsoft.IdentityModel.Tokens](https://www.nuget.org/packages/Microsoft.IdentityModel.Tokens/)** - Token validation

### Validation & Patterns
- **[MediatR 12.4](https://github.com/jbogard/MediatR)** - CQRS implementation
- **[FluentValidation 11.11](https://fluentvalidation.net/)** - Input validation
- **[AutoMapper 12.0](https://automapper.org/)** - Object-to-object mapping

### API Documentation
- **[Swashbuckle (Swagger) 6.6](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)** - OpenAPI documentation
- **Swagger UI** - Interactive API testing

### Development Tools
- **[Visual Studio 2022](https://visualstudio.microsoft.com/)** / **[VS Code](https://code.visualstudio.com/)** - IDEs
- **[SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup)** - Database management

---

## 🚀 Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

1. **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)** (version 8.0 or later)
2. **[SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads)** (Express, LocalDB, or full version)
3. **[Visual Studio 2022](https://visualstudio.microsoft.com/)** (recommended) or **[VS Code](https://code.visualstudio.com/)**
4. **[SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup)** (optional, for database management)

### Installation Steps

#### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/PersonalFinanceApp.git
cd PersonalFinanceApp
```

#### 2. Configure Database Connection

Update the connection string in `src/PersonalFinanceApp.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=PersonalFinanceDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Connection String Options:**
- **SQL Server Express**: `Server=localhost\\SQLEXPRESS;...`
- **LocalDB**: `Server=(localdb)\\mssqllocaldb;...`
- **Full SQL Server**: `Server=localhost;...`

#### 3. Configure JWT Settings

Update JWT settings in `src/PersonalFinanceApp.API/appsettings.Development.json`:

```json
{
  "JwtSettings": {
    "Secret": "YourSuperSecretKeyForJWTTokenGeneration123456789!@#$%^&*()",
    "Issuer": "PersonalFinanceApp",
    "Audience": "PersonalFinanceApp",
    "ExpirationInMinutes": 60
  }
}
```

⚠️ **Security Note**: Use environment variables or Azure Key Vault for production secrets!

#### 4. Restore NuGet Packages
```bash
dotnet restore
```

#### 5. Apply Database Migrations

Navigate to the Infrastructure project and run migrations:

```bash
# From solution root
cd src/PersonalFinanceApp.Infrastructure

# Create database and apply migrations
dotnet ef database update --startup-project ../PersonalFinanceApp.API

# Or from solution root
dotnet ef database update --project src/PersonalFinanceApp.Infrastructure --startup-project src/PersonalFinanceApp.API
```

**Verify Migration:**
- Open SSMS and confirm `PersonalFinanceDb` database exists
- Check for tables: `Users`, `Categories`, `Transactions`

#### 6. Build the Solution
```bash
dotnet build
```

#### 7. Run the Application

**Option A: Using Visual Studio**
1. Open `PersonalFinanceApp.sln` in Visual Studio 2022
2. Set `PersonalFinanceApp.API` as the startup project
3. Press `F5` or click "Run"

**Option B: Using .NET CLI**
```bash
cd src/PersonalFinanceApp.API
dotnet run
```

The API will start at:
- **HTTPS**: `https://localhost:7xxx`
- **HTTP**: `http://localhost:5xxx`

#### 8. Access Swagger UI

Open your browser and navigate to:
```
https://localhost:7xxx/swagger
```

You'll see the interactive API documentation with all available endpoints.

---

## 🧪 Testing with Swagger

### 1. Register a New User

**Endpoint**: `POST /api/auth/register`

**Request Body**:
```json
{
  "email": "test@example.com",
  "password": "Test123",
  "firstName": "John",
  "lastName": "Doe"
}
```

**Response**: Returns user info and JWT token

### 2. Authenticate (Login)

**Endpoint**: `POST /api/auth/login`

**Request Body**:
```json
{
  "email": "test@example.com",
  "password": "Test123"
}
```

**Response**: Returns JWT token

### 3. Authorize in Swagger

1. Click the **"Authorize"** button (🔒) at the top right
2. Enter: `Bearer YOUR_JWT_TOKEN_HERE`
3. Click **"Authorize"**
4. Now you can access protected endpoints!

### 4. Create a Category

**Endpoint**: `POST /api/categories`

**Request Body**:
```json
{
  "name": "Groceries",
  "type": 1
}
```
*Types: 0 = Income, 1 = Expense*

### 5. Create a Transaction

**Endpoint**: `POST /api/transactions`

**Request Body**:
```json
{
  "amount": 50.00,
  "type": 1,
  "categoryId": "guid-from-category-creation",
  "description": "Weekly groceries",
  "date": "2024-01-20T10:30:00Z"
}
```

### 6. Get Transactions with Filters

**Endpoint**: `GET /api/transactions?month=1&year=2024`

**Query Parameters**:
- `month` (optional): Filter by month (1-12)
- `year` (optional): Filter by year
- `categoryId` (optional): Filter by category

---

## 📁 Project Structure

```
PersonalFinanceApp/
│
├── src/
│   ├── PersonalFinanceApp.API/              # Presentation Layer
│   │   ├── Controllers/                     # API Controllers
│   │   │   ├── AuthController.cs            # Authentication endpoints
│   │   │   ├── CategoriesController.cs      # Category CRUD
│   │   │   └── TransactionsController.cs    # Transaction CRUD
│   │   ├── Middleware/                      # Custom middleware
│   │   │   └── ExceptionHandlingMiddleware.cs
│   │   ├── appsettings.json                 # Configuration
│   │   ├── appsettings.Development.json
│   │   └── Program.cs                       # Application entry point
│   │
│   ├── PersonalFinanceApp.Application/      # Application Layer
│   │   ├── Common/
│   │   │   ├── Behaviors/                   # MediatR pipeline behaviors
│   │   │   │   └── ValidationBehavior.cs
│   │   │   ├── Exceptions/                  # Application exceptions
│   │   │   │   └── ValidationException.cs
│   │   │   ├── Interfaces/                  # Abstractions
│   │   │   │   ├── IApplicationDbContext.cs
│   │   │   │   ├── IJwtTokenService.cs
│   │   │   │   └── IPasswordHasher.cs
│   │   │   └── Settings/                    # Configuration models
│   │   │       └── JwtSettings.cs
│   │   ├── Features/                        # Feature folders (CQRS)
│   │   │   ├── Authentication/
│   │   │   │   ├── Commands/
│   │   │   │   │   ├── RegisterUser/
│   │   │   │   │   │   ├── RegisterUserCommand.cs
│   │   │   │   │   │   ├── RegisterUserCommandHandler.cs
│   │   │   │   │   │   └── RegisterUserCommandValidator.cs
│   │   │   │   │   └── LoginUser/
│   │   │   │   │       ├── LoginUserCommand.cs
│   │   │   │   │       ├── LoginUserCommandHandler.cs
│   │   │   │   │       └── LoginUserCommandValidator.cs
│   │   │   │   └── Common/
│   │   │   │       └── AuthenticationResult.cs
│   │   │   ├── Categories/
│   │   │   │   ├── Commands/
│   │   │   │   │   ├── CreateCategory/
│   │   │   │   │   ├── UpdateCategory/
│   │   │   │   │   └── DeleteCategory/
│   │   │   │   ├── Queries/
│   │   │   │   │   ├── GetCategories/
│   │   │   │   │   └── GetCategoryById/
│   │   │   │   └── Common/
│   │   │   │       ├── CategoryDto.cs
│   │   │   │       └── CategoryResult.cs
│   │   │   └── Transactions/
│   │   │       ├── Commands/
│   │   │       │   ├── CreateTransaction/
│   │   │       │   ├── UpdateTransaction/
│   │   │       │   └── DeleteTransaction/
│   │   │       ├── Queries/
│   │   │       │   ├── GetTransactions/
│   │   │       │   └── GetTransactionById/
│   │   │       └── Common/
│   │   │           ├── TransactionDto.cs
│   │   │           └── TransactionResult.cs
│   │   └── DependencyInjection.cs           # Service registration
│   │
│   ├── PersonalFinanceApp.Domain/           # Domain Layer
│   │   ├── Entities/                        # Domain entities
│   │   │   ├── User.cs
│   │   │   ├── Category.cs
│   │   │   └── Transaction.cs
│   │   ├── Enums/                           # Domain enumerations
│   │   │   ├── TransactionType.cs
│   │   │   └── CategoryType.cs
│   │   └── Exceptions/                      # Domain exceptions
│   │       ├── DomainException.cs
│   │       ├── InvalidEmailException.cs
│   │       ├── InvalidPasswordException.cs
│   │       ├── InvalidTransactionAmountException.cs
│   │       └── InvalidCategoryAssignmentException.cs
│   │
│   └── PersonalFinanceApp.Infrastructure/   # Infrastructure Layer
│       ├── Data/
│       │   ├── Configurations/              # EF Core configurations
│       │   │   ├── UserConfiguration.cs
│       │   │   ├── CategoryConfiguration.cs
│       │   │   └── TransactionConfiguration.cs
│       │   ├── Migrations/                  # EF Core migrations
│       │   └── ApplicationDbContext.cs      # DbContext
│       ├── Services/                        # Infrastructure services
│       │   ├── PasswordHasher.cs            # BCrypt implementation
│       │   └── JwtTokenService.cs           # JWT generation
│       └── DependencyInjection.cs           # Service registration
│
├── tests/                                    # Test projects (future)
│   ├── PersonalFinanceApp.Domain.Tests/
│   ├── PersonalFinanceApp.Application.Tests/
│   └── PersonalFinanceApp.API.Tests/
│
├── docs/                                     # Documentation
│   ├── AuthenticationImplementation.md
│   ├── CategoryCRUDImplementation.md
│   └── TransactionCRUDImplementation.md
│
├── .gitignore                                # Git ignore rules
├── PersonalFinanceApp.sln                    # Solution file
└── README.md                                 # This file
```

---

## 🔌 API Endpoints

### Authentication Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/auth/register` | Register new user | ❌ No |
| POST | `/api/auth/login` | Authenticate user | ❌ No |

### Category Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/categories` | Create category | ✅ Yes |
| GET | `/api/categories` | Get all user categories | ✅ Yes |
| GET | `/api/categories/{id}` | Get category by ID | ✅ Yes |
| PUT | `/api/categories/{id}` | Update category | ✅ Yes |
| DELETE | `/api/categories/{id}` | Delete category | ✅ Yes |

### Transaction Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/transactions` | Create transaction | ✅ Yes |
| GET | `/api/transactions` | Get all user transactions | ✅ Yes |
| GET | `/api/transactions?month=1&year=2024` | Filter by month/year | ✅ Yes |
| GET | `/api/transactions?categoryId={guid}` | Filter by category | ✅ Yes |
| GET | `/api/transactions/{id}` | Get transaction by ID | ✅ Yes |
| PUT | `/api/transactions/{id}` | Update transaction | ✅ Yes |
| DELETE | `/api/transactions/{id}` | Delete transaction | ✅ Yes |

### Request/Response Examples

**Register User**:
```json
POST /api/auth/register
{
  "email": "user@example.com",
  "password": "SecurePass123",
  "firstName": "John",
  "lastName": "Doe"
}

Response: 200 OK
{
  "userId": "guid",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "email": "user@example.com",
  "firstName": "John",
  "lastName": "Doe"
}
```

**Create Transaction**:
```json
POST /api/transactions
Authorization: Bearer {token}
{
  "amount": 150.50,
  "type": 1,
  "categoryId": "category-guid",
  "description": "Grocery shopping",
  "date": "2024-01-20T10:30:00Z"
}

Response: 201 Created
{
  "transactionId": "guid",
  "amount": 150.50,
  "type": 1,
  "categoryId": "category-guid",
  "categoryName": "Groceries",
  "description": "Grocery shopping",
  "date": "2024-01-20T10:30:00Z",
  "createdAt": "2024-01-20T10:30:00Z"
}
```

---

## 🗄️ Database Schema

### Users Table
| Column | Type | Constraints |
|--------|------|-------------|
| Id | uniqueidentifier | PK |
| Email | nvarchar(256) | NOT NULL, UNIQUE |
| PasswordHash | nvarchar(MAX) | NOT NULL |
| FirstName | nvarchar(100) | NULL |
| LastName | nvarchar(100) | NULL |
| CreatedAt | datetime2 | NOT NULL |
| UpdatedAt | datetime2 | NOT NULL |

### Categories Table
| Column | Type | Constraints |
|--------|------|-------------|
| Id | uniqueidentifier | PK |
| UserId | uniqueidentifier | FK → Users(Id), NOT NULL |
| Name | nvarchar(100) | NOT NULL |
| Type | int | NOT NULL (0=Income, 1=Expense) |
| CreatedAt | datetime2 | NOT NULL |
| UpdatedAt | datetime2 | NOT NULL |

### Transactions Table
| Column | Type | Constraints |
|--------|------|-------------|
| Id | uniqueidentifier | PK |
| UserId | uniqueidentifier | FK → Users(Id), NOT NULL |
| CategoryId | uniqueidentifier | FK → Categories(Id), NULL |
| Amount | decimal(18,2) | NOT NULL |
| Type | int | NOT NULL (0=Income, 1=Expense) |
| Description | nvarchar(500) | NULL |
| Date | datetime2 | NOT NULL |
| CreatedAt | datetime2 | NOT NULL |
| UpdatedAt | datetime2 | NOT NULL |

---

## 🔐 Authentication

### JWT Token Structure

**Claims**:
- `sub` (Subject): User ID
- `email`: User email
- `jti` (JWT ID): Unique token identifier
- `nameid` (NameIdentifier): User ID (for ASP.NET Core)

**Configuration**:
```json
{
  "JwtSettings": {
    "Secret": "your-secret-key-min-32-characters",
    "Issuer": "PersonalFinanceApp",
    "Audience": "PersonalFinanceApp",
    "ExpirationInMinutes": 60
  }
}
```

**Using the Token**:
```http
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

### Password Security
- **BCrypt Hashing**: Automatic salt generation
- **Password Requirements**: Min 8 chars, 1 uppercase, 1 lowercase, 1 digit
- **Validation**: Enforced in `RegisterUserCommandValidator`

---

## ✅ Validation

### FluentValidation Rules

**User Registration**:
- Email: Required, valid format, max 256 chars, unique
- Password: Min 8 chars, uppercase, lowercase, digit
- FirstName/LastName: Required, max 100 chars

**Category**:
- Name: Required, max 100 chars
- Type: Required, valid enum (Income/Expense)

**Transaction**:
- Amount: Required, > 0
- Type: Required, valid enum
- Date: Required
- Description: Max 500 chars (optional)
- CategoryId: Must exist and belong to user (if provided)
- **Business Rule**: Transaction type must match category type

### Validation Flow

```
API Request → MediatR → ValidationBehavior → Validators → Handler
                              ↓ (if invalid)
                        ValidationException
                              ↓
                   ExceptionHandlingMiddleware
                              ↓
                      400 Bad Request
```

---

## 🛡️ Error Handling

### Global Exception Middleware

All exceptions are caught and formatted consistently:

**Validation Error (400)**:
```json
{
  "success": false,
  "message": "One or more validation failures have occurred.",
  "errors": {
    "Email": ["Email already exists."],
    "Password": ["Password must contain at least one uppercase letter."]
  }
}
```

**Unauthorized (401)**:
```json
{
  "success": false,
  "message": "Invalid email or password.",
  "errors": null
}
```

**Not Found (404)**:
```json
{
  "success": false,
  "message": "Category with ID {id} not found.",
  "errors": null
}
```

**Internal Server Error (500)**:
```json
{
  "success": false,
  "message": "An internal server error occurred.",
  "errors": null
}
```

---

### Coding Standards
- Follow **Clean Architecture** principles
- Use **CQRS pattern** for new features
- Write **unit tests** for domain logic
- Add **XML documentation** for public APIs
- Follow **C# naming conventions**

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Author

**Petrika Manika**

---

## 📚 Additional Resources

- [Clean Architecture Documentation](docs/CleanArchitecture.md)
- [Authentication Implementation](docs/AuthenticationImplementation.md)
- [Category CRUD Guide](docs/CategoryCRUDImplementation.md)
- [Transaction Management](docs/TransactionCRUDImplementation.md)
- [API Documentation](https://localhost:7xxx/swagger) (when running)

---
