using Emgu.CV;

namespace Bardi_demo_project.Services;

public interface IImageService
{ 
    Task<Mat> CropImage(IFormFile image);
}