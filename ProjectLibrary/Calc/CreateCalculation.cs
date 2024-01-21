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
                                mathOperator = MathOperator.NthSquareRoot;
                                displayMathOperator = '√';
                                break;
                            case '6':
                                mathOperator = MathOperator.Modulus;
                                displayMathOperator = '%';
                                break;
                            case '7':
                                mathOperator = MathOperator.SquareRoot;
                                displayMathOperator = '√';
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

                            if (decimal.TryParse(Console.ReadLine(), out decimal b))
                            {
                                Console.WriteLine($"{a} {displayMathOperator} {b}");

                                CalcStrategy calcStrategy = new CalcStrategy();

                                decimal sum = 0;
                                DateOnly today = DateOnly.FromDateTime(DateTime.Now);

                                if (mathOperator == MathOperator.Addition)
                                {
                                    calcStrategy.setCalcStrategy(new Addition());
                                    sum = calcStrategy.ExecuteCalcStrategy(a, b);
                                    Console.WriteLine($"Answer: {sum:F2}");
                                }
                                else if (mathOperator == MathOperator.Subtraction)
                                {
                                    calcStrategy.setCalcStrategy(new Subtraction());
                                    sum = calcStrategy.ExecuteCalcStrategy(a, b);
                                    Console.WriteLine($"Answer: {sum:F2}");
                                }
                                else if (mathOperator == MathOperator.Times)
                                {
                                    calcStrategy.setCalcStrategy(new Times());
                                    sum = calcStrategy.ExecuteCalcStrategy(a, b);
                                    Console.WriteLine($"Answer: {sum:F2}");
                                }
                                else if (mathOperator == MathOperator.Division)
                                {
                                    calcStrategy.setCalcStrategy(new Division());
                                    sum = calcStrategy.ExecuteCalcStrategy(a, b);
                                    Console.WriteLine($"Answer: {sum:F2}");
                                }
                                else if (mathOperator == MathOperator.NthSquareRoot)
                                {
                                    calcStrategy.setCalcStrategy(new NthSquareRoot());
                                    sum = calcStrategy.ExecuteCalcStrategy(a, b);
                                    Console.WriteLine($"Answer: {sum:F2}");
                                }
                                else if (mathOperator == MathOperator.Modulus)
                                {
                                    calcStrategy.setCalcStrategy(new Modulus());
                                    sum = calcStrategy.ExecuteCalcStrategy(a, b);
                                    Console.WriteLine($"Answer: {sum:F2}");
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
                            Console.WriteLine($"Answer: {sum:F2}");

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