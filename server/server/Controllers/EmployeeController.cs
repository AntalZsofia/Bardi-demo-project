using Bardi_demo_project.Models.RequestDto;
using Bardi_demo_project.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Bardi_demo_project.Controllers;
[EnableCors("AllowOrigin")]
[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterEmployee([FromForm] RegisterEmployeeDto registerEmployeeDto)
    {
        try
        {
            var result = await _employeeService.RegisterEmployee(registerEmployeeDto);
            if (result.Success)
            {
            return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
                
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginEmployee(LoginEmployeeDto loginEmployeeDto)
    {
        try
        {
            var result = await _employeeService.LoginEmployee(loginEmployeeDto);
            if (result.Success)
            {
            return Ok(result.Message);
            }
            else
            {
                return Unauthorized(result.Message);
                
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}