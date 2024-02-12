using Emgu.CV;
using Emgu.CV.Structure;

namespace Bardi_demo_project.Services;

public class VectorService : IVectorService
{
    public double[] ConvertToVector(Mat image)
    {
        Image<Gray, byte> img = image.ToImage<Gray, byte>();

        double[] vector = new double[img.Rows * img.Cols];
        int index = 0;
        for(int row = 0; row < img.Rows; row++)
        {
            for (int col = 0; col < img.Cols; col++)
            {
                    vector[index] = img.Data[row, col, 0];
                    index++;
            }
        }
        return vector;
    }
    

    public bool CompareVectors(double[] vector1, double[] vector2)
    {
        if (vector1.Length != vector2.Length)
        {
            return false;
            
        }

        double distance = 0;
        for (int i = 0; i < vector1.Length; i++)
        {
            distance += Math.Pow(vector1[i] - vector2[i], 2);
        }

        double threshold = 0.01;
        return distance <= threshold;
    }
}