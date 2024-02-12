namespace Bardi_demo_project.Models.ResultDto;

public class RegisterResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    
    public RegisterResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}