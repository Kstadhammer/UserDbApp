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

    //delete the test file after the tests are done
    public void DeleteTestFile_AfterTestsAreDone()
    {
        //delete the test file after the tests are done
        if (File.Exists(_testFilePath))
        {
            File.Delete(_testFilePath);
        }
    }
}
