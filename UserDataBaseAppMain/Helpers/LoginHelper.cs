using System.Text;
using Business.Interfaces;

namespace UserDataBaseAppMain.Helpers;

public static class LoginHelper
{
    static LoginHelper()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
    }

    public static void DisplayLoginLogo()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(
            @"
    ██▓     ▒█████    ▄████  ██▓ ███▄    █ 
    ▓██▒    ▒██▒  ██▒ ██▒ ▀█▒▓██▒ ██ ▀█   █ 
    ▒██░    ▒██░  ██▒▒██░▄▄▄░▒██▒▓██  ▀█ ██▒
    ▒██░    ▒██   ██░░▓█  ██▓░██░▓██▒  ▐▌██▒
    ░██████▒░ ████▓▒░░▒▓███▀▒░██░▒██░   ▓██░
    ░ ▒░▓  ░░ ▒░▒░▒░  ░▒   ▒ ░▓  ░ ▒░   ▒ ▒ 
    ░ ░ ▒  ░  ░ ▒ ▒░   ░   ░  ▒ ░░ ░░   ░ ▒░
      ░ ░   ░ ░ ░ ▒  ░ ░   ░  ▒ ░   ░   ░ ░ 
        ░  ░    ░ ░        ░  ░           ░ "
        );
        Console.ResetColor();
        Console.WriteLine("\n");
    }

    public static int ShowLoginMenu(string[] loginOptions, int selectedIndex)
    {
        ConsoleKey keyPressed;
        do
        {
            Console.Clear();
            DisplayLoginLogo();

            Console.WriteLine("Welcome to the User Database App 📊:");
            Console.WriteLine(
                "Login into an existing account or create a new account if you don't have one:"
            );
            Console.WriteLine("Use ⬆️  and ⬇️  to navigate and press Enter to select:\n");

            for (int i = 0; i < loginOptions.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"  > {loginOptions[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  > {loginOptions[i]}");
                }
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = loginOptions.Length - 1;
                }

                //had some help from claude to fix this, my first try was to use the
                //selectedIndex-- but it wouldn't work
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= loginOptions.Length)
                {
                    selectedIndex = 0;
                }
            }
        } while (keyPressed != ConsoleKey.Enter);

        return selectedIndex;
    }
}
