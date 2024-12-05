using Business.Models;
using Business.Services;

namespace Business.Interfaces;

public interface IValidationService
{
    bool ValidateFirstName(string firstName);
    bool ValidateLastName(string lastName);
    bool ValidateEmail(string email);
    bool ValidatePhoneNumber(string phoneNumber);
    bool ValidateAddress(string address);
    bool ValidatePostalCode(string postalCode);
    bool ValidateCity(string city);
}
