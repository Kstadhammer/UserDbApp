# Factories

Factories are like assembly lines for objects. They handle the complicated process of creating objects, especially when those objects need special setup or configuration.

## Real-World Examples:

### UserFactory

```csharp
public class UserFactory
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserValidator _userValidator;

    public UserFactory(IPasswordHasher passwordHasher, IUserValidator userValidator)
    {
        _passwordHasher = passwordHasher;
        _userValidator = userValidator;
    }

    public async Task<User> CreateUser(RegisterDTO dto)
    {
        // Validate input
        await _userValidator.ValidateNewUser(dto);

        // Create user with default values
        var user = new User
        {
            Email = dto.Email,
            Username = dto.Username,
            PasswordHash = _passwordHasher.HashPassword(dto.Password),
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        // Create associated profile
        user.Profile = new UserProfile
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            CreatedAt = DateTime.UtcNow
        };

        return user;
    }
}

// Example usage:
public class UserRegistrationService
{
    private readonly UserFactory _userFactory;
    private readonly IUserRepository _userRepository;

    public async Task<User> RegisterNewUser(RegisterDTO dto)
    {
        var user = await _userFactory.CreateUser(dto);
        await _userRepository.CreateAsync(user);
        return user;
    }
}
```

Factories are responsible for creating complex objects or groups of related objects. They encapsulate object creation logic.

Common factories in a User Database app:
- `UserFactory`: Creates user instances
- `DTOFactory`: Converts between models and DTOs
- `ServiceFactory`: Creates service instances
- `ConnectionFactory`: Creates database connections
- `LoggerFactory`: Creates logging instances

Best practices:
- Use factory methods for complex object creation
- Implement singleton pattern when appropriate
- Handle configuration in factories
- Follow dependency injection principles 