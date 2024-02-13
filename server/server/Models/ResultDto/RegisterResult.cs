namespace Bardi_demo_project.Models.ResultDto;

public class RegisterResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public int EmployeeIdentificationNumber { get; set; }
    
    public RegisterResult(bool success, string message, int employeeIdentificationNumber)
    {
        Success = success;
        Message = message;
        EmployeeIdentificationNumber = employeeIdentificationNumber;
    }

}