using ProjectLibrary.Interface;

namespace ProjectLibrary.Geometry.Execute
{
    public class RhombusArea : IArea
    {
        public double CalcArea(double width, double length)
        {
            double area = width * length;
            return area;
        }
    }
}
