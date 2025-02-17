# Pizza Store API

A simple RESTful API for managing a pizza store's menu built with ASP.NET Core and Entity Framework Core.

## Technologies Used

- ASP.NET Core (.NET 9.0)
- Entity Framework Core with SQLite
- OpenAPI

## Prerequisites

- .NET 9.0 SDK or later
- A code editor (Visual Studio, VS Code, JetBrains Rider, etc.)

## Getting Started

### 1. Clone the Repository

```bash
git clone git@github.com:noel-srocha/PizzaStore.git
cd pizza-store
```

### 2. Database Setup

The project uses SQLite as its database. The connection string is configured to use `Pizzas.db` in the project root directory. The database will be created automatically when you run the application for the first time.

If you need to manually create/update the database, run the following commands:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 3. Build and Run

To build and run the project:

```bash
dotnet build
dotnet run
```

The API will start running on `http://localhost:5032"`.

## API Endpoints

The following endpoints are available:

- `GET /`: Hello World message
- `GET /pizzas`: Get all pizzas
- `GET /pizza/{id}`: Get a specific pizza by ID
- `POST /pizza`: Create a new pizza
- `PUT /pizza/{id}`: Update an existing pizza
- `DELETE /pizza/{id}`: Delete a pizza

### OpenAPI Documentation

When running in Development mode, OpenAPI documentation is available at:
- `/scalar` - Scalar API Reference

## Development

The project uses Entity Framework Core for database operations with a SQLite database. The database context is defined in `PizzaDb.cs`, and the connection string can be configured in `appsettings.json` or through environment variables.
