using ProjectLibrary.Interface;

namespace ProjectLibrary.Geometry.Execute
{
    public class TriangleArea : IArea
    {
        public double CalcArea(double width, double height)
        {
            double area = (width * height) / 2;
            return area;
        }
    }
}
