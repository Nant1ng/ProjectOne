using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data;
using ProjectLibrary.Enumeration;
using ProjectLibrary.Models;

namespace ProjectLibrary.Geometry
{
    public class RecoverGeometryCalculation
    {
        public void Recover(DbContextOptionsBuilder<AppDBContext> options)
        {
            using (AppDBContext dbContext = new AppDBContext(options.Options))
            {
                bool isRunning = true;
                do
                {
                    Console.WriteLine("Recover a Geometry Calculation.");
                    Console.WriteLine("Write exit if you want to go back.");
                    Console.WriteLine();

                    foreach (Shape s in dbContext.Shape.Where(s => !s.IsActive))
                    {
                        if (s.TypeOfShape == TypeOfShape.Rectangle || s.TypeOfShape == TypeOfShape.Rhombus)
                            Console.WriteLine($"Id: {s.Id}, Shape: {s.TypeOfShape}, Perimeter: {s.Perimeter}, Area: {s.Area}, Date: {s.CalculationDate}, Active: {s.IsActive}");
                        else if (s.TypeOfShape == TypeOfShape.Triangle)
                            Console.WriteLine($"Id: {s.Id}, Shape: {s.TypeOfShape}, Perimeter: {s.Perimeter:F2}, Area: {s.Area:F2}, Date: {s.CalculationDate}, Active: {s.IsActive}");
                        else if (s.TypeOfShape == TypeOfShape.Parallelogram)
                            Console.WriteLine($"Id: {s.Id}, Shape: {s.TypeOfShape}, Perimeter: {s.Perimeter:F2}, Area: {s.Area:F2}, Date: {s.CalculationDate}, Active: {s.IsActive}");
                    }

                    Console.WriteLine();
                    Console.Write("Enter the Id of the Geometry Calculation you want to Recover: ");
                    string? userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out int geometryCalculationId))
                    {
                        Shape? shapeToRecover = dbContext.Shape.Find(geometryCalculationId);

                        if (shapeToRecover != null && !shapeToRecover.IsActive)
                        {
                            shapeToRecover.IsActive = true;
                            dbContext.SaveChanges();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Successfully Recovered a Geometry Calculation with Id {geometryCalculationId}.");
                            Console.ResetColor();

                            GoAgain goAgain = new GoAgain();

                            string message = "Do you want to Recover another Geometry Calculation?";
                            string restart = goAgain.Restart(message);

                            if (restart == "yes")
                                Console.Clear();
                            else
                            {
                                isRunning = false;
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"No InActive Geometry Calculation found with Id {geometryCalculationId}");
                            Console.ResetColor();
                        }
                    }
                    else if (string.Equals(userInput, "exit", StringComparison.OrdinalIgnoreCase))
                    {
                        isRunning = false;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid input. Please enter a vaild Geometry Calculation Id.");
                        Console.ResetColor();
                    }
                } while (isRunning);
            }
        }
    }
}
