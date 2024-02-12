using Bardi_demo_project.Models;
using Microsoft.EntityFrameworkCore;

namespace Bardi_demo_project.Services;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _context;
    
    public EmployeeRepository(EmployeeDbContext context)
    {
        _context = context;
    }
    
    public async Task SaveEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Employee> GetEmployeeByName(string name)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Name == name);
        return employee!;
    }
    
    public async Task<bool> DoesIdentificationNumberExist(int idNumber)
    {
        return await _context.Employees.AnyAsync(e => e.IdentificationNumber == idNumber);
    }
}