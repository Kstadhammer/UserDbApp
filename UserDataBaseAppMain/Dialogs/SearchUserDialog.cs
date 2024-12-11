// This code allows the user to search for a user by their first name.
// It prompts the user to enter a first name and checks if it's valid.
// If a user is found, it displays their details; otherwise, it shows a message that no user was found.

using System.Diagnostics;
using Business.Interfaces;
using Business.Models;
using Business.Models.DTOs;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs;

public class SearchUserDialog(IUserService userService) : ISearchUserDialog
{
    public void ShowDialog()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Search for a user\n");
        Console.ResetColor();

        Console.Write("Enter first name to search: ");
        var firstName = Console.ReadLine()?.Trim();

        // Check if first name is empty

        if (string.IsNullOrWhiteSpace(firstName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nFirst name cannot be empty.");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        //Gets user from userService using the first name of the user

        var user = userService.GetUserByFirstName(firstName);

        // If user is not found, show message
        if (string.IsNullOrEmpty(user.FirstName))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nNo user found with first name '{firstName}'");
        }
        else
        {
            Console.WriteLine($"\nUser found:");
            Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Phone: {user.PhoneNumber}");
            Console.WriteLine($"Address: {user.Address}");
            Console.WriteLine($"Postal Code: {user.PostalCode}");
            Console.WriteLine($"City: {user.City}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
