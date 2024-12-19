using System;
using CommunityToolkit.Mvvm.ComponentModel;
using UserDataBaseApp.Avalonia.Models;

namespace UserDataBaseApp.Avalonia.ViewModels;

public partial class UserViewModel : ViewModelBase
{
    [ObservableProperty]
    private User _user;

    [ObservableProperty]
    private string _firstName;

    [ObservableProperty]
    private string _lastName;

    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _phoneNumber;

    [ObservableProperty]
    private string _address;

    [ObservableProperty]
    private string _postalCode;

    [ObservableProperty]
    private string _city;

    public UserViewModel(User user)
    {
        User = user;
    }

    public User GetUser()
    {
        return new User
        {
            Id = Guid.NewGuid().ToString(),
            TimeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            FirstName = User.FirstName,
            LastName = User.LastName,
            Email = User.Email,
            PhoneNumber = User.PhoneNumber,
            Address = User.Address,
            PostalCode = User.PostalCode,
            City = User.City,
        };
    }
}
