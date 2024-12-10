using System.ComponentModel.DataAnnotations;

namespace Business.Models.DTOs;

public class UserDto
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(
        20,
        MinimumLength = 2,
        ErrorMessage = "First name must be between 2 and 20 characters"
    )]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(
        30,
        MinimumLength = 2,
        ErrorMessage = "Last name must be between 2 and 30 characters"
    )]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "Postal code is required")]
    [RegularExpression(@"^\d{5}$", ErrorMessage = "Postal code must be 5 digits")]
    public string PostalCode { get; set; } = null!;

    [Required(ErrorMessage = "City is required")]
    public string City { get; set; } = null!;
}
