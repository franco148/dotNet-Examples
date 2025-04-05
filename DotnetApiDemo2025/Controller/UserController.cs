using DotnetApiDemo2025.Controllers;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {        
    }

    [HttpGet("test/{testValue}")]
    // public IActionResult Test()
    public string[] Test(string testValue)
    {
        string[] repsonseArray = new string [] {
            "test1",
            "test2"
        };

        return repsonseArray;
    }
}