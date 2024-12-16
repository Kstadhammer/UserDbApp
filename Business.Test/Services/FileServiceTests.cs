using System.Text.Json;
using Business.Interfaces;
using Business.Models;
using Business.Models.DTOs;
using Business.Services;
using Microsoft.VisualBasic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace Business.Test.Services;

//testing for the file service using xunit and moq
public class FileServiceTests
{
    private readonly string _testFilePath;
    private readonly FileService _fileService;

    //setup the file service and the test file path
    public FileServiceTests()
    {
        _testFilePath = Path.Combine(Path.GetTempPath(), "test_users.json");
        _fileService = new FileService(_testFilePath);
    }

    [Fact]
    //delete the test file after the tests are done
    public void DeleteTestFile_AfterTestsAreDone()
    {
        //delete the test file after the tests are done
        if (File.Exists(_testFilePath))
        {
            File.Delete(_testFilePath);
        }
    }

    [Fact]
    public void SaveUserToFile_ShouldCreateAFile()
    {
        // Arrange
        var testData = "test data";

        // Act
        _fileService.SaveUserToFile(testData);

        // Assert
        Assert.True(File.Exists(_testFilePath));
        Assert.Equal(testData, File.ReadAllText(_testFilePath));
    }

    [Fact]
    public void GetFileContent_ShouldReturnTheFileContent()
    {
        // Get the file content from the file service and return it
        // Arrange
        var testData = "test data";
        File.WriteAllText(_testFilePath, testData);
        // Act
        var result = _fileService.GetFileContent();

        // Assert
        Assert.Equal(testData, result);
    }

    [Fact]
    public void GetFileContent_ShouldReturnEmptyStringIfFileDoesNotExist()
    {
        // Arrange
        // Act
        var result = _fileService.GetFileContent();

        // Assert
        Assert.Equal("[]", result);
    }
}
