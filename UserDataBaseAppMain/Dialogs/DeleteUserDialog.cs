using Business.Interfaces;
using Business.Models.DTOs;
using Business.Services;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs;

public class DeleteUserDialog(IUserService userService) : IDeleteUserDialog
{
    public void ShowDialog()
    {
        Console.Clear();
        Console.WriteLine("Delete a existing user:");

        Console.Write("Enter first name: ");
        var firstName = Console.ReadLine()?.Trim();

        Console.Write("Enter last name: ");
        var lastName = Console.ReadLine()?.Trim();

        // if no user is found or first name and last name are empty

        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            Console.WriteLine("First name and last name cannot be empty.");
            return;
        }
        // if user is found and last name matches

        var user = userService.GetUserByFirstName(firstName);
        if (user.LastName == lastName)
        {
            userService.DeleteUser(user.Id);
            Console.WriteLine("User deleted successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
