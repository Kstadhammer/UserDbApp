using System;
using UserDataBaseAppMain.Helpers;
using Business.Interfaces;
using Business.Models;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain.Dialogs;

public class ExitUserDialog : IExitUserDialog
{
    public void ShowDialog()
    {
        string[] options = new[] { "Yes, exit application", "No, return to menu" };
        int selectedIndex = 1; // Default to "No"
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nAre you sure you want to exit?");
        
        selectedIndex = ConsoleHelper.ShowMenu(options, selectedIndex);

        if (selectedIndex == 0) // Yes selected
        {
            Console.Clear();
            ConsoleHelper.DisplaySuccessMessage("\nThank you for using the User Database App!");
            
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Saving and closing...");
            Console.ResetColor();

            System.Threading.Thread.Sleep(1500);
            Environment.Exit(0);
        }

        Console.Clear();
        return;
    }
}
