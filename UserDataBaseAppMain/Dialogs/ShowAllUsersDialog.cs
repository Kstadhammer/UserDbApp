using Business.Interfaces;
using Business.Models;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs;

public class ShowAllUsersDialog(IUserService userService) : IShowAllUsersDialog
{
    public void ShowDialog()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Here are all the existing users:\n");
        Console.ResetColor();

        var users = userService.GetUsers();

        // if no users are found, show message and return to main menu
        if (users == null || !users.Any())
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("There are no users to display.");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }
        else
        {
            // if users are found, show user details using foreach loop
            // and display user details
            foreach (var user in users)
            {
                Console.WriteLine($"Created: {user.TimeCreated}");
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Phone number: {user.PhoneNumber}");
                Console.WriteLine($"Address: {user.Address}");
                Console.WriteLine($"Postal code: {user.PostalCode}");
                Console.WriteLine($"City: {user.City}");
                Console.WriteLine();
            }
        }

        // return to main menu

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
}
