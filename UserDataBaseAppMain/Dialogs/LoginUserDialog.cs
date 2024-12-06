using Business.Interfaces;
using Business.Models;
using Business.Services;
using UserDataBaseAppMain.Dialogs;
using UserDataBaseAppMain.Helpers;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs;

public class LoginUserDialog(IUserService userService) : ILoginUserDialog
{
    private readonly IUserService _userService = userService;

    private int _selectedIndex = 0;

    private readonly string[] _loginOptions = ["1. Login", "2. Register", "3. Exit"];

    public void ShowLoginMenu()
    {
        while (true)
        {
            _selectedIndex = LoginHelper.ShowLoginMenu(_loginOptions, _selectedIndex);

            switch (_selectedIndex)
            {
                case 0:
                    ShowLoginDialog();
                    break;
                case 1:
                    //_createLoginUserDialog.ShowDialog();
                    break;
                case 2:
                    //_exitUserDialog.ShowDialog();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void ShowLoginDialog()
    {
        Console.Clear();
        Console.WriteLine("Please login to your account.");
        Console.Write("Enter username: ");
        var username = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter password: ");
        var password = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            Console.WriteLine("Username and password cannot be empty");
            return;
        }

        var user = _userService.Login(username, password);
        Console.ReadKey();
    }
}
