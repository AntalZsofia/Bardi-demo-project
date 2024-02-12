namespace Bardi_demo_project.Models.ResultDto;

public class LoginResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    
    public LoginResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }
    
}