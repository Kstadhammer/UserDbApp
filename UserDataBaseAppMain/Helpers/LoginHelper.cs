using System.Text;

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
        Console.ForegroundColor = ConsoleColor.Cyan;
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
}
