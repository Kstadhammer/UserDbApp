using System.IO;
using System.Reflection;
using Business.Interfaces;

namespace Business.Services;

public class FileService : IFileService
{
    private readonly string _saveDirectory;
    private readonly string _saveFilePath;

    public FileService(string saveFileName = "users.json")
    {
        /*
            Help was needed to get the correct folder path,
            as it was being put in the .NET 9.0 folder.
        
            The correct folder structure is:
              - Start: C:\MyProject\bin\Debug\net9.0
              - Up one level: C:\MyProject\bin\Debug
              - Up two levels: C:\MyProject\bin
              - Up three levels: C:\MyProject
              -Now it creates a folder called Business/Data/Filename.json
              where it stores all the userdata
              
              Used Claude AI for this

              Some of the code is used from Hans video on how to save to json file
              and load from json after user has been added and when starting the application
        */
        string baseDirectory =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
        string projectDirectory =
            Directory.GetParent(baseDirectory)?.Parent?.Parent?.FullName ?? "";
        _saveDirectory = Path.Combine(projectDirectory, "Business/Data");
        _saveFilePath = Path.Combine(_saveDirectory, saveFileName);
    }

    public void SaveUserToFile(string content)
    {
        if (!Directory.Exists(_saveDirectory))
        {
            Directory.CreateDirectory(_saveDirectory);
        }
        using var streamWriter = new StreamWriter(_saveFilePath);
        streamWriter.Write(content);
    }

    public string GetFileContent()
    {
        if (File.Exists(_saveFilePath))
        {
            using var streamReader = new StreamReader(_saveFilePath);
            return streamReader.ReadToEnd();
        }
        return "[]";
    }
}
