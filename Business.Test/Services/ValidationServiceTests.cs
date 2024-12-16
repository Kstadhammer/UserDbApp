using System.Text.Json;
using Business.Interfaces;
using Business.Models;
using Business.Models.DTOs;
using Business.Services;
using Microsoft.VisualBasic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

// i had alot of troubleshooting with the regex, but i got it to work
// i got some help from Claude to implement the regex correctly

//testing for the validation service using xunit and moq
namespace Business.Test.Services
{
    public class ValidationServiceTests
    {
        private readonly IValidationService _validationService;

        public ValidationServiceTests()
        {
            _validationService = new ValidationService();
        }

        [Theory]
        [InlineData("Kim", true)]
        [InlineData("K", false)]
        [InlineData("", false)]
        [InlineData("null", false)]
        public void ValidateFirstName_ShouldReturnTrueIfFirstNameIsValid(
            string firstName,
            bool expected
        )
        {
            // Act
            var result = _validationService.ValidateFirstName(firstName);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Hammerstad", true)]
        [InlineData("H", false)]
        [InlineData("", false)]
        [InlineData("null", false)]
        public void ValidateLastName_ShouldReturnTrueIfLastNameIsValid(
            string lastName,
            bool expected
        )
        {
            // Act
            var result = _validationService.ValidateLastName(lastName);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("kim.hammerstad@gmail.com", true)]
        [InlineData("mail-invalid@gmailcom", false)]
        [InlineData("", false)]
        [InlineData("null", false)]
        public void ValidateEmail_ShouldReturnTrueIfEmailIsValid(string email, bool expected)
        {
            // Act
            var result = _validationService.ValidateEmail(email);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("0793543210", true)]
        [InlineData("079354321", false)]
        [InlineData("", false)]
        [InlineData("null", false)]
        public void ValidatePhoneNumber_ShouldReturnTrueIfPhoneNumberIsValid(
            string phoneNumber,
            bool expected
        )
        {
            // Act
            var result = _validationService.ValidatePhoneNumber(phoneNumber);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
