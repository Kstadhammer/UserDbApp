using System.Diagnostics;
using Business.Interfaces;
using Business.Models;
using UserDataBaseAppMain.Helpers;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs;

public class MainMenuDialog(IUserService userService) : IMainMenuDialog
{
    private readonly IUserService _userService =
        userService ?? throw new ArgumentNullException(nameof(userService));
    private readonly CreateUserDialog _createUserDialog = new(userService);
    private readonly ShowAllUsersDialog _showAllUsersDialog = new(userService);
    private readonly SearchUserDialog _searchUserDialog = new(userService);
    private readonly ExitUserDialog _exitUserDialog = new();

    private int _selectedIndex = 0;
    private readonly string[] _options =
    {
        "1. Add New User",
        "2. View All Users",
        "3. Find User by Name",
        "4. Remove User",
        "5. Exit Application",
    };

    public void ShowUserMenu()
    {
        while (true)
        {
            _selectedIndex = ConsoleHelper.ShowMenu(_options, _selectedIndex);

            switch (_selectedIndex)
            {
                case 0:
                    _createUserDialog.ShowDialog();
                    break;
                case 1:
                    _showAllUsersDialog.ShowDialog();
                    break;
                case 2:
                    _searchUserDialog.ShowDialog();
                    break;
                case 3:
                    //_deleteUserDialog.ShowDialog();
                    break;
                case 4:
                    _exitUserDialog.ShowDialog();
                    break;
            }
        }
    }
}
