using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Calc.Execute;
using ProjectLibrary.Data;
using ProjectLibrary.Enumeration;
using ProjectLibrary.Models;

namespace ProjectLibrary.Calc
{
    public class UpdateCalculation
    {
        public void Update(DbContextOptionsBuilder<AppDBContext> options)
        {
            using (AppDBContext dbContext = new AppDBContext(options.Options))
            {
                bool isRunning = true;
                do
                {
                    Console.WriteLine("Update a Calculation.");
                    foreach (Calculator c in dbContext.Calculator.Where(c => c.IsActive == true))
                    {
                        if (c.MathOperator == MathOperator.SquareRoot)
                            Console.WriteLine($"Id: {c.Id}, A: {c.A}, Math Operator: {c.MathOperator} {c.MathOperatorSymbol}, Sum: {c.Sum}, Date: {c.CalculationDate}, Active: {c.IsActive}");
                        else
                            Console.WriteLine($"Id: {c.Id}, A: {c.A}, Math Operator: {c.MathOperator} {c.MathOperatorSymbol}, B: {c.B}, Sum: {c.Sum}, Date: {c.CalculationDate}, Active: {c.IsActive}");
                    }

                    Console.WriteLine();
                    Console.Write("Enter a Id of a Calculation you want to Update: ");

                    if (int.TryParse(Console.ReadLine(), out int calculationId))
                    {
                        Calculator? calculationToUpdate = dbContext.Calculator.Find(calculationId);

                        if (calculationToUpdate != null && calculationToUpdate.IsActive)
                        {
                            Console.WriteLine($"Update Calculation with Id {calculationId}");
                            Console.Write("Enter a number: ");

                            if (decimal.TryParse(Console.ReadLine(), out decimal newA))
                            {
                                Console.WriteLine("Choose an Operator:");

                                int operatorNumber = 0;

                                foreach (MathOperator mo in Enum.GetValues(typeof(MathOperator)))
                                    Console.WriteLine($"{++operatorNumber} - {mo}");

                                char? operatorInput = Console.ReadKey().KeyChar;

                                MathOperator newMathOperator;
                                char displayNewMathOperator;

                                switch (operatorInput)
                                {
                                    case '1':
                                        newMathOperator = MathOperator.Addition;
                                        displayNewMathOperator = '+';
                                        break;
                                    case '2':
                                        newMathOperator = MathOperator.Subtraction;
                                        displayNewMathOperator = '-';
                                        break;
                                    case '3':
                                        newMathOperator = MathOperator.Times;
                                        displayNewMathOperator = '*';
                                        break;
                                    case '4':
                                        newMathOperator = MathOperator.Division;
                                        displayNewMathOperator = '/';
                                        break;
                                    case '5':
                                        newMathOperator = MathOperator.NthSquareRoot;
                                        displayNewMathOperator = '√';
                                        break;
                                    case '6':
                                        newMathOperator = MathOperator.Modulus;
                                        displayNewMathOperator = '%';
                                        break;
                                    case '7':
                                        newMathOperator = MathOperator.SquareRoot;
                                        displayNewMathOperator = '√';
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Invalid Operator!");
                                        Console.ResetColor();
                                        continue;
                                }
                                if (newMathOperator != MathOperator.SquareRoot)
                                {
                                    Console.WriteLine();
                                    Console.Write("Enter a second number: ");
                                    string? secondInput = Console.ReadLine();

                                    if (decimal.TryParse(secondInput, out decimal newB))
                                    {
                                        Console.WriteLine($"{newA} {displayNewMathOperator} {newB}");

                                        CalcStrategy calcStrategy = new CalcStrategy();

                                        decimal newSum = 0;
                                        DateOnly newDay = DateOnly.FromDateTime(DateTime.Now);

                                        if (newMathOperator == MathOperator.Addition)
                                        {
                                            calcStrategy.setCalcStrategy(new Addition());
                                            newSum = calcStrategy.ExecuteCalcStrategy(newA, newB);
                                            Console.WriteLine($"Answer: {newSum}");
                                        }
                                        else if (newMathOperator == MathOperator.Subtraction)
                                        {
                                            calcStrategy.setCalcStrategy(new Subtraction());
                                            newSum = calcStrategy.ExecuteCalcStrategy(newA, newB);
                                            Console.WriteLine($"Answer: {newSum}");
                                        }
                                        else if (newMathOperator == MathOperator.Times)
                                        {
                                            calcStrategy.setCalcStrategy(new Times());
                                            newSum = calcStrategy.ExecuteCalcStrategy(newA, newB);
                                            Console.WriteLine($"Answer: {newSum}");
                                        }
                                        else if (newMathOperator == MathOperator.Division)
                                        {
                                            calcStrategy.setCalcStrategy(new Division());
                                            newSum = calcStrategy.ExecuteCalcStrategy(newA, newB);
                                            Console.WriteLine($"Answer: {newSum}");
                                        }
                                        else if (newMathOperator == MathOperator.NthSquareRoot)
                                        {
                                            calcStrategy.setCalcStrategy(new NthSquareRoot());
                                            newSum = calcStrategy.ExecuteCalcStrategy(newA, newB);
                                            Console.WriteLine($"Answer: {newSum:F2}");
                                        }
                                        else if (newMathOperator == MathOperator.Modulus)
                                        {
                                            calcStrategy.setCalcStrategy(new Modulus());
                                            newSum = calcStrategy.ExecuteCalcStrategy(newA, newB);
                                            Console.WriteLine($"Answer: {newSum}");
                                        }

                                        calculationToUpdate.A = newA;
                                        calculationToUpdate.MathOperator = newMathOperator;
                                        calculationToUpdate.MathOperatorSymbol = displayNewMathOperator;
                                        calculationToUpdate.B = newB;
                                        calculationToUpdate.Sum = newSum;
                                        calculationToUpdate.CalculationDate = newDay;
                                        dbContext.SaveChanges();

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"Successfully Updated Calculation with Id {calculationId}.");
                                        Console.ResetColor();

                                        GoAgain goAgain = new GoAgain();

                                        string message = "Do you want to Update something else?";
                                        string restart = goAgain.Restart(message);

                                        if (restart == "yes")
                                            Console.Clear();
                                        else
                                        {
                                            isRunning = false;
                                            Console.WriteLine();
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
                                else if (newMathOperator == MathOperator.SquareRoot)
                                {
                                    SquareRoot squareRoot = new SquareRoot();
                                    GoAgain goAgain = new GoAgain();

                                    DateOnly newDay = DateOnly.FromDateTime(DateTime.Now);
                                    decimal newSum = squareRoot.Calc(newA);

                                    Console.WriteLine();
                                    Console.WriteLine($"√{newA}");
                                    Console.WriteLine($"Answer: {newSum}");

                                    calculationToUpdate.A = newA;
                                    calculationToUpdate.MathOperator = newMathOperator;
                                    calculationToUpdate.MathOperatorSymbol = displayNewMathOperator;
                                    calculationToUpdate.B = null;
                                    calculationToUpdate.Sum = newSum;
                                    calculationToUpdate.CalculationDate = newDay;
                                    dbContext.SaveChanges();

                                    string message = "Do you want to Update something else?";
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
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"No Active Calculation found with Id {calculationId}");
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
