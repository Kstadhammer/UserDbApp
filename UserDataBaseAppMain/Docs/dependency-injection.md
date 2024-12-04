# Dependency Injection in C#

Dependency Injection (DI) is a design pattern that implements Inversion of Control (IoC) for resolving dependencies. It helps create loosely coupled code that is more maintainable and testable.

## Key Concepts

1. **Constructor Injection**: Dependencies are provided through a class constructor
2. **Property Injection**: Dependencies are provided through properties
3. **Method Injection**: Dependencies are provided through methods

## Example

```csharp
// Without Dependency Injection
public class UserService {
    private readonly DatabaseContext _database = new DatabaseContext(); // Tightly coupled

    public void SaveUser(User user) {
        _database.Users.Add(user);
        _database.SaveChanges();
    }
}

// With Dependency Injection
public class UserService {
    private readonly IDatabaseContext _database;

    // Constructor Injection
    public UserService(IDatabaseContext database) {
        _database = database;
    }

    public void SaveUser(User user) {
        _database.Users.Add(user);
        _database.SaveChanges();
    }
}
```

## Benefits

1. **Loose Coupling**: Classes are not directly dependent on their dependencies
2. **Easier Testing**: Mock objects can be injected for testing
3. **Flexibility**: Dependencies can be easily swapped
4. **Lifetime Management**: Better control over object lifetime

## Built-in DI Container in .NET

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Register services
    services.AddScoped<IUserService, UserService>();
    services.AddSingleton<IConfiguration>();
    services.AddTransient<IEmailService, EmailService>();
}
```

## Service Lifetimes

- **Transient**: Created each time they're requested
- **Scoped**: Created once per client request
- **Singleton**: Created once and reused for the lifetime of the application
