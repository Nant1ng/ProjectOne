using ProjectLibrary.Enumeration;

namespace ProjectLibrary.Models
{
    /// <summary>
    /// Represents a basic calculator operation. It stores operands (A and B), 
    /// the mathematical operator, and the result of the operation (Sum). 
    /// This class can be used to perform and keep track of simple arithmetic calculations.
    /// </summary>
    public class Calculator
    {
        public int Id { get; set; }
        public decimal A { get; set; }
        public MathOperator MathOperator { get; set; }
        public char MathOperatorSymbol { get; set; }
        public decimal? B { get; set; }
        public decimal Sum { get; set; }
        public DateOnly CalculationDate { get; set; }
        public bool IsActive { get; set; } = true;

        public Calculator(decimal a, MathOperator mathOperator, char mathOperatorSymbol, decimal? b, decimal sum, DateOnly calculationDate)
        {
            A = a;
            MathOperator = mathOperator;
            MathOperatorSymbol = mathOperatorSymbol;
            B = b;
            Sum = sum;
            CalculationDate = calculationDate;
        }
    }
}
