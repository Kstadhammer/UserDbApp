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
            var userDto = new UserDto();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the create a user interface\n");
            Console.ResetColor();

            Console.Write("Enter First Name: ");
            userDto.FirstName = Console.ReadLine()!;
            while (!_validationService.ValidateFirstName(userDto.FirstName))
            {
                Console.WriteLine("First name must be between 2 and 20 characters.");
                Console.Write("Enter First Name: ");
                userDto.FirstName = Console.ReadLine()!;
            }

            Console.Write("Enter Last Name: ");
            userDto.LastName = Console.ReadLine()!;
            while (!_validationService.ValidateLastName(userDto.LastName))
            {
                Console.WriteLine("Last name must be between 2 and 30 characters.");
                Console.Write("Enter Last Name: ");
                userDto.LastName = Console.ReadLine()!;
            }

            Console.Write("Enter Email: ");
            userDto.Email = Console.ReadLine()!;
            while (!_validationService.ValidateEmail(userDto.Email))
            {
                Console.WriteLine("Please enter a valid email address.");
                Console.Write("Enter Email: ");
                userDto.Email = Console.ReadLine()!;
            }

            Console.Write("Enter Phone Number: ");
            userDto.PhoneNumber = Console.ReadLine()!;
            while (!_validationService.ValidatePhoneNumber(userDto.PhoneNumber))
            {
                Console.WriteLine("Please enter a valid phone number.");
                Console.Write("Enter Phone Number: ");
                userDto.PhoneNumber = Console.ReadLine()!;
            }

            Console.Write("Enter Address: ");
            userDto.Address = Console.ReadLine()!;
            while (!_validationService.ValidateAddress(userDto.Address))
            {
                Console.WriteLine("Please enter a valid address.");
                Console.Write("Enter Address: ");
                userDto.Address = Console.ReadLine()!;
            }

            Console.Write("Enter Postal Code: ");
            userDto.PostalCode = Console.ReadLine()!;
            while (!_validationService.ValidatePostalCode(userDto.PostalCode))
            {
                Console.WriteLine("Postal code must be 5 digits.");
                Console.Write("Enter Postal Code: ");
                userDto.PostalCode = Console.ReadLine()!;
            }

            Console.Write("Enter City: ");
            userDto.City = Console.ReadLine()!;
            while (!_validationService.ValidateCity(userDto.City))
            {
                Console.WriteLine("Please enter a valid city name.");
                Console.Write("Enter City: ");
                userDto.City = Console.ReadLine()!;
            }

            userService.CreateUser(userDto);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"User: {userDto.FirstName} {userDto.LastName} created successfully");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
