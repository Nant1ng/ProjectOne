using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data;
using ProjectLibrary.Models;
using ProjectLibrary.Enumeration;

namespace ProjectLibrary.Calc
{
    public class ShowCalculation
    {
        public void Read(DbContextOptionsBuilder<AppDBContext> options)
        {
            using (AppDBContext dbContext = new AppDBContext(options.Options))
            {
                Console.WriteLine("Calculation History.");

                foreach (Calculator c in dbContext.Calculator.Where(c => c.IsActive == true))
                {
                    if (c.MathOperator == MathOperator.SquareRoot)
                        Console.WriteLine($"A: {c.A}, Math Operator: {c.MathOperator} {c.MathOperatorSymbol}, Sum: {c.Sum}, Date: {c.CalculationDate}");
                    else
                        Console.WriteLine($"A: {c.A}, Math Operator: {c.MathOperator} {c.MathOperatorSymbol}, B: {c.B}, Sum: {c.Sum}, Date: {c.CalculationDate}");
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
