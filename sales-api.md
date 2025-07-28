# 🛠️ Developer Evaluation Project

## 📋 Overview

This project is a **Sales Management API** developed as part of a technical assessment. It leverages:

- ASP.NET Core 8
- Domain-Driven Design (DDD)
- Clean Code principles
- SOLID principles
- Best architectural practices

---

## ✅ Requirements

Before running the project, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)

---

## 🚀 Getting Started

Follow the steps below to set up and run the project locally:

### 1. Clone the Repository

```bash
git clone https://github.com/cafs3011/developer-evaluation-abi.git
cd developer-evaluation-sales/template/backend
```

### 2. Apply Database Migrations

```bash
dotnet ef database update --project src/Ambev.DeveloperEvaluation.ORM
```

> This command ensures that the database schema is up-to-date.

### 3. Run the API

```bash
dotnet run --project src/Ambev.DeveloperEvaluation.WebApi
```

Once the API is running, it will be available at:

- http://localhost:5000  
- https://localhost:5001  

Swagger UI will be available at `/swagger` for exploring and testing endpoints.

---

##  Features

The Sales API includes the following functionalities:

- Create a sale
- Retrieve a sale by ID
- List all sales
- Cancel a sale
- Automatically apply discounts based on quantity
- Track cancellation status (Cancelled / Not Cancelled)
- Emit domain events:
  - `SaleCreated`
  - `SaleCancelled`

---

##  Sale Fields

Each sale includes the following data:

- **Sale Number** (auto-generated)
- **Sale Date**
- **Customer**
- **Branch**
- **Total Amount** (calculated)
- **IsCancelled** (boolean)
- **Products**:
  - Quantity
  - Unit Price
  - Discount (auto-applied)
  - Total per item

---

##  Business Rules

The discount rules applied to products are:

| Quantity           | Discount     |
|--------------------|--------------|
| Less than 4        | No discount  |
| 4 to 9             | 10%          |
| 10 to 20           | 20%          |
| More than 20       | ❌ Not allowed |

---

##  Testing

To run unit tests:

```bash
dotnet test tests/Ambev.DeveloperEvaluation.Unit
```

> Integration and functional test structures are also included in the solution.

---

##  Project Structure

- **Domain**: Core entities, value objects, events, and interfaces  
- **Application**: Use cases, commands, handlers, and validators  
- **ORM**: EF Core DbContext, entity mappings, and repositories  
- **WebApi**: Controllers, DTOs, middleware, and mappings  
- **IoC**: Dependency injection configuration  
- **Tests**: Projects for unit, integration, and functional tests

---

##  License

This project uses the **MIT License** or the applicable license from your organization.
