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
            .ConfigureServices(
                (context, services) =>
                {
                    services.AddTransient<IFileService, FileService>();
                    services.AddSingleton<IUserService, UserService>();
                    services.AddTransient<IValidationService, ValidationService>();
                    services.AddTransient<ICreateUserDialog, CreateUserDialog>();
                    services.AddTransient<IShowAllUsersDialog, ShowAllUsersDialog>();
                    //services.AddTransient<ISearchUserDialog, SearchUserDialog>();
                    services.AddTransient<ILoginUserDialog, LoginUserDialog>();
                    services.AddTransient<IMainMenuDialog, MainMenuDialog>();
                    //services.AddTransient<ICreateLoginUserDialog, CreateLoginUserDialog>();
                    services.AddTransient<IExitUserDialog, ExitUserDialog>();
                }
            )
            .Build();
        using var scope = host.Services.CreateScope();

        var loginUserDialog = scope.ServiceProvider.GetRequiredService<ILoginUserDialog>();
        loginUserDialog.ShowLoginMenu();
        var mainMenuDialog = scope.ServiceProvider.GetRequiredService<IMainMenuDialog>();
        mainMenuDialog.ShowUserMenu();
    }
}
