namespace Bardi_demo_project.Services;

public interface IEmployeeRepository
{
    Task SaveEmployee(Employee employee);
    Task<Employee> GetEmployeeByName(string name);
    Task<bool> DoesIdentificationNumberExist(int idNumber);
}