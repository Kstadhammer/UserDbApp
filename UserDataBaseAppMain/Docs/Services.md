# Services

Services are like the workers of your application. They handle specific tasks and business operations. Think of them as different departments in a company.

## Real-World Examples:

### UserService

```csharp
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public UserService(IUserRepository userRepository, IEmailService emailService)
    {
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task<User> RegisterUser(RegisterDTO dto)
    {
        // Validate input
        if (await _userRepository.EmailExists(dto.Email))
            throw new BusinessException("Email already registered");

        // Create user
        var user = new User
        {
            Email = dto.Email,
            Username = dto.Username,
            PasswordHash = HashingHelper.HashPassword(dto.Password)
        };

        // Save user
        await _userRepository.Create(user);
        
        // Send welcome email
        await _emailService.SendWelcomeEmail(user.Email);
        
        return user;
    }
}
```

Services handle the business logic of the application. They orchestrate the flow of data between different layers and implement the core functionality.

Key services for a User Database app:
- `UserService`: User management (create, update, delete)
- `AuthenticationService`: Login, logout, session management
- `ValidationService`: Complex validation logic
- `EmailService`: Email notifications
- `LoggingService`: Application logging

Best practices:
- Follow interface-based design
- Implement dependency injection
- Keep services focused on specific business domains
- Handle error management and logging 