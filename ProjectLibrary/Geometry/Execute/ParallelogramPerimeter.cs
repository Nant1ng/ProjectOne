namespace ProjectLibrary.Geometry.Execute
{
    public class ParallelogramPerimeter
    {
        public double CalcPerimeter(double width, double cathetusLeft)
        {
            double perimeter = (width * 2) + (cathetusLeft * 2);
            return perimeter;
        }
    }
}
