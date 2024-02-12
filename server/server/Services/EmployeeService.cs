using Bardi_demo_project.Models.RequestDto;
using Bardi_demo_project.Models.ResultDto;
using Emgu.CV;


namespace Bardi_demo_project.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IImageService _imageService;
    private readonly IVectorService _vectorService;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly Random _random = new Random();
    
    public EmployeeService(IImageService imageService, IVectorService vectorService, IEmployeeRepository employeeRepository, Random random)
    {
        _imageService = imageService;
        _vectorService = vectorService;
        _employeeRepository = employeeRepository;
        _random = random;
        
    } 
    
    public async Task<RegisterResult> RegisterEmployee(RegisterEmployeeDto registerEmployeeDto)
    {
        try
        {
            //crop the image and convert it to a vector
            Mat croppedImage = await _imageService.CropImage(registerEmployeeDto.Image);
           double[] vector = _vectorService.ConvertToVector(croppedImage);
           
           //create random identification number
           int identificationNumber;
           do
           {
               identificationNumber = _random.Next(1000, 10000);
           } while (await _employeeRepository.DoesIdentificationNumberExist(identificationNumber));
           
           //create employee
           var employee = new Employee
           {
               Name = registerEmployeeDto.Name,
               IdentificationNumber = identificationNumber,
               VectorOfImage = vector
           };

           await _employeeRepository.SaveEmployee(employee);
           return new RegisterResult(true, "Employee registered successfully");

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    

    public async Task<LoginResult> LoginEmployee(LoginEmployeeDto loginEmployeeDto)
    {
        try
        {
            //check the employee's name and identification number
            var employee = await _employeeRepository.GetEmployeeByName(loginEmployeeDto.Name);
            if (employee == null)
            {
                return new LoginResult(false, "Invalid name");
            }
            if (employee.IdentificationNumber != loginEmployeeDto.IdentificationNumber)
            {
                return new LoginResult(false, "Invalid identification number");
            }
            
            //check the employee's image and compare with the stored one in the database
            Mat newImage = await _imageService.CropImage(loginEmployeeDto.Image);
            double[] newVector = _vectorService.ConvertToVector(newImage);

            bool isMatch = _vectorService.CompareVectors(employee.VectorOfImage, newVector);
            
            if (!isMatch)
            {
                return new LoginResult(false,"Invalid image");
            }
            
            return new LoginResult(true, "Login successful");

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}

