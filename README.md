# reference-api
A Web API solution for reference.

[![Pull Request Validation](https://github.com/tlatkovich/reference-api/actions/workflows/pr-validation.yml/badge.svg)](https://github.com/tlatkovich/reference-api/actions/workflows/pr-validation.yml)
[![Scan Code with CodeQL](https://github.com/tlatkovich/reference-api/actions/workflows/codeql.yml/badge.svg)](https://github.com/tlatkovich/reference-api/actions/workflows/codeql.yml)

## Architecture Principles & Practices

- Clean Architecture: Enforced by architecture tests to ensure proper separation between Domain, Infrastructure, and API layers.
- Domain-Driven Design (DDD): Domain logic is isolated in the Core project.
- Layered Solution Structure: Projects for API, Core, Infrastructure, Migration, and Service Defaults.
- Asynchronous Programming: Async/await, Task-based APIs, and cancellation support.
- Immutability: Use of record structs for immutable data models.
- Global Usings: Simplifies and reduces using statements.
- File-Scoped Namespaces: Cleaner code structure.
- Extended Property Patterns: For concise property matching.
- Interpolated String Handlers: For efficient string interpolation.
- Exception Handling: Try-catch with meaningful context, custom exceptions as needed.
- Caching: Hybrid and Redis caching for performance.
- Security: Input validation and JWT authentication.
- XML Documentation: Public APIs and methods are documented.
- Testing: xUnit, Shouldly, Moq, and architecture tests (NetArchTest.Rules).
- OpenTelemetry: Distributed tracing and metrics.

## Technologies & Libraries Used

- **.NET 9** (net9.0)
- **ASP.NET Core** (Web API)
- **FastEndpoints** (API endpoint framework)
- **FastEndpoints.Swagger** (OpenAPI/Swagger integration)
- **Microsoft.AspNetCore.OpenApi** (OpenAPI support)
- **Entity Framework Core** (Data access)
- **Microsoft.EntityFrameworkCore.SqlServer** (SQL Server provider)
- **Ardalis.GuardClauses** (Guard clauses for validation)
- **Ardalis.Specification** (Repository pattern/specification)
- **FluentValidation** (Validation)
- **MediatR** (CQRS/Mediator pattern)
- **Microsoft.Identity.Web** (Authentication)
- **Microsoft.Extensions.Caching.Hybrid** (Hybrid caching)
- **Microsoft.Extensions.Caching.StackExchangeRedis** (Redis caching)
- **Azure.Identity** (Azure authentication)
- **OpenTelemetry** (Tracing, metrics)
- **Testcontainers** (Integration testing with containers)
- **xUnit** (Unit testing)
- **Shouldly** (Assertions)
- **Moq** (Mocking)
- **NetArchTest.Rules** (Architecture tests)
- **Microsoft.NET.Test.Sdk** (Test runner)
- **Aspire** (Service defaults, migration, resilience)
