# Mansour Accounting

Custom accounting application built around the actual workflow and requirements of the business.

## Architecture

The project is split into separate layers, each with a specific responsibility:

```text
Domain
→ Models/entities + core business rules

Application
→ Use cases/functions + business operation logic

Infrastructure
→ Database + EF Core + migrations + external implementations

API
→ HTTP endpoints that call Application functions

Desktop
→ User interface (MAUI, WPF, or another desktop framework)
```

### Project Structure

```text
MansourAccounting
│
├── Accounting.Api
├── Accounting.Application
├── Accounting.Domain
├── Accounting.Infrastructure
└── Accounting.Desktop    # Added later for the UI
```

### Request Flow

```text
Desktop
   ↓
API endpoint
   ↓
Application function
   ↓
Domain rules
   ↓
Infrastructure
   ↓
PostgreSQL
```

### Layer Responsibilities

#### `Accounting.Domain`

Contains the core of the accounting system:

* Models/entities
* Core business rules
* Domain-specific logic

The Domain should not depend on the database, API, or UI.

#### `Accounting.Application`

Contains the operations the system can perform:

* Create records
* Edit records
* Delete records
* Search/filter records
* Calculate balances
* Other accounting use cases

It coordinates the Domain and Infrastructure.

#### `Accounting.Infrastructure`

Handles communication with external systems:

* PostgreSQL
* Entity Framework Core
* Database configuration
* Migrations
* Repositories/data access
* External services if needed

#### `Accounting.Api`

Provides the backend's HTTP API.

Its main responsibility is to:

1. Receive HTTP requests.
2. Validate/request-map input.
3. Call the appropriate Application function.
4. Return the result.

The API should not contain the actual accounting business logic.

#### `Accounting.Desktop`

The user interface, to be added after the backend is ready.

Possible technologies include:

* .NET MAUI
* WPF

The UI communicates with the backend through the API rather than directly accessing PostgreSQL.

---

# Development Environment

## PostgreSQL

PostgreSQL runs inside Docker during development.

Docker configuration:

```text
Container: mansour-accounting-db
Database:  mansour_accounting
```

The database uses a persistent Docker volume so that stopping/removing the container does not normally delete the database data.

---

# Starting the Project

## 1. Start Docker Desktop

Make sure Docker Desktop is running before starting PostgreSQL.

## 2. Start PostgreSQL

From the project root, where `docker-compose.yml` is located:

```bash
docker compose up -d
```

Check that the database container is running:

```bash
docker compose ps
```

The PostgreSQL container should show as running.

## 3. Start the API

Open another terminal in the project root:

```bash
dotnet run --project src/Accounting.Api
```

The API will start on the configured HTTP/HTTPS port.

## 4. Stop the project

The API can be stopped with:

```text
Ctrl + C
```

PostgreSQL can be stopped with:

```bash
docker compose down
```

The database data is preserved in the Docker volume.

---

# Database Development

Entity Framework Core is used to manage the database.

The general process is:

```text
C# Entity/Model
      ↓
Entity Framework Core
      ↓
Migration
      ↓
PostgreSQL Database
```

When models change, create a migration and apply it:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

Migrations are committed to Git so that the database structure can be reproduced on other development machines.

---

# Current Accounting Concept

The application currently has two currencies:

* USD
* LBP

Exchange rates can change over time.

Each financial record stores the exchange rate applicable when the record was created so that historical records are not affected by future rate changes.

The current record concept is:

```text
Record
├── Date
├── Name
├── Type              # To be determined
├── Description/Note
├── Amount
├── Credit/Debit
├── Currency
└── Exchange Rate
```

The exact database structure and meaning of fields such as `Type` and `Account` will be finalized after reviewing the actual workflow and requirements with the business owner.
