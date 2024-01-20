namespace ProjectLibrary.Geometry.Execute
{
    public class TrianglePerimeter
    {
        public double CalcPerimeter(double width, double cathetusLeft, double cathetusRight)
        {
            double perimeter = width + cathetusLeft + cathetusRight;
            return perimeter;
        }
    }
}
