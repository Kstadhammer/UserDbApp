using Business.Interfaces;
using Business.Models;
using Business.Models.DTOs;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs
{
    public class CreateUserDialog(IUserService userService, IValidationService validationService)
        : ICreateUserDialog
    {
        private readonly IValidationService _validationService = validationService;

        public void ShowDialog()
        {
            var userDto = new UserDto(); // Create a new UserDto object to store user information
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan; // Change console text color to Cyan
            Console.WriteLine("Welcome to the user creation interface\n");
            Console.ResetColor(); // Change console text color back to default

            // Ask for First Name and check if it's valid
            Console.Write("Enter First Name: ");
            userDto.FirstName = Console.ReadLine()!;
            while (!_validationService.ValidateFirstName(userDto.FirstName))
            {
                Console.WriteLine("First name must be between 2 and 20 characters.");
                Console.Write("Enter First Name: ");
                userDto.FirstName = Console.ReadLine()!;
            }

            // Ask for Last Name and check if it's valid
            Console.Write("Enter Last Name: ");
            userDto.LastName = Console.ReadLine()!;
            while (!_validationService.ValidateLastName(userDto.LastName))
            {
                Console.WriteLine("Last name must be between 2 and 30 characters.");
                Console.Write("Enter Last Name: ");
                userDto.LastName = Console.ReadLine()!;
            }

            // Ask for Email and check if it's valid
            Console.Write("Enter Email: ");
            userDto.Email = Console.ReadLine()!;
            while (!_validationService.ValidateEmail(userDto.Email))
            {
                Console.WriteLine("Please enter a valid email address.");
                Console.Write("Enter Email: ");
                userDto.Email = Console.ReadLine()!;
            }

            // Ask for Phone Number and check if it's valid
            Console.Write("Enter Phone Number: ");
            userDto.PhoneNumber = Console.ReadLine()!;
            while (!_validationService.ValidatePhoneNumber(userDto.PhoneNumber))
            {
                Console.WriteLine("Please enter a valid phone number.");
                Console.Write("Enter Phone Number: ");
                userDto.PhoneNumber = Console.ReadLine()!;
            }

            // Ask for Address and check if it's valid
            Console.Write("Enter Address: ");
            userDto.Address = Console.ReadLine()!;
            while (!_validationService.ValidateAddress(userDto.Address))
            {
                Console.WriteLine("Please enter a valid address.");
                Console.Write("Enter Address: ");
                userDto.Address = Console.ReadLine()!;
            }

            // Ask for Postal Code and check if it's valid
            Console.Write("Enter Postal Code: ");
            userDto.PostalCode = Console.ReadLine()!;
            while (!_validationService.ValidatePostalCode(userDto.PostalCode))
            {
                Console.WriteLine("Postal code must be 5 digits.");
                Console.Write("Enter Postal Code: ");
                userDto.PostalCode = Console.ReadLine()!;
            }

            // Ask for City and check if it's valid
            Console.Write("Enter City: ");
            userDto.City = Console.ReadLine()!;
            while (!_validationService.ValidateCity(userDto.City))
            {
                Console.WriteLine("Please enter a valid city name.");
                Console.Write("Enter City: ");
                userDto.City = Console.ReadLine()!;
            }

            userService.CreateUser(userDto); // Use the service to create the user
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green; // Change console text color to Green
            Console.WriteLine($"User: {userDto.FirstName} {userDto.LastName} created successfully");
            Console.ResetColor(); // Change console text color back to default
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(); // Wait for user to press a key before continuing
        }
    }
}
