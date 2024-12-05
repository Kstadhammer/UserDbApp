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
        string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
        string projectDirectory = Directory.GetParent(baseDirectory)?.Parent?.Parent?.FullName ?? "";
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
        streamWriter.WriteLine(content);
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
