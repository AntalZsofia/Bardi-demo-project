using System.Net.Mime;
using Emgu.CV;
using Emgu.CV.Structure;
namespace Bardi_demo_project.Services;

public class ImageService
{
    static readonly CascadeClassifier _faceCascade = new("haarcascade_frontalface_alt2.xml");

    public void CropImage(IFormFile image)
    {
        //var img = MediaTypeNames.Image.FromStream(image.OpenReadStream());
        //new Bitmap(Image.FromStream(image.OpenReadStream()));
        var face = _faceCascade.DetectMultiScale(new Mat(), 1.1, 3);
        
        
        
    }
    public void GreyScaleImage(){}
}

public class Bitmap
{
    public Bitmap(object fromStream)
    {
        throw new NotImplementedException();
    }
}