using System.Diagnostics;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using UserDataBaseAppMain.Helpers;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs;

public class EditUserDialog(IUserService userService)
{
    public void ShowDialog()
    {
        Console.Clear();
        Console.WriteLine("Edit a existing user:");
        Console.WriteLine("Press S to show all users");
        Console.WriteLine("Press E to exit");
        string userInput = Console.ReadLine()!;

        if (userInput.ToUpper() == "S")
        {
            var showAllUsersDialog = new ShowAllUsersDialog(userService);
            showAllUsersDialog.ShowDialog();
            foreach (var user in userService.GetUsers()!)
            {
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
                
            }
        }
        else if (userInput.ToUpper() == "E")
        {
            var exitUserDialog = new ExitUserDialog();
            exitUserDialog.ShowDialog();
        }
        else
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
    }
}
