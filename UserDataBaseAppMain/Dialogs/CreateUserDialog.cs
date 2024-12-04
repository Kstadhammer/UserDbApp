using Business.Interfaces;
using Business.Models;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs
{
    public class CreateUserDialog(IUserService userService) : ICreateUserDialog
    {
        public void ShowDialog()
        {
            var user = new User();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the create a user interface\n");
            Console.ResetColor();

            Console.Write("Enter the user's first name: ");
            user.FirstName = Console.ReadLine()!;
            Console.Write("Enter the user's last name: ");
            user.LastName = Console.ReadLine()!;
            Console.Write("Enter the user's email: ");
            user.Email = Console.ReadLine()!;
            Console.Write("Enter the user's phone number: ");
            user.PhoneNumber = Console.ReadLine()!;
            Console.Write("Enter the user's address: ");
            user.Address = Console.ReadLine()!;
            Console.Write("Enter the user's postal code: ");
            user.PostalCode = Console.ReadLine()!;
            Console.Write("Enter the user's city: ");
            user.City = Console.ReadLine()!;

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
