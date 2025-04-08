using DotnetApiDemo2025.Controllers;
using DotnetApiDemo2025.Data;
using DotnetApiDemo2025.Models;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    DataContextDapper _dapper;

    public UserController(IConfiguration config)
    {        
        // Console.WriteLine(config.GetConnectionString("DefaultConnection"));
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection() 
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers() 
    {
        string sql = @"
            SELECT [UserId]
                  ,[FirstName]
                  ,[LastName]
                  ,[Email]
                  ,[Gender]
                  ,[Active]
            FROM [DotnetApiDb].[DemoSchema].[Users]";

        return _dapper.LoadData<User>(sql);
    }

    [HttpGet("GetSingleUser/{userId}")]
    public User GetSingleUser(int userId)
    {
        string sql = @"
            SELECT [UserId]
                  ,[FirstName]
                  ,[LastName]
                  ,[Email]
                  ,[Gender]
                  ,[Active]
            FROM [DotnetApiDb].[DemoSchema].[Users]
            WHERE [UserId] = " + userId.ToString();

        return _dapper.LoadDataSingle<User>(sql);
    }

    [HttpGet("test/{testValue}")]
    // public IActionResult Test()
    public string[] Test(string testValue)
    {
        string[] repsonseArray = new string [] {
            "test1",
            "test2",
            testValue
        };

        return repsonseArray;
    }
}