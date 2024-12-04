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
            Console.WriteLine("Search for a user");
            Console.WriteLine("Enter the user's first name: ");
            var firstName = Console.ReadLine();
        }
    }
}
