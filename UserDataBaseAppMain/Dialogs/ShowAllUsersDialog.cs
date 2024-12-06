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

        if (users == null || !users.Any())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("There are no users to display.");
            Console.ResetColor();
        }
        else
        {
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

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
}
