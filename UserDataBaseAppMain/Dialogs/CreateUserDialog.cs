using Business.Interfaces;
using Business.Models;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs
{
    public class CreateUserDialog(IUserService userService, IValidationService validationService)
        : ICreateUserDialog
    {
        private readonly IValidationService _validationService = validationService;

        public void ShowDialog()
        {
            var user = new User();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the create a user interface\n");
            Console.ResetColor();

            Console.Write("Enter the user's first name: ");
            user.FirstName = Console.ReadLine()!;
            while (!_validationService.ValidateFirstName(user.FirstName))
            {
                Console.WriteLine("Invalid first name. Please try again.");
                user.FirstName = Console.ReadLine()!;
            }
            Console.Write("Enter the user's last name: ");
            user.LastName = Console.ReadLine()!;
            while (!_validationService.ValidateLastName(user.LastName))
            {
                Console.WriteLine("Invalid last name. Please try again.");
                user.LastName = Console.ReadLine()!;
            }
            Console.Write("Enter the user's email: ");
            user.Email = Console.ReadLine()!;
            while (!_validationService.ValidateEmail(user.Email))
            {
                Console.WriteLine("Invalid email. Please try again.");
                user.Email = Console.ReadLine()!;
            }
            Console.Write("Enter the user's phone number: ");
            user.PhoneNumber = Console.ReadLine()!;
            while (!_validationService.ValidatePhoneNumber(user.PhoneNumber))
            {
                Console.WriteLine("Invalid phone number. Please try again.");
                user.PhoneNumber = Console.ReadLine()!;
            }
            Console.Write("Enter the user's address: ");
            user.Address = Console.ReadLine()!;
            while (!_validationService.ValidateAddress(user.Address))
            {
                Console.WriteLine("Invalid address. Please try again.");
                user.Address = Console.ReadLine()!;
            }
            Console.Write("Enter the user's postal code: ");
            user.PostalCode = Console.ReadLine()!;
            while (!_validationService.ValidatePostalCode(user.PostalCode))
            {
                Console.WriteLine("Invalid postal code. Please try again.");
                user.PostalCode = Console.ReadLine()!;
            }
            Console.Write("Enter the user's city: ");
            user.City = Console.ReadLine()!;
            while (!_validationService.ValidateCity(user.City))
            {
                Console.WriteLine("Invalid city. Please try again.");
                user.City = Console.ReadLine()!;
            }

            userService.CreateUser(user);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"User: {user.FirstName} {user.LastName} created successfully");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
