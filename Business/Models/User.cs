using System;

namespace Business.Models;

public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string TimeCreated { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
