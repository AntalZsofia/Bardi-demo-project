using System.Drawing;
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

                // Convert the memory stream to a byte array
                byte[] imageBytes = memoryStream.ToArray();

                // Use Imdecode to read the image directly from the byte array
                Mat imageMat = new Mat();
                CvInvoke.Imdecode(imageBytes, ImreadModes.Color, imageMat);

                //convert to grey scale
                Mat greyImage = new Mat();
                CvInvoke.CvtColor(imageMat, greyImage, ColorConversion.Bgr2Gray);
                
                Rectangle[] faces = FaceCascade.DetectMultiScale(imageMat, 1.1, 3);
                if (faces.Length == 1)
                {
                    Rectangle faceRec = faces[0];
                    Mat croppedFaceMat = new Mat(greyImage, faceRec);

                    return croppedFaceMat;
                }
                else if (faces.Length == 0)
                {
                    // No faces detected
                    throw new Exception("No faces detected in the image.");
                }
                else
                {
                    // More than one face detected
                    throw new Exception("More than one face detected in the image. Expected only one face.");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error processing the image.", ex);
        }
    }

   
}