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

    private readonly string[] _loginOptions = { "1. Login", "2. Register", "3. Exit" };

    public void ShowLoginMenu()
    {
        while (true)
        {
            _selectedIndex = LoginHelper.ShowMenu(_loginOptions, _selectedIndex);

            switch (_selectedIndex)
            {
                case 0:
                    _loginUserDialog.ShowDialog();
                    break;
                case 1:
                    _createLoginUserDialog.ShowDialog();
                    break;
                case 2:
                    _exitUserDialog.ShowDialog();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
