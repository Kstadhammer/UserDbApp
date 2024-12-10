using System.Diagnostics;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs
{
    public class SearchUserDialog(IUserService userService)
    {
        public void ShowDialog()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Search for a existing user:");
            Console.Write("Enter the user's first name: ");
            Console.ResetColor();

            var firstName = Console.ReadLine();
            var user = userService.GetUserByFirstName(firstName);
            if (user != null)
            {
                Console.WriteLine($"User found: {user.FirstName} {user.LastName}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}
