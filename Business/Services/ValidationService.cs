using System.Text.RegularExpressions;
using Business.Interfaces;
using Business.Services;

namespace Business.Services;

//Got some help from Claude to implement the regex correctly


public class ValidationService : IValidationService
{
    public bool ValidateFirstName(string firstName)
    {
        return !string.IsNullOrWhiteSpace(firstName)
            && Regex.IsMatch(firstName, @"^[A-Za-z]{1,20}$");
    }

    public bool ValidateLastName(string lastName)
    {
        return !string.IsNullOrWhiteSpace(lastName) && Regex.IsMatch(lastName, @"^[A-Za-z]{1,30}$");
    }

    public bool ValidateEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
    }

    public bool ValidatePhoneNumber(string phoneNumber)
    {
        return Regex.IsMatch(phoneNumber, @"^\+?(\d[\s-.]?){10,14}$");
    }

    public bool ValidateAddress(string address)
    {
        return !string.IsNullOrWhiteSpace(address) && Regex.IsMatch(address, @"^[\w\s,.]+$");
    }

    public bool ValidatePostalCode(string postalCode)
    {
        return Regex.IsMatch(postalCode, @"^\d{5}$");
    }

    public bool ValidateCity(string city)
    {
        return !string.IsNullOrWhiteSpace(city) && Regex.IsMatch(city, @"^[A-Za-z\s]+$");
    }
}
