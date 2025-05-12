# Copilot Instructions

This solution includes an ASP.NET Core web API. The solution is built using C# and .NET 9.

## Coding Standards

### Naming Conventions
- Use PascalCase for class, interface, enum, property, and method names.
- Use camelCase for local variables and method parameters.
- Append “Async” to the names of asynchronous methods (e.g., FetchDataAsync).

### Asynchronous Programming
- Utilize async and await keywords for asynchronous operations.
- Return Task or ValueTask from asynchronous methods.
- Avoid blocking calls; refrain from using .Result or .Wait().
- Implement CancellationToken in methods that support cancellation.
- For asynchronous streams, use IAsyncEnumerable<T>.

### Language Features
- Leverage record structs for immutable data models to enhance performance.
- Utilize global using directives to simplify and reduce the number of using statements.
- Apply file-scoped namespace declarations for cleaner code structure.
- Use extended property patterns to simplify object property matching.
- Employ interpolated string handlers for efficient string interpolation.

### Code Style
- Use var when the type is evident; otherwise, specify the type explicitly.
- Organize using directives alphabetically and place them outside the namespace.
- Structure class members by grouping fields, constructors, properties, and methods together.
- For simple properties and methods, prefer expression-bodied members.
- Ensure methods are concise and adhere to the Single Responsibility Principle (SRP).

### Exception Handling
- Use try-catch blocks to handle exceptions and provide meaningful context.
- Avoid using exceptions for control flow; exceptions should represent truly exceptional conditions.
- Implement custom exception classes when specific exception handling is required.

### Performance Considerations
- Optimize data access by using asynchronous methods and retrieving only necessary data.
- Implement caching strategies to reduce unnecessary data retrieval.

### Security Practices:
- Validate all user inputs to prevent security vulnerabilities.

### Documentation:
- Provide XML documentation comments for public APIs and methods to facilitate code understanding.
