using System.Text.RegularExpressions;
using Business.Interfaces;
using Business.Services;

namespace Business.Services;

//Got some help from Claude to implement the regex correctly


public class ValidationService : IValidationService
{
    public bool ValidateFirstName(string firstName)
    {
        if (firstName?.ToLower() == "null" || string.IsNullOrWhiteSpace(firstName))
            return false;
        return Regex.IsMatch(firstName, @"^[A-Za-zÀ-ÖØ-öø-ÿ\s\-']{2,20}$");
    }

    public bool ValidateLastName(string lastName)
    {
        if (lastName?.ToLower() == "null" || string.IsNullOrWhiteSpace(lastName))
            return false;
        return Regex.IsMatch(lastName, @"^[A-Za-zÀ-ÖØ-öø-ÿ\s\-']{2,30}$");
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
