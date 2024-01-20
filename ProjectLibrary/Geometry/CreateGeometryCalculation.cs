using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data;
using ProjectLibrary.Enumeration;
using ProjectLibrary.Geometry.Execute;
using ProjectLibrary.Models;

namespace ProjectLibrary.Geometry
{
    public class CreateGeometryCalculation
    {
        public void Create(DbContextOptionsBuilder<AppDBContext> options)
        {
            using (AppDBContext dbContext = new AppDBContext(options.Options))
            {
                bool isRunning = true;
                do
                {
                    Console.WriteLine("What shape do you want to calculate? ");

                    int shapeNumber = 0;

                    foreach (TypeOfShape s in Enum.GetValues(typeof(TypeOfShape)))
                        Console.WriteLine($"{++shapeNumber} - {s}");

                    char? shapeInput = Console.ReadKey().KeyChar;

                    TypeOfShape shape;

                    switch (shapeInput)
                    {
                        case '1':
                            shape = TypeOfShape.Rectangle; break;
                        case '2':
                            shape = TypeOfShape.Parallelogram; break;
                        case '3':
                            shape = TypeOfShape.Triangle; break;
                        case '4':
                            shape = TypeOfShape.Rhombus; break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Invalid Shape.");
                            Console.ResetColor();
                            continue;
                    }

                    if (shape != TypeOfShape.Triangle && shape != TypeOfShape.Parallelogram)
                    {
                        Console.WriteLine();
                        Console.Write($"Enter the Lenght of the {shape}: ");

                        if (double.TryParse(Console.ReadLine(), out double lenght) && lenght > 0)
                        {
                            Console.Write($"Enter the Width of the {shape}: ");

                            if (double.TryParse(Console.ReadLine(), out double width) && width > 0)
                            {
                                RectanglePerimeter rectanglePerimeter = new RectanglePerimeter();
                                RectangleArea rectangleArea = new RectangleArea();
                                RhombusPerimeter rhombusPerimeter = new RhombusPerimeter();
                                RhombusArea rhombusArea = new RhombusArea();

                                double perimeter = 0;
                                double area = 0;

                                if (shape == TypeOfShape.Rectangle)
                                {
                                    perimeter = rectanglePerimeter.CalcPerimeter(width, lenght);
                                    area = rectangleArea.CalcArea(width, lenght);
                                }
                                else if (shape == TypeOfShape.Rhombus)
                                {
                                    perimeter = rhombusPerimeter.CalcPerimeter(width);
                                    area = rhombusArea.CalcArea(width, lenght);
                                }

                                Console.WriteLine($"Perimeter: {perimeter:F2}");
                                Console.WriteLine($"Area: {area:F2}");

                                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                                Shape newShape = new Shape(shape, lenght, width, null, null, perimeter, area, today);
                                GoAgain goAgain = new GoAgain();

                                dbContext.Shape.Add(newShape);
                                dbContext.SaveChanges();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Successfully Created a Geometry Calculation.");
                                Console.ResetColor();

                                string message = "Do you want calculate something else?";
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
                    else if (shape == TypeOfShape.Parallelogram)
                    {
                        Console.WriteLine();
                        Console.Write($"Enter the Lenght of the {shape}: ");

                        if (double.TryParse(Console.ReadLine(), out double lenght) && lenght > 0)
                        {
                            Console.Write($"Enter the Width of the {shape}: ");

                            if (double.TryParse(Console.ReadLine(), out double width) && width > 0)
                            {
                                Console.Write($"Enter the Left Cathetus of the {shape}: ");

                                if (double.TryParse(Console.ReadLine(), out double cathetusLeft) && cathetusLeft > 0)
                                {
                                    ParallelogramPerimeter parallelogramPerimeter = new ParallelogramPerimeter();
                                    ParallelogramArea parallelogramArea = new ParallelogramArea();

                                    double perimeter = parallelogramPerimeter.CalcPerimeter(width, cathetusLeft);
                                    double area = parallelogramArea.CalcArea(width, lenght);

                                    Console.WriteLine($"Perimeter: {perimeter:F2}");
                                    Console.WriteLine($"Area: {area:F2}");

                                    DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                                    Shape newShape = new Shape(shape, lenght, width, cathetusLeft, null, perimeter, area, today);
                                    GoAgain goAgain = new GoAgain();

                                    dbContext.Shape.Add(newShape);
                                    dbContext.SaveChanges();

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Successfully Created a Geometry Calculation.");
                                    Console.ResetColor();

                                    string message = "Do you want calculate something else?";
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
                    else if (shape == TypeOfShape.Triangle)
                    {
                        Console.WriteLine();
                        Console.Write($"Enter the Lenght of the {shape}: ");

                        if (double.TryParse(Console.ReadLine(), out double lenght) && lenght > 0)
                        {
                            Console.Write($"Enter the Width of the {shape}: ");

                            if (double.TryParse(Console.ReadLine(), out double width) && width > 0)
                            {
                                Console.Write($"Enter the Left Cathetus of the {shape}: ");

                                if (double.TryParse(Console.ReadLine(), out double cathetusLeft) && cathetusLeft > 0)
                                {
                                    Console.Write($"Enter the Right Cathetus of the {shape}: ");

                                    if (double.TryParse(Console.ReadLine(), out double cathetusRight) && cathetusRight > 0)
                                    {
                                        TrianglePerimeter trianglePerimeter = new TrianglePerimeter();
                                        TriangleArea triangleArea = new TriangleArea();

                                        double perimeter = trianglePerimeter.CalcPerimeter(width, cathetusLeft, cathetusRight);
                                        double area = triangleArea.CalcArea(width, lenght);

                                        Console.WriteLine($"Perimeter: {perimeter:F2}");
                                        Console.WriteLine($"Area: {area:F2}");

                                        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                                        Shape newShape = new Shape(shape, lenght, width, cathetusLeft, cathetusRight, perimeter, area, today);
                                        GoAgain goAgain = new GoAgain();

                                        dbContext.Shape.Add(newShape);
                                        dbContext.SaveChanges();

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"Successfully Created a Geometry Calculation.");
                                        Console.ResetColor();

                                        string message = "Do you want calculate something else?";
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
                } while (isRunning);
            }
        }
    }
}
