using System.Diagnostics;
using Business.Interfaces;
using Business.Models;
using UserDataBaseAppMain.Helpers;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs;

public class MainMenuDialog(
    IUserService userService,
    IValidationService validationService,
    ICreateUserDialog createUserDialog,
    IShowAllUsersDialog showAllUsersDialog,
    //ISearchUserDialog searchUserDialog,
    IExitUserDialog exitUserDialog
) : IMainMenuDialog
{
    private readonly IUserService _userService =
        userService ?? throw new ArgumentNullException(nameof(userService));
    private readonly IValidationService _validationService =
        validationService ?? throw new ArgumentNullException(nameof(validationService));
    private readonly ICreateUserDialog _createUserDialog =
        createUserDialog ?? throw new ArgumentNullException(nameof(createUserDialog));
    private readonly IShowAllUsersDialog _showAllUsersDialog =
        showAllUsersDialog ?? throw new ArgumentNullException(nameof(showAllUsersDialog));

    //private readonly ISearchUserDialog _searchUserDialog =
    //  searchUserDialog ?? throw new ArgumentNullException(nameof(searchUserDialog));
    private readonly IExitUserDialog _exitUserDialog =
        exitUserDialog ?? throw new ArgumentNullException(nameof(exitUserDialog));

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
                    //_searchUserDialog.ShowDialog();
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
