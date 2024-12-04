# DTOs (Data Transfer Objects)

Think of DTOs as forms that users fill out. They only contain the exact information needed for a specific operation - no extra fields, no business logic.

## Real-World Examples:

### RegisterDTO

```csharp
public class RegisterDTO
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, MinimumLength = 3)]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "Passwords don't match")]
    public string ConfirmPassword { get; set; }
}

public class UserDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<string> Roles { get; set; }
    // Note: Sensitive data like password is excluded
}
```

DTOs are objects used to transfer data between processes or layers of the application. They help in decoupling the data structure from the domain models.

Common DTOs in a User Database app:
- `UserDTO`: User data for client communication
- `LoginDTO`: Login credentials
- `RegisterDTO`: Registration data
- `UserProfileDTO`: User profile information
- `ResponseDTO`: Standardized API responses

Best practices:
- Keep DTOs simple and flat
- Use only necessary properties
- Include data validation attributes
- Avoid business logic 