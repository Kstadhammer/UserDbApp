using System;
using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserDataBaseAppMain.Dialogs;
using UserDataBaseAppMain.Interfaces;

namespace UserDataBaseAppMain;

public class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddTransient<IFileService, FileService>();
                services.AddTransient<IUserService, UserService>();
                services.AddTransient<IMainMenuDialog, MainMenuDialog>();
                services.AddTransient<IShowAllUsersDialog, ShowAllUsersDialog>();
                services.AddTransient<ICreateUserDialog, CreateUserDialog>();
                //services.AddTransient<ISearchUserDialog, SearchUserDialog>();
                services.AddTransient<IExitUserDialog, ExitUserDialog>();
            })
            .Build();
        using var scope = host.Services.CreateScope();
        var mainMenuDialog = scope.ServiceProvider.GetRequiredService<IMainMenuDialog>();
        mainMenuDialog.ShowUserMenu();
    }
}
