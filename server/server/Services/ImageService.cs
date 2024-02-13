
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;
using Bardi_demo_project.Models.RequestDto;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


namespace Bardi_demo_project.Services;

public class ImageService : IImageService
{
    static readonly CascadeClassifier FaceCascade = new("haarcascade_frontalface_alt2.xml");

    public async Task<Mat> CropImage(IFormFile image)
    {
        try
        {
            
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                
                byte[] imageBytes = memoryStream.ToArray();
                Mat imageMat = new Mat();
                CvInvoke.Imdecode(imageBytes, ImreadModes.Color, imageMat);
                
                
                Rectangle[] faces = FaceCascade.DetectMultiScale(imageMat, 1.1, 3);
                if(faces != null && faces.Length > 0)
                {
                    Rectangle faceRec = faces[0];
                    Mat croppedFaceMat = new Mat(imageMat, faceRec);
                    Mat greyCroppedFaceMat = ConvertToGrayscale(croppedFaceMat);
                    return greyCroppedFaceMat;
                }
                else
                {
                    throw new Exception("No faces detected in the image.");
                }
            }
          
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
                
        
        
    } 
    public Mat ConvertToGrayscale(Mat image)
        {
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);
            return grayImage;
        }

   
}