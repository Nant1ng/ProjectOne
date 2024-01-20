using ProjectLibrary.Interface;

namespace ProjectLibrary.Geometry.Execute
{
    public class RectangleArea : IArea
    {
        public double CalcArea(double width, double lenght)
        {
            double area = width * lenght;
            return area;
        }
    }
}
