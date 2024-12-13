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
    ISearchUserDialog searchUserDialog,
    IExitUserDialog exitUserDialog,
    IDeleteUserDialog deleteUserDialog,
    IEditUserDialog editUserDialog
) : IMainMenuDialog
{
    // Initialize services and dialogs, throwing an exception if any are null
    private readonly IUserService _userService =
        userService ?? throw new ArgumentNullException(nameof(userService));
    private readonly IValidationService _validationService =
        validationService ?? throw new ArgumentNullException(nameof(validationService));
    private readonly ICreateUserDialog _createUserDialog =
        createUserDialog ?? throw new ArgumentNullException(nameof(createUserDialog));
    private readonly IShowAllUsersDialog _showAllUsersDialog =
        showAllUsersDialog ?? throw new ArgumentNullException(nameof(showAllUsersDialog));

    private readonly ISearchUserDialog _searchUserDialog =
        searchUserDialog ?? throw new ArgumentNullException(nameof(searchUserDialog));
    private readonly IExitUserDialog _exitUserDialog =
        exitUserDialog ?? throw new ArgumentNullException(nameof(exitUserDialog));
    private readonly IDeleteUserDialog _deleteUserDialog =
        deleteUserDialog ?? throw new ArgumentNullException(nameof(deleteUserDialog));
    private readonly IEditUserDialog _editUserDialog =
        editUserDialog ?? throw new ArgumentNullException(nameof(editUserDialog));

    // Menu options which can be navigated using arrow keys
    private int _selectedIndex = 0;
    private readonly string[] _options =
    {
        "1. Add New User", // Option to add a new user
        "2. View All Users", // Option to view all users
        "3. Find User by Name", // Option to search for a user by name
        "4. Edit User", // Option to edit an existing user
        "5. Remove User", // Option to delete a user
        "6. Exit Application", // Option to exit the application
    };

    // Method to display the user menu and handle user selections
    public void ShowUserMenu()
    {
        while (true) // Infinite loop to keep showing the menu
        {
            // Display the menu and get the selected index
            _selectedIndex = ConsoleHelper.ShowMenu(_options, _selectedIndex);

            // Execute the action based on the selected option
            switch (_selectedIndex)
            {
                case 0:
                    _createUserDialog.ShowDialog(); // Show dialog to create a new user
                    break;
                case 1:
                    _showAllUsersDialog.ShowDialog(); // Show dialog to view all users
                    break;
                case 2:
                    _searchUserDialog.ShowDialog(); // Show dialog to search for a user
                    break;
                case 3:
                    _editUserDialog.ShowDialog(); // Show dialog to edit a user
                    break;
                case 4:
                    _deleteUserDialog.ShowDialog(); // Show dialog to delete a user
                    break;
                case 5:
                    _exitUserDialog.ShowDialog(); // Show dialog to exit the application
                    break;
            }
        }
    }
}
