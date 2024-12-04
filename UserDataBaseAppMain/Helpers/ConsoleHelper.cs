using System;
using System.Text;

namespace UserDataBaseAppMain.Helpers;

public static class ConsoleHelper
{
    static ConsoleHelper()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
    }

    /// <summary>
    /// Interactive menu from https://github.com/ricardogerbaudo/Console.InteractiveMenu
    /// Implementation of the ASCII logo and arrow key navigation was assisted by Claude AI.
    /// This includes the menu navigation system and proper handling of arrow key inputs.
    /// </summary>
    public static void DisplayLogo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
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
        Console.ResetColor();
        Console.WriteLine("\n");
    }

    public static int ShowMenu(string[] options, int selectedIndex)
    {
        ConsoleKey keyPressed;
        do
        {
            Console.Clear();
            DisplayLogo();
            Console.WriteLine("Welcome to the User Database App! 📊");
            Console.WriteLine("Use ⬆️  and ⬇️  to navigate and press Enter to select:\n");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"  > {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"    {options[i]}");
                }
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = options.Length - 1;
                }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length)
                {
                    selectedIndex = 0;
                }
            }
        } while (keyPressed != ConsoleKey.Enter);

        return selectedIndex;
    }

    public static void DisplaySuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✅ {message}");
        Console.ResetColor();
    }

    public static void DisplayErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n❌ {message}");
        Console.ResetColor();
    }
}
