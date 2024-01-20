using ProjectLibrary.Interface;

namespace ProjectLibrary.Geometry.Execute
{
    public class ParallelogramArea : IArea
    {
        public double CalcArea(double width, double height)
        {
            double area = width * height;
            return area;
        }
    }
}
