using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data;
using ProjectLibrary.Enumeration;
using ProjectLibrary.Models;

namespace ProjectLibrary.Calc
{
    public class RecoverCalculation
    {
        public void Recover(DbContextOptionsBuilder<AppDBContext> options)
        {
            using (AppDBContext dbContext = new AppDBContext(options.Options))
            {
                bool isRunning = true;
                do
                {
                    Console.WriteLine("Recover a Calculation.");

                    foreach (Calculator c in dbContext.Calculator.Where(c => !c.IsActive))
                    {
                        if (c.MathOperator == MathOperator.SquareRoot)
                            Console.WriteLine($"Id: {c.Id}, A: {c.A}, Math Operator: {c.MathOperator} {c.MathOperatorSymbol}, Sum: {c.Sum}, Date: {c.CalculationDate}, Active: {c.IsActive}");
                        else
                            Console.WriteLine($"A: {c.A}, Math Operator: {c.MathOperator} {c.MathOperatorSymbol}, B: {c.B}, Sum: {c.Sum}, Date: {c.CalculationDate}, Active: {c.IsActive}");
                    }

                    Console.WriteLine();
                    Console.Write("Enter the Id of a Calculation you want to Recover: ");

                    if (int.TryParse(Console.ReadLine(), out int calculationId))
                    {
                        Calculator? calculationToRecover = dbContext.Calculator.Find(calculationId);

                        if (calculationToRecover != null && calculationToRecover.IsActive == false)
                        {
                            calculationToRecover.IsActive = true;
                            dbContext.SaveChanges();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Successfully Recovered Calculation with Id {calculationId}.");
                            Console.ResetColor();

                            GoAgain goAgain = new GoAgain();

                            string message = "Do you want to Recover another calculation?";
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
                            Console.WriteLine($"No InActive Calculation found with Id {calculationId}");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid input. Please enter a vaild Calculation Id.");
                        Console.ResetColor();
                    }
                } while (isRunning);
            }
        }
    }
}
