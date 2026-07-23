
# 📊 FinOps Core - Sistema de Gestão e Conciliação Financeira

> Aplicação corporativa desenvolvida para demonstrar padrões arquiteturais avançados, alta performance em consultas e integridade de dados financeiros.

Este projeto é um módulo financeiro focado em garantir a integridade do fluxo de caixa (Escrita) e entregar alta performance na leitura de dados para dashboards (Leitura), utilizando a segregação de responsabilidades.

## 🏗️ Arquitetura e Padrões de Projeto

O sistema foi desenhado utilizando **Clean Architecture (Arquitetura Limpa)** e os princípios do **Domain-Driven Design (DDD)** para garantir que o coração do software seja isolado de frameworks e tecnologias de infraestrutura.

Para atender aos requisitos de alta performance e integridade, foi implementado o padrão **CQRS (Command Query Responsibility Segregation)**:

*   **Commands (Escrita):** Utiliza **Entity Framework Core** com o padrão *Unit of Work*. As operações de mudança de estado passam por validações rigorosas nas Entidades de Domínio (Rich Models), garantindo propriedades ACID e lidando com concorrência otimista (Optimistic Concurrency) no banco de dados.
*   **Queries (Leitura):** Utiliza **Dapper** executando consultas SQL nativas e otimizadas diretamente no banco, mapeando os resultados para DTOs leves. Isso ignora o overhead de tracking do ORM tradicional em relatórios pesados.

Outros padrões aplicados:
*   **Mediator Pattern (via MediatR):** Desacoplamento dos Controllers da API das regras de negócio.
*   **Result Pattern:** Retorno de estados de Sucesso/Falha sem depender do custoso lançamento de exceções (`throw`) para quebras de regras de negócio.
*   **Idempotência e Resiliência:** Proteção contra dupla submissão de requisições financeiras.

---

## 🚀 Tecnologias Utilizadas

### Backend
*   .NET Core (C#)
*   Entity Framework Core (Commands / Migrations)
*   Dapper (Queries de alta performance)
*   LINQ
*   MediatR & FluentValidation
*   xUnit / Moq (Testes Unitários)

### Frontend
*   Angular (SPA, TypeScript, SCSS)
*   RxJS (Programação Reativa)
*   Interceptors (Tratamento global de erros e Autenticação)

### Banco de Dados & Infraestrutura
*   Oracle Database (Relacional)
*   Docker & Docker Compose
*   Kubernetes (Manifestos K8s disponíveis na pasta `/k8s`)
*   GitHub Actions (CI/CD)

---

## 📂 Estrutura do Projeto

A solution do Backend está dividida seguindo a Regra da Dependência:

```text
/src
 ├── /FinancialSystem.Domain       # Entidades, Value Objects e Regras de Negócio Puras (Sem dependências externas)
 ├── /FinancialSystem.Application  # Casos de Uso, CQRS (Commands/Queries), DTOs e Validações
 ├── /FinancialSystem.Infrastructure # EF Core (DbContext, Mapeamentos), Dapper, Integrações externas
 ├── /FinancialSystem.API          # Controllers RESTful, Swagger, Configurações de Injeção de Dependência
/frontend
 ├── /financial-app                # Aplicação Angular
/k8s                               # Manifestos de Deployment do Kubernetes

```

---

## ⚙️ Como Executar o Projeto Localmente

### Pré-requisitos

* [Docker Desktop](https://www.docker.com/products/docker-desktop/)
* [.NET SDK](https://dotnet.microsoft.com/download)
* [Node.js](https://nodejs.org/) & Angular CLI (`npm install -g @angular/cli`)

### Passo a Passo

1. **Clone o repositório:**
```bash
git clone [https://github.com/seu-usuario/finops-core.git](https://github.com/seu-usuario/finops-core.git)
cd finops-core

```


2. **Suba o Banco de Dados (Oracle):**
Na raiz do projeto, execute o Docker Compose para subir a instância do banco de dados:
```bash
docker-compose up -d db

```


*Nota: A imagem do Oracle XE pode demorar cerca de 1 a 2 minutos para inicializar completamente na primeira execução.*
3. **Execute as Migrations e Inicie a API:**
```bash
cd src/FinancialSystem.API
dotnet ef database update
dotnet run

```


A API estará disponível em `https://localhost:5001`. O Swagger pode ser acessado em `https://localhost:5001/swagger`.
4. **Inicie o Frontend Angular:**
Em um novo terminal, navegue até a pasta do frontend:
```bash
cd frontend/financial-app
npm install
ng serve

```


Acesse a aplicação no navegador via `http://localhost:4200`.

---

## 🧪 Rodando os Testes

Para garantir a qualidade e as regras de negócio, o projeto conta com testes de unidade na camada de domínio e aplicação.

```bash
cd src
dotnet test

```

---

## 👨‍💻 Autor

**[Seu Nome]**

* LinkedIn: [Seu Link]
* Portfólio: [Seu Link]

*Projeto desenvolvido para fins de estudo e demonstração técnica de arquitetura de software.*

```

```
