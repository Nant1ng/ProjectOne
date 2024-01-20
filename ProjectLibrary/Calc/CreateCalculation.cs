using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Calc.Execute;
using ProjectLibrary.Data;
using ProjectLibrary.Enumeration;
using ProjectLibrary.Models;

namespace ProjectLibrary.Calc
{
    public class CreateCalculation
    {
        public void Create(DbContextOptionsBuilder<AppDBContext> options)
        {
            using (AppDBContext dbContext = new AppDBContext(options.Options))
            {
                bool isRunning = true;
                do
                {
                    Console.WriteLine("Time to do The Math!");
                    Console.Write("Enter a Number: ");

                    if (decimal.TryParse(Console.ReadLine(), out decimal a))
                    {
                        Console.WriteLine("Choose an Operator:");

                        int operatorNumber = 0;

                        foreach (MathOperator mo in Enum.GetValues(typeof(MathOperator)))
                            Console.WriteLine($"{++operatorNumber} - {mo}");

                        char? operatorInput = Console.ReadKey().KeyChar;

                        MathOperator mathOperator;
                        char displayMathOperator;

                        switch (operatorInput)
                        {
                            case '1':
                                mathOperator = MathOperator.Addition;
                                displayMathOperator = '+';
                                break;
                            case '2':
                                mathOperator = MathOperator.Subtraction;
                                displayMathOperator = '-';
                                break;
                            case '3':
                                mathOperator = MathOperator.Times;
                                displayMathOperator = '*';
                                break;
                            case '4':
                                mathOperator = MathOperator.Division;
                                displayMathOperator = '/';
                                break;
                            case '5':
                                mathOperator = MathOperator.SquareRoot;
                                displayMathOperator = '√';
                                break;
                            case '6':
                                mathOperator = MathOperator.Modulus;
                                displayMathOperator = '%';
                                break;
                            default:
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Invalid Operator!");
                                Console.ResetColor();
                                continue;
                        }

                        if (mathOperator != MathOperator.SquareRoot)
                        {
                            Console.WriteLine();
                            Console.Write("Enter a second number: ");
                            string? secondInput = Console.ReadLine();

                            if (decimal.TryParse(secondInput, out decimal b))
                            {
                                Console.WriteLine($"{a} {displayMathOperator} {b}");

                                Addition addition = new Addition();
                                Subtraction subtraction = new Subtraction();
                                Times times = new Times();
                                Division division = new Division();
                                Modulus modulus = new Modulus();

                                decimal sum = 0;
                                DateOnly today = DateOnly.FromDateTime(DateTime.Now);

                                if (mathOperator == MathOperator.Addition)
                                {
                                    sum = addition.Calc(a, b);
                                    Console.WriteLine($"Answer: {sum}");
                                }
                                else if (mathOperator == MathOperator.Subtraction)
                                {
                                    sum = subtraction.Calc(a, b);
                                    Console.WriteLine($"Answer: {sum}");
                                }
                                else if (mathOperator == MathOperator.Times)
                                {
                                    sum = times.Calc(a, b);
                                    Console.WriteLine($"Answer: {sum}");
                                }
                                else if (mathOperator == MathOperator.Division)
                                {
                                    sum = division.Calc(a, b);
                                    Console.WriteLine($"Answer: {sum}");
                                }
                                else if (mathOperator == MathOperator.Modulus)
                                {
                                    sum = modulus.Calc(a, b);
                                    Console.WriteLine($"Answer: {sum}");
                                }

                                Calculator newCalculator = new Calculator(a, mathOperator, displayMathOperator, b, sum, today);
                                GoAgain goAgain = new GoAgain();
                                dbContext.Calculator.Add(newCalculator);
                                dbContext.SaveChanges();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Successfully Created a Calculation.");
                                Console.ResetColor();

                                string message = "Do you want to calculate something else?";
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
                        else if (mathOperator == MathOperator.SquareRoot)
                        {
                            SquareRoot squareRoot = new SquareRoot();
                            GoAgain goAgain = new GoAgain();

                            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                            decimal sum = squareRoot.Calc(a);

                            Console.WriteLine();
                            Console.WriteLine($"√{a}");
                            Console.WriteLine($"Answer: {sum}");

                            Calculator newCalculator = new Calculator(a, mathOperator, displayMathOperator, null, sum, today);
                            dbContext.Calculator.Add(newCalculator);
                            dbContext.SaveChanges();

                            string message = "Do you want to calculate something else?";
                            string restart = goAgain.Restart(message);

                            if (restart == "yes")
                                Console.Clear();
                            else
                            {
                                isRunning = false;
                                Console.Clear();
                            }
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