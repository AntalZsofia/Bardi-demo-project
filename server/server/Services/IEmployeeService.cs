using Bardi_demo_project.Models.RequestDto;
using Bardi_demo_project.Models.ResultDto;

namespace Bardi_demo_project.Services;

public interface IEmployeeService
{
       Task<RegisterResult> RegisterEmployee(RegisterEmployeeDto registerEmployeeDto);
        Task<LoginResult> LoginEmployee(LoginEmployeeDto loginEmployeeDto);
}