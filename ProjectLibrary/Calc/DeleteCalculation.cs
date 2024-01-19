using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data;
using ProjectLibrary.Models;

namespace ProjectLibrary.Calc
{
    public class DeleteCalculation
    {
        public void Delete(DbContextOptionsBuilder<AppDBContext> options)
        {
            using (AppDBContext dbContext = new AppDBContext(options.Options))
            {
                bool isRunning = true;
                do
                {
                    Console.WriteLine("Delete a Calculation.");

                    foreach (Calculator c in dbContext.Calculator.Where(c => c.IsActive == true))
                        Console.WriteLine($"Id: {c.Id}, A: {c.A}, Math Operator: {c.MathOperator} {c.MathOperatorSymbol}, B: {c.B}, Sum: {c.Sum}, Date: {c.CalculationDate}, Active: {c.IsActive}");

                    Console.WriteLine();
                    Console.WriteLine("Enter the Id of a Calculation you want to Delete: ");

                    if (int.TryParse(Console.ReadLine(), out int calculationId))
                    {
                        Calculator? calculationToDelete = dbContext.Calculator.Find(calculationId);

                        if (calculationToDelete != null && calculationToDelete.IsActive == true)
                        {
                            calculationToDelete.IsActive = false;
                            dbContext.SaveChanges();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Successfully Soft-Deleted Calculation with Id {calculationId}.");
                            Console.ResetColor();

                            GoAgain goAgain = new GoAgain();

                            string message = "Do you want to Delete another calculation?";
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
                            Console.WriteLine($"No Active Calculation found with Id {calculationId}");
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
