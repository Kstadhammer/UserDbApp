using System.Diagnostics;
using Business.Interfaces;
using Business.Models;
using Business.Models.DTOs;
using Business.Services;
using UserDataBaseAppMain.Helpers;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs;

public class EditUserDialog(IUserService userService, IValidationService validationService)
    : IEditUserDialog
{
    public void ShowDialog()
    {
        Console.Clear();
        Console.WriteLine("Edit Existing User \n");

        // Show all users first
        var users = userService.GetUsers().ToList();
        if (!users.Any())
        // if no user is found
        {
            Console.WriteLine("No users with that name found in the system.");
            ConsoleHelper.PressAnyKeyToContinue();
            return;
        }

        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine("------------------------");
        }

        Console.Write("\nEnter the ID of the user you want to edit (or 'exit' to return): ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "exit")
            return;

        var userToEdit = users.FirstOrDefault(u => u.Id == input);
        if (userToEdit == null)
        {
            Console.WriteLine("User not found.");
            ConsoleHelper.PressAnyKeyToContinue();
            return;
        }

        // Get updated information
        var userDto = new UserDto();

        Console.WriteLine($"\nCurrent First Name: {userToEdit.FirstName}");
        Console.Write("New First Name (press Enter to keep current): ");
        var firstName = Console.ReadLine();
        userDto.FirstName = string.IsNullOrWhiteSpace(firstName) ? userToEdit.FirstName : firstName;

        Console.WriteLine($"Current Last Name: {userToEdit.LastName}");
        Console.Write("New Last Name (press Enter to keep current): ");
        var lastName = Console.ReadLine();
        userDto.LastName = string.IsNullOrWhiteSpace(lastName) ? userToEdit.LastName : lastName;

        Console.WriteLine($"Current Email: {userToEdit.Email}");
        Console.Write("New Email (press Enter to keep current): ");
        var email = Console.ReadLine();
        userDto.Email = string.IsNullOrWhiteSpace(email) ? userToEdit.Email : email;

        Console.WriteLine($"Current Phone Number: {userToEdit.PhoneNumber}");
        Console.Write("New Phone Number (press Enter to keep current): ");
        var phone = Console.ReadLine();
        userDto.PhoneNumber = string.IsNullOrWhiteSpace(phone) ? userToEdit.PhoneNumber : phone;

        Console.WriteLine($"Current Address: {userToEdit.Address}");
        Console.Write("New Address (press Enter to keep current): ");
        var address = Console.ReadLine();
        userDto.Address = string.IsNullOrWhiteSpace(address) ? userToEdit.Address : address;

        Console.WriteLine($"Current Postal Code: {userToEdit.PostalCode}");
        Console.Write("New Postal Code (press Enter to keep current): ");
        var postalCode = Console.ReadLine();
        userDto.PostalCode = string.IsNullOrWhiteSpace(postalCode)
            ? userToEdit.PostalCode
            : postalCode;

        Console.WriteLine($"Current City: {userToEdit.City}");
        Console.Write("New City (press Enter to keep current): ");
        var city = Console.ReadLine();
        userDto.City = string.IsNullOrWhiteSpace(city) ? userToEdit.City : city;

        // Validate the updated information
        if (!ValidateUserInput(userDto))
        {
            Console.WriteLine("\nValidation failed. Changes were not saved.");
            ConsoleHelper.PressAnyKeyToContinue();
            return;
        }

        // Save the changes
        userService.EditUser(userToEdit.Id, userDto);
        Console.WriteLine("\nUser information updated successfully!");
        ConsoleHelper.PressAnyKeyToContinue();
    }

    private bool ValidateUserInput(UserDto userDto)
    {
        if (!validationService.ValidateFirstName(userDto.FirstName))
        {
            Console.WriteLine(
                "Invalid first name. Must be 2-20 characters long and contain only letters."
            );
            return false;
        }

        if (!validationService.ValidateLastName(userDto.LastName))
        {
            Console.WriteLine(
                "Invalid last name. Must be 2-30 characters long and contain only letters."
            );
            return false;
        }

        if (!validationService.ValidateEmail(userDto.Email))
        {
            Console.WriteLine("Invalid email format.");
            return false;
        }

        if (!validationService.ValidatePhoneNumber(userDto.PhoneNumber))
        {
            Console.WriteLine("Invalid phone number format.");
            return false;
        }

        if (!validationService.ValidateAddress(userDto.Address))
        {
            Console.WriteLine("Invalid address format.");
            return false;
        }

        if (!validationService.ValidatePostalCode(userDto.PostalCode))
        {
            Console.WriteLine("Invalid postal code. Must be exactly 5 digits.");
            return false;
        }

        if (!validationService.ValidateCity(userDto.City))
        {
            Console.WriteLine("Invalid city name. Must contain only letters and spaces.");
            return false;
        }

        return true;
    }
}
