using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data;
using ProjectLibrary.Enumeration;
using ProjectLibrary.Geometry.Execute;
using ProjectLibrary.Models;

namespace ProjectLibrary.Geometry
{
    public class UpdateGeometryCalculation
    {
        public void Update(DbContextOptionsBuilder<AppDBContext> options)
        {
            using (AppDBContext dbContext = new AppDBContext(options.Options))
            {
                bool isRunning = true;
                do
                {
                    Console.WriteLine("Update a Geometry Calculation.");

                    foreach (Shape s in dbContext.Shape.Where(s => s.IsActive))
                    {
                        if (s.TypeOfShape == TypeOfShape.Rectangle || s.TypeOfShape == TypeOfShape.Rhombus)
                            Console.WriteLine($"Id: {s.Id}, Shape: {s.TypeOfShape}, Perimeter: {s.Perimeter}, Area: {s.Area}, Date: {s.CalculationDate}, Active: {s.IsActive}");
                        else if (s.TypeOfShape == TypeOfShape.Triangle)
                            Console.WriteLine($"Id: {s.Id}, Shape: {s.TypeOfShape}, Perimeter: {s.Perimeter:F2}, Area: {s.Area:F2}, Date: {s.CalculationDate}, Active: {s.IsActive}");
                        else if (s.TypeOfShape == TypeOfShape.Parallelogram)
                            Console.WriteLine($"Id: {s.Id}, Shape: {s.TypeOfShape}, Perimeter: {s.Perimeter:F2}, Area: {s.Area:F2}, Date: {s.CalculationDate}, Active: {s.IsActive}");
                    }

                    Console.WriteLine();
                    Console.Write("Enter a Id of a Geometry Calculation you want to Update: ");

                    if (int.TryParse(Console.ReadLine(), out int shapeId))
                    {
                        Shape? shapeToUpdate = dbContext.Shape.Find(shapeId);

                        if (shapeToUpdate != null && shapeToUpdate.IsActive)
                        {
                            Console.WriteLine($"Update Geometry Calculation with Id {shapeId}");
                            Console.WriteLine("Enter a new Shape:");

                            int shapeNumber = 0;

                            foreach (TypeOfShape s in Enum.GetValues(typeof(TypeOfShape)))
                                Console.WriteLine($"{++shapeNumber} - {s}");

                            char? shapeInput = Console.ReadKey().KeyChar;

                            TypeOfShape newShape;

                            switch (shapeInput)
                            {
                                case '1':
                                    newShape = TypeOfShape.Rectangle; break;
                                case '2':
                                    newShape = TypeOfShape.Parallelogram; break;
                                case '3':
                                    newShape = TypeOfShape.Triangle; break;
                                case '4':
                                    newShape = TypeOfShape.Rhombus; break;
                                default:
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Invalid Shape.");
                                    Console.ResetColor();
                                    continue;
                            }

                            if (newShape != TypeOfShape.Triangle && newShape != TypeOfShape.Parallelogram)
                            {
                                Console.WriteLine();
                                Console.Write("Enter the new Lenght: ");

                                if (double.TryParse(Console.ReadLine(), out double newLenght) && newLenght > 0)
                                {
                                    Console.WriteLine("Enter the new Width: ");

                                    if (double.TryParse(Console.ReadLine(), out double newWidth) && newWidth > 0)
                                    {
                                        RectanglePerimeter rectanglePerimeter = new RectanglePerimeter();
                                        RectangleArea rectangleArea = new RectangleArea();
                                        RhombusPerimeter rhombusPerimeter = new RhombusPerimeter();
                                        RhombusArea rhombusArea = new RhombusArea();

                                        double newPerimeter = 0;
                                        double newArea = 0;

                                        if (newShape == TypeOfShape.Rectangle)
                                        {
                                            newPerimeter = rectanglePerimeter.CalcPerimeter(newWidth, newLenght);
                                            newArea = rectangleArea.CalcArea(newWidth, newLenght);
                                        }
                                        else if (newShape == TypeOfShape.Rhombus)
                                        {
                                            newPerimeter = rhombusPerimeter.CalcPerimeter(newWidth);
                                            newArea = rhombusArea.CalcArea(newWidth, newLenght);
                                        }

                                        Console.WriteLine($"Perimeter: {newPerimeter:F2}");
                                        Console.WriteLine($"Area: {newArea:F2}");

                                        DateOnly newDay = DateOnly.FromDateTime(DateTime.Now);
                                        GoAgain goAgain = new GoAgain();

                                        shapeToUpdate.TypeOfShape = newShape;
                                        shapeToUpdate.Lenght = newLenght;
                                        shapeToUpdate.Width = newWidth;
                                        shapeToUpdate.CathetusLeft = null;
                                        shapeToUpdate.CathetusRight = null;
                                        shapeToUpdate.Perimeter = newPerimeter;
                                        shapeToUpdate.Area = newArea;
                                        shapeToUpdate.CalculationDate = newDay;
                                        dbContext.SaveChanges();

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"Successfully Updated a Geometry Calculation.");
                                        Console.ResetColor();

                                        string message = "Do you want Update something else?";
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
                                        Console.WriteLine("Invalid input: Please enter a valid number.");
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Invalid input: Please enter a valid number.");
                                    Console.ResetColor();
                                }
                            }
                            else if (newShape == TypeOfShape.Parallelogram)
                            {
                                Console.WriteLine();
                                Console.Write("Enter the new Lenght: ");

                                if (double.TryParse(Console.ReadLine(), out double newLenght) && newLenght > 0)
                                {
                                    Console.Write("Enter the new Width: ");

                                    if (double.TryParse(Console.ReadLine(), out double newWidth) && newWidth > 0)
                                    {
                                        Console.Write("Enter the new Left Cathetus: ");

                                        if (double.TryParse(Console.ReadLine(), out double newCathetusLeft) && newCathetusLeft > 0)
                                        {
                                            ParallelogramPerimeter parallelogramPerimeter = new ParallelogramPerimeter();
                                            ParallelogramArea parallelogramArea = new ParallelogramArea();

                                            double newPerimeter = parallelogramPerimeter.CalcPerimeter(newWidth, newCathetusLeft);
                                            double newArea = parallelogramArea.CalcArea(newWidth, newLenght);

                                            Console.WriteLine($"Perimeter: {newPerimeter:F2}");
                                            Console.WriteLine($"Area: {newArea:F2}");

                                            DateOnly newDay = DateOnly.FromDateTime(DateTime.Now);
                                            GoAgain goAgain = new GoAgain();

                                            shapeToUpdate.TypeOfShape = newShape;
                                            shapeToUpdate.Lenght = newLenght;
                                            shapeToUpdate.Width = newWidth;
                                            shapeToUpdate.CathetusLeft = newCathetusLeft;
                                            shapeToUpdate.CathetusRight = null;
                                            shapeToUpdate.Perimeter = newPerimeter;
                                            shapeToUpdate.Area = newArea;
                                            shapeToUpdate.CalculationDate = newDay;
                                            dbContext.SaveChanges();

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"Successfully Updated a Geometry Calculation.");
                                            Console.ResetColor();

                                            string message = "Do you want Update something else?";
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
                                            Console.WriteLine("Invalid input: Please enter a valid number.");
                                            Console.ResetColor();
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Invalid input: Please enter a valid number.");
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Invalid input: Please enter a valid number.");
                                    Console.ResetColor();
                                }
                            }
                            else if (newShape == TypeOfShape.Triangle)
                            {
                                Console.WriteLine();
                                Console.Write("Enter the new Lenght: ");

                                if (double.TryParse(Console.ReadLine(), out double newLenght) && newLenght > 0)
                                {
                                    Console.Write("Enter the new Width: ");

                                    if (double.TryParse(Console.ReadLine(), out double newWidth) && newWidth > 0)
                                    {
                                        Console.Write("Enter the new Left Cathetus: ");

                                        if (double.TryParse(Console.ReadLine(), out double newCathetusLeft) && newCathetusLeft > 0)
                                        {
                                            Console.WriteLine("Enter the new Right Cathetus: ");

                                            if (double.TryParse(Console.ReadLine(), out double newCathetusRight) && newCathetusRight > 0)
                                            {
                                                TrianglePerimeter trianglePerimeter = new TrianglePerimeter();
                                                TriangleArea triangleArea = new TriangleArea();

                                                double newPerimeter = trianglePerimeter.CalcPerimeter(newWidth, newCathetusLeft, newCathetusRight);
                                                double newArea = triangleArea.CalcArea(newWidth, newLenght);

                                                Console.WriteLine($"Perimeter: {newPerimeter:F2}");
                                                Console.WriteLine($"Area: {newArea:F2}");

                                                DateOnly newDay = DateOnly.FromDateTime(DateTime.Now);
                                                GoAgain goAgain = new GoAgain();

                                                shapeToUpdate.TypeOfShape = newShape;
                                                shapeToUpdate.Lenght = newLenght;
                                                shapeToUpdate.Width = newWidth;
                                                shapeToUpdate.CathetusLeft = newCathetusLeft;
                                                shapeToUpdate.CathetusRight = newCathetusRight;
                                                shapeToUpdate.Perimeter = newPerimeter;
                                                shapeToUpdate.Area = newArea;
                                                shapeToUpdate.CalculationDate = newDay;
                                                dbContext.SaveChanges();

                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine($"Successfully Updated a Geometry Calculation.");
                                                Console.ResetColor();

                                                string message = "Do you want Update something else?";
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
                                                Console.WriteLine("Invalid input: Please enter a valid number.");
                                                Console.ResetColor();
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("Invalid input: Please enter a valid number.");
                                            Console.ResetColor();
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Invalid input: Please enter a valid number.");
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Invalid input: Please enter a valid number.");
                                    Console.ResetColor();
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"No Active Calculation found with Id {shapeId}");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid input: Please enter a valid number.");
                        Console.ResetColor();
                    }
                } while (isRunning);
            }
        }
    }
}