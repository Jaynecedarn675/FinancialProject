
# 📊 FinOps Core - Financial Management and Reconciliation System

> Corporate application developed to demonstrate advanced architectural patterns, high query performance and financial data integrity.

This project is a financial module focused on ensuring cash flow integrity (Write) and delivering high performance in data reading for dashboards (Read), using segregation of responsibilities.

## 🏗️ Architecture and Design Patterns

The system was designed using **Clean Architecture** and the principles of **Domain-Driven Design (DDD)** to ensure that the software core is isolated from frameworks and infrastructure technologies.

To meet high performance and integrity requirements, the **CQRS (Command Query Responsibility Segregation)** pattern was implemented:

*   **Commands (Write):** Uses **Entity Framework Core** with the *Unit of Work* pattern. State-changing operations go through strict validations in Domain Entities (Rich Models), ensuring ACID properties and handling optimistic concurrency in the database.
*   **Queries (Read):** Uses **Dapper** executing native and optimized SQL queries directly in the database, mapping results to lightweight DTOs. This avoids the overhead of traditional ORM tracking in heavy reporting.

Other applied patterns:
*   **Mediator Pattern (via MediatR):** Decouples API Controllers from business rules.
*   **Result Pattern:** Returns Success/Failure states without relying on expensive exception throwing for business rule violations.
*   **Idempotency and Resilience:** Protection against duplicate submission of financial requests.

---

## 🚀 Technologies Used

### Backend
*   .NET Core (C#)
*   Entity Framework Core (Commands / Migrations)
*   Dapper (High performance Queries)
*   LINQ
*   MediatR & FluentValidation
*   xUnit / Moq (Unit Tests)

### Frontend
*   Angular (SPA, TypeScript, SCSS)
*   RxJS (Reactive Programming)
*   Interceptors (Global error handling and Authentication)

### Database & Infrastructure
*   Oracle Database (Relational)
*   Docker & Docker Compose
*   Kubernetes (K8s manifests available in `/k8s`)
*   GitHub Actions (CI/CD)

---

## 📂 Project Structure

The backend solution is divided following the Dependency Rule:

```text
/src
 ├── /FinancialSystem.Domain       # Entities, Value Objects and Pure Business Rules (No external dependencies)
 ├── /FinancialSystem.Application  # Use Cases, CQRS (Commands/Queries), DTOs and Validations
 ├── /FinancialSystem.Infrastructure # EF Core (DbContext, Mappings), Dapper, External integrations
 ├── /FinancialSystem.API          # RESTful Controllers, Swagger, Dependency Injection configuration
/frontend
 ├── /financial-app                # Angular Application
/k8s                               # Kubernetes Deployment manifests

```

---

## ⚙️ How to Run the Project Locally

### Prerequisites

* [Docker Desktop](https://www.docker.com/products/docker-desktop/)
* [.NET SDK](https://dotnet.microsoft.com/download)
* [Node.js](https://nodejs.org/) & Angular CLI (`npm install -g @angular/cli`)

### Step by Step

1. **Clone the repository:**
```bash
git clone [https://github.com/seu-usuario/finops-core.git](https://github.com/seu-usuario/finops-core.git)
cd finops-core

```

2. **Start the Database (Oracle):**
At the project root, run Docker Compose to start the database instance:
```bash
docker-compose up -d db

```

*Note: The Oracle XE image may take about 1 to 2 minutes to fully initialize on the first run.*
3. **Run the Migrations and Start the API:**
```bash
cd src/FinancialSystem.API
dotnet ef database update
dotnet run

```

The API will be available at `https://localhost:5001`. Swagger can be accessed at `https://localhost:5001/swagger`.
4. **Start the Angular Frontend:**
In a new terminal, navigate to the frontend folder:
```bash
cd frontend/financial-app
npm install
ng serve

```

Access the application in the browser at `http://localhost:4200`.

---

## 🧪 Running the Tests

To ensure quality and business rules, the project includes unit tests in the domain and application layers.

```bash
cd src
dotnet test

```

---

## 👨‍💻 Author

Created and maintained by **Gabriel Campos**

🐙 GitHub: **[gabrielcamposdeveloper](https://github.com/gabrielcamposdeveloper)**

Feel free to explore my other repositories and connect with me.

---

## 📄 License

This project is licensed under the **MIT License**.

