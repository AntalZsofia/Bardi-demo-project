using Emgu.CV;

namespace Bardi_demo_project.Services;

public interface IVectorService
{
    double[] ConvertToVector(Mat image);
    
    bool CompareVectors(double[] vector1, double[] vector2);
}