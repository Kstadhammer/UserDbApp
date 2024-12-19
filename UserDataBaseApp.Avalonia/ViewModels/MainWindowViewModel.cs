using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UserDataBaseApp.Avalonia.Models;

namespace UserDataBaseApp.Avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<UserViewModel> Users { get; set; } =
        new ObservableCollection<UserViewModel>();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddUserCommand))]
    private UserViewModel _newUser;

    private bool CanAddUser()
    {
        return !string.IsNullOrEmpty(NewUser?.FirstName)
            && !string.IsNullOrEmpty(NewUser?.LastName)
            && !string.IsNullOrEmpty(NewUser?.Email)
            && !string.IsNullOrEmpty(NewUser?.PhoneNumber)
            && !string.IsNullOrEmpty(NewUser?.Address)
            && !string.IsNullOrEmpty(NewUser?.PostalCode)
            && !string.IsNullOrEmpty(NewUser?.City);
    }

    [RelayCommand(CanExecute = nameof(CanAddUser))]
    private void AddUser()
    {
        Users.Add(NewUser);
        NewUser = new UserViewModel(new User());
    }
}
