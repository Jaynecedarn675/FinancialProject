# 📊 FinOps Core - Financial Management and Reconciliation System

<p align="center">

![.NET](https://img.shields.io/badge/.NET-8-512BD4?style=for-the-badge&logo=dotnet)
![C%23](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp)
![Angular](https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular)
![Oracle](https://img.shields.io/badge/Oracle-F80000?style=for-the-badge&logo=oracle)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-6DB33F?style=for-the-badge)
![Dapper](https://img.shields.io/badge/Dapper-00599C?style=for-the-badge)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker)
![Kubernetes](https://img.shields.io/badge/Kubernetes-326CE5?style=for-the-badge&logo=kubernetes)
![GitHub Actions](https://img.shields.io/badge/GitHub_Actions-2088FF?style=for-the-badge&logo=githubactions)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

</p>

<p align="center">

![Architecture](https://img.shields.io/badge/Clean%20Architecture-✓-0A66C2?style=flat-square)
![DDD](https://img.shields.io/badge/DDD-Domain--Driven%20Design-orange?style=flat-square)
![CQRS](https://img.shields.io/badge/CQRS-Command%20%2F%20Query-blue?style=flat-square)
![MediatR](https://img.shields.io/badge/MediatR-Pattern-purple?style=flat-square)
![Result Pattern](https://img.shields.io/badge/Result-Pattern-success?style=flat-square)
![Unit of Work](https://img.shields.io/badge/Unit%20of%20Work-Pattern-lightgrey?style=flat-square)

</p>

> Corporate application developed to demonstrate advanced architectural patterns, financial data integrity, and high-performance read operations using CQRS.

---

# 🏛️ Architecture

The solution follows **Clean Architecture** and **Domain-Driven Design (DDD)**, keeping business rules completely isolated from infrastructure and frameworks.

To support scalability and high throughput, the application adopts **CQRS (Command Query Responsibility Segregation)**.

## ✍️ Command Side (Write)

- Entity Framework Core
- Unit of Work
- Rich Domain Model
- Optimistic Concurrency
- ACID Transactions
- FluentValidation
- MediatR

Business operations pass through the domain layer, ensuring consistency and protecting financial transactions.

---

## 📖 Query Side (Read)

- Dapper
- Native SQL
- Lightweight DTOs
- Optimized Queries

Read operations bypass ORM tracking, delivering significantly faster dashboard and reporting performance.

---

## 🧩 Design Patterns

| Pattern | Purpose |
|----------|----------|
| ✅ Clean Architecture | Separation of concerns |
| ✅ Domain-Driven Design | Rich business domain |
| ✅ CQRS | Read/Write segregation |
| ✅ Unit of Work | Transaction management |
| ✅ Repository Pattern | Persistence abstraction |
| ✅ MediatR | Decoupled application layer |
| ✅ Result Pattern | Business validation without exceptions |
| ✅ Dependency Injection | Loose coupling |
| ✅ Idempotency | Prevent duplicate financial requests |

---

# 🚀 Tech Stack

## Backend

| Technology | Description |
|------------|-------------|
| .NET 8 | Backend |
| C# | Programming Language |
| Entity Framework Core | Commands |
| Dapper | High-performance Queries |
| MediatR | CQRS |
| FluentValidation | Validation |
| LINQ | Data Manipulation |
| xUnit | Unit Tests |
| Moq | Mocking |

---

## Frontend

| Technology | Description |
|------------|-------------|
| Angular | SPA |
| TypeScript | Language |
| SCSS | Styling |
| RxJS | Reactive Programming |
| HTTP Interceptors | Authentication & Error Handling |

---

## Infrastructure

| Technology | Description |
|------------|-------------|
| Oracle Database | Relational Database |
| Docker | Containers |
| Docker Compose | Local Environment |
| Kubernetes | Deployment |
| GitHub Actions | CI/CD |

---

# 📂 Project Structure

```text
src
├── FinancialSystem.Domain
│   ├── Entities
│   ├── ValueObjects
│   ├── Enums
│   ├── Events
│   └── Interfaces
│
├── FinancialSystem.Application
│   ├── Commands
│   ├── Queries
│   ├── DTOs
│   ├── Validators
│   └── Behaviors
│
├── FinancialSystem.Infrastructure
│   ├── Persistence
│   ├── Dapper
│   ├── Repositories
│   └── Services
│
└── FinancialSystem.API
    ├── Controllers
    ├── Middleware
    ├── Filters
    └── Configuration

frontend
└── financial-app

k8s
└── deployment
```

---

# ⚡ Running Locally

## Requirements

- Docker Desktop
- .NET SDK 8
- Node.js
- Angular CLI

---

### Clone Repository

```bash
git clone https://github.com/your-user/finops-core.git

cd finops-core
```

---

### Start Oracle

```bash
docker compose up -d db
```

---

### Apply Migrations

```bash
cd src/FinancialSystem.API

dotnet ef database update

dotnet run
```

Swagger

```
https://localhost:5001/swagger
```

---

### Angular

```bash
cd frontend/financial-app

npm install

ng serve
```

```
http://localhost:4200
```

---

# 🧪 Tests

```bash
cd src

dotnet test
```

---

# 📈 Main Features

- Financial Reconciliation
- Cash Flow Management
- CQRS Architecture
- Dashboard Queries
- High Performance Reads
- Rich Domain Validation
- Transaction Management
- Optimistic Concurrency
- Idempotent Requests
- Unit Testing

---

# 👨‍💻 Author

**Gabriel Campos**

[![GitHub](https://img.shields.io/badge/GitHub-gabrielcamposdeveloper-181717?style=for-the-badge&logo=github)](https://github.com/gabrielcamposdeveloper)

---

# 📄 License

![MIT](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

Licensed under the MIT License.
