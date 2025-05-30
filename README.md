# reference-api
A Web API solution for reference.

[![Pull Request Validation](https://github.com/tlatkovich/reference-api/actions/workflows/pr-validation.yml/badge.svg)](https://github.com/tlatkovich/reference-api/actions/workflows/pr-validation.yml)
[![Scan Code with CodeQL](https://github.com/tlatkovich/reference-api/actions/workflows/codeql.yml/badge.svg)](https://github.com/tlatkovich/reference-api/actions/workflows/codeql.yml)

## Architecture Principles & Practices

- Clean Architecture: Ensures all dependencies point inward toward the Domain layer, maintaining clear separation from Infrastructure and API layers through separate projects and architecture tests.
- Domain-Driven Design (DDD): Isolates domain logic within the Core project and emphasizes the use of AggregateRoot entities to encapsulate domain behavior and enforce invariants within a consistent boundary.
- Request-Endpoint-Response Pattern (REPR): Structures each API endpoint with a request, endpoint, and response component.
- Vertical Slice Architecture: Encapsulates each API endpoint in its own folder, containing all related files (request, endpoint, validation, mapping, response).
- .NET Aspire: Enables running and connecting multi-project applications, container resources, and dependencies for local development.
- Development Containers: Provides a fully featured, pre-configured Docker environment for .NET/SQL development.
- Asynchronous Programming: Utilizes async/await, Task-based APIs, and supports cancellation.
- Immutability: Implements record structs for immutable data transfer objects (DTOs).
- Global Usings: Reduces and simplifies using statements.
- File-Scoped Namespaces: Promotes a cleaner code structure.
- Value Objects: Encapsulates domain data without identity or behavior.
- Guards Clauses: Validates method parameters and properties.
- Specification Pattern: Implements the repository pattern with specifications for querying data.
- Caching: Implements a write-through caching strategy, combining in-memory and Redis caches to ensure data consistency and optimal performance.
- Eventing and Messaging: Employs MediatR for domain and integration events.
- Security: Ensures input validation and JWT authentication.
- Testing: Automates testing for domain, infrastructure, and API layers as well as architecture principles.
- OpenTelemetry: Provides distributed tracing and metrics.
- API Documentation: Utilizes OpenAPI for automatic generation of API documentation.
- GitHub Copilot: Implements instructional comments for code generation.
- GitHub Advanced Security: Implements CodeQL for static code analysis and dependabot for security vulnerability detection.
- GitHub Actions: Automates CI/CD processes, including build, test, and deployment.
- EditorConfig: Maintain consistent coding styles across various editors and IDEs.

## Notable Technologies & Libraries Used

### Development
- **Devevelopment Containers** (Development environment)
- **.NET Aspire** (Orchestration, service discovery, migrations)
- **OpenTelemetry** (Tracing, metrics)
- **Docker** (Containerization)
- **GitHub Security** (CodeQL, Dependabot)
- **GitHub Actions** (CI/CD)
- **GitHub Copilot** (Code generation)
- **EditorConfig** (Code style consistency)

### Domain
- **.NET 9** (C# 13)
- **FluentValidation** (Validation)
- **Ardalis.GuardClauses** (Guard clauses for validation)

### Web API
- **ASP.NET Core** (Web API)
- **Fast Endpoints** (API endpoint framework)
- **OpenApi** (API documentation)

### Infrastructure
- **Entity Framework Core** (Data access)
- **Ardalis.Specification** (Repository pattern/specification)
- **Microsoft.EntityFrameworkCore.SqlServer** (SQL Server provider)
- **Microsoft.Extensions.Caching.Hybrid** (Hybrid caching)
- **Microsoft.Extensions.Caching.StackExchangeRedis** (Redis caching)
- **Azure.Identity** (Azure authentication)
- **Microsoft.Identity.Web** (Authentication)
- **MediatR** (CQRS/Mediator pattern)

### Testing
- **xUnit** (Unit testing)
- **Moq** (Mocking)
- **Shouldly** (Assertions)
- **Testcontainers** (Infrastructure testing with containers)
- **NetArchTest.Rules** (Architecture tests)

## Development Containers

This solution includes a fully configured [Development Container](https://containers.dev/) for a consistent and productive development environment. The dev container leverages Docker and VS Code Dev Containers to provide all necessary tools and dependencies for .NET 9 and SQL Server development.

**Key Features:**
- **Base Image:** Uses `mcr.microsoft.com/devcontainers/dotnet:9.0-bookworm` for .NET 9.
- **Pre-installed Features:**
  - Docker-in-Docker (for running containers inside the dev container)
  - PowerShell
  - Azure CLI
- **VS Code Extensions:** Automatically installs recommended extensions for .NET, Azure, Docker, GitHub Copilot, GitHub Actions, EditorConfig, and more.
- **Automated Setup Commands:**
  - Updates and installs .NET workloads and tools (including Aspire and Entity Framework Core tools)
  - Restores NuGet packages and pulls the latest SQL Server container image
  - Trusts HTTPS development certificates
- **Volume Mounts:**
  - Mounts Azure and .NET user secrets directories for secure local development
- **Environment Variables:**
  - Configures `DOTNET_USER_SECRETS` for secret management

**Getting Started:**
1. Open the repo in VS Code.
2. When prompted, select the appropriate dev container configuration for your platform:
   - **macOS/Linux:** Choose `.devcontainer/macOS/devcontainer.json`
   - **Windows:** Choose `.devcontainer/Windows/devcontainer.json`
3. The container will build and initialize automatically, installing all dependencies and extensions.
4. You can now build, run, and debug the solution in a consistent, isolated environment.

For more details, see the `.devcontainer` folder and configuration files for both macOS and Windows setups.
