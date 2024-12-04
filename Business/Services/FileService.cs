using System.IO;
using System.Reflection;
using Business.Interfaces;

namespace Business.Services;

public class FileService : IFileService
{
    private readonly string _saveDirectory;
    private readonly string _saveFilePath;

    public FileService(string saveDirectory = "Data", string saveFileName = "users.json")
    {
        _saveDirectory = saveDirectory;
        _saveFilePath = Path.Combine(_saveDirectory, saveFileName);
    }

    public void SaveUserToFile(string content)
    {
        if (Directory.Exists(_saveDirectory))
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
