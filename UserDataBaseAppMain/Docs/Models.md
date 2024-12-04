# Models

Models are like blueprints for your data. They represent real things in your application (users, products, orders) and include both the data and rules about that data.

## Real-World Examples:

### User Model

```csharp
public class User
{
    public int Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    // Navigation properties
    public UserProfile Profile { get; set; }
    public List<UserRole> Roles { get; private set; } = new();

    public void UpdateUsername(string newUsername)
    {
        if (string.IsNullOrEmpty(newUsername))
            throw new ArgumentException("Username cannot be empty");
            
        Username = newUsername;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public bool HasRole(string roleName)
    {
        return Roles.Any(r => r.Name == roleName);
    }
}

public class UserProfile
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Address { get; set; }
    
    // Navigation property back to User
    public User User { get; set; }
}
```

Models represent the domain entities of the application. They are the core business objects that contain both data and behavior.

Essential models for a User Database app:
- `User`: Core user entity
- `UserProfile`: Detailed user information
- `Role`: User roles and permissions
- `Audit`: Tracking changes
- `Session`: User session information

Best practices:
- Include data validation
- Implement proper encapsulation
- Use navigation properties for relationships
- Keep business rules in models 