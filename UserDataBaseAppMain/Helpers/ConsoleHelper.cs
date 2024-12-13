using System;
using System.Text;

namespace UserDataBaseAppMain.Helpers;

public static class ConsoleHelper
{
    static ConsoleHelper()
    {
        // Set the console output to use UTF-8 encoding for better character support
        Console.OutputEncoding = Encoding.UTF8;
        // Hide the cursor for a cleaner look
        Console.CursorVisible = false;
    }

    /// <summary>
    /// This method displays the logo of the application.
    /// It uses ASCII art to create a visual representation of the app.
    /// The logo is shown in cyan color to make it stand out.
    /// </summary>
    public static void DisplayLogo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan; // Set the text color to cyan
        Console.WriteLine(
            @"
         █     █░▓█████  ██▓     ▄████▄   ▒█████   ███▄ ▄███▓▓█████ 
        ▓█░ █ ░█░▓█   ▀ ▓██▒    ▒██▀ ▀█  ▒██▒  ██▒▓██▒▀█▀ ██▒▓█   ▀ 
        ▒█░ █ ░█ ▒███   ▒██░    ▒▓█    ▄ ▒██░  ██▒▓██    ▓██░▒███   
        ░█░ █ ░█ ▒▓█  ▄ ▒██░    ▒▓▓▄ ▄██▒▒██   ██░▒██    ▒██ ▒▓█  ▄ 
        ░░██▒██▓ ░▒████▒░██████▒▒ ▓███▀ ░░ ████▓▒░▒██▒   ░██▒░▒████▒
        ░ ▓░▒ ▒  ░░ ▒░ ░░ ▒░▓  ░░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░   ░  ░░░ ▒░ ░

        ▄▄▄█████▓ ▒█████      ▄▄▄█████▓ ██░ ██ ▓█████ 
        ▓  ██▒ ▓▒▒██▒  ██▒    ▓  ██▒ ▓▒▓██░ ██▒▓█   ▀ 
        ▒ ▓██░ ▒░▒██░  ██▒    ▒ ▓██░ ▒░▒██▀▀██░▒███   
        ░ ▓██▓ ░ ▒██   ██░    ░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄ 
          ▒██▒ ░ ░ ████▓▒░      ▒██▒ ░ ░▓█▒░██▓░▒████▒
          ▒ ░░   ░ ▒░▒░▒░       ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░

        ▓█████▄  ▄▄▄     ▄▄▄█████▓ ▄▄▄       ▄▄▄▄    ▄▄▄        ██████ ▓█████ 
        ▒██▀ ██▌▒████▄   ▓  ██▒ ▓▒▒████▄    ▓█████▄ ▒████▄    ▒██    ▒ ▓█   ▀ 
        ░██   █▌▒██  ▀█▄ ▒ ▓██░ ▒░▒██  ▀█▄  ▒██▒ ▄██▒██  ▀█▄  ░ ▓██▄   ▒███   
        ░▓█▄   ▌░██▄▄▄▄██░ ▓██▓ ░ ░██▄▄▄▄██ ▒██░█▀  ░██▄▄▄▄██   ▒   ██▒▒▓█  ▄ 
        ░▒████▓  ▓█   ▓██▒ ▒██▒ ░  ▓█   ▓██▒░▓█  ▀█▓ ▓█   ▓██▒▒██████▒▒░▒████▒
         ▒▒▓  ▒  ▒▒   ▓▒█░ ▒ ░░    ▒▒   ▓▒█░░▒▓███▀▒ ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░░░ ▒░ ░"
        );
        Console.ResetColor(); // Reset the console color to default
        Console.WriteLine("\n"); // Add a new line for spacing
    }

    /// <summary>
    /// This method shows a menu with options for the user to choose from.
    /// It allows the user to navigate using the up and down arrow keys.
    /// When the user presses Enter, the selected option is returned.
    /// </summary>
    public static int ShowMenu(string[] options, int selectedIndex)
    {
        ConsoleKey keyPressed; // Variable to store the key pressed by the user
        do
        {
            Console.Clear(); // Clear the console for a fresh display
            DisplayLogo(); // Show the application logo
            Console.WriteLine("Welcome to the User Database App! 📊"); // Welcome message
            Console.WriteLine("Use ⬆️  and ⬇️  to navigate and press Enter to select:\n"); // Instructions for navigation

            // Display the menu options
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex) // Check if this option is selected
                {
                    Console.ForegroundColor = ConsoleColor.Cyan; // Change color for selected option
                    Console.WriteLine($"  > {options[i]}"); // Show selected option
                    Console.ResetColor(); // Reset color back to default
                }
                else
                {
                    Console.WriteLine($"    {options[i]}"); // Show unselected options
                }
            }

            // Read the key pressed by the user
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key; // Store the key pressed

            // Navigate up or down based on the key pressed
            if (keyPressed == ConsoleKey.UpArrow)
            {
                selectedIndex--; // Move selection up
                if (selectedIndex < 0) // If at the top, wrap around to the bottom
                {
                    selectedIndex = options.Length - 1;
                }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                selectedIndex++; // Move selection down
                if (selectedIndex >= options.Length) // If at the bottom, wrap around to the top
                {
                    selectedIndex = 0;
                }
            }
        } while (keyPressed != ConsoleKey.Enter); // Continue until Enter is pressed

        return selectedIndex; // Return the index of the selected option
    }

    /// <summary>
    /// This method displays a success message in green color.
    /// It is used to inform the user that an action was successful.
    /// </summary>
    public static void DisplaySuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green; // Set text color to green
        Console.WriteLine($"\n✅ {message}"); // Display the success message
        Console.ResetColor(); // Reset the color back to default
    }

    /// <summary>
    /// This method displays an error message in red color.
    /// It is used to inform the user that something went wrong.
    /// </summary>
    public static void DisplayErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
        Console.WriteLine($"\n❌ {message}"); // Display the error message
        Console.ResetColor(); // Reset the color back to default
    }

    /// <summary>
    /// This method prompts the user to press any key to continue.
    /// It is used to pause the program until the user is ready to proceed.
    /// </summary>
    public static void PressAnyKeyToContinue()
    {
        Console.WriteLine("\nPress any key to continue..."); // Instruction for the user
        Console.ReadKey(); // Wait for the user to press a key
    }
}
