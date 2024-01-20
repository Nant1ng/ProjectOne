using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data;
using ProjectLibrary.Enumeration;
using ProjectLibrary.Models;

namespace ProjectLibrary.Geometry
{
    public class ShowGeometryCalculation
    {
        public void Read(DbContextOptionsBuilder<AppDBContext> options)
        {
            using (AppDBContext dbContext = new AppDBContext(options.Options))
            {
                Console.WriteLine("Geometry Calculation History.");

                foreach (Shape s in dbContext.Shape.Where(s => s.IsActive))
                {
                    if (s.TypeOfShape == TypeOfShape.Rectangle || s.TypeOfShape == TypeOfShape.Rhombus)
                        Console.WriteLine($"Shape: {s.TypeOfShape}, Lenght: {s.Lenght}, Width: {s.Width}, Perimeter: {s.Perimeter:F2}, Area: {s.Area:F2}, Date: {s.CalculationDate}");
                    else if (s.TypeOfShape == TypeOfShape.Triangle)
                        Console.WriteLine($"Shape: {s.TypeOfShape}, Lenght: {s.Lenght}, Width: {s.Width}, Left Cathetus: {s.CathetusLeft}, Right Cathetus: {s.CathetusRight}, Perimeter: {s.Perimeter:F2}, Area: {s.Area:F2}, Date: {s.CalculationDate}");
                    else if (s.TypeOfShape == TypeOfShape.Parallelogram)
                        Console.WriteLine($"Shape: {s.TypeOfShape}, Lenght: {s.Lenght}, Width: {s.Width}, Left Cathetus: {s.CathetusLeft}, Perimeter: {s.Perimeter:F2}, Area: {s.Area:F2}, Date: {s.CalculationDate}");
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
