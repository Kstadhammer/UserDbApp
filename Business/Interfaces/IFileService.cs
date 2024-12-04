using Business.Models;
using Business.Services;

namespace Business.Interfaces;

public interface IFileService
{
    string GetFileContent();
    void SaveUserToFile(string content);
}
