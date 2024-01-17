﻿using ProjectLibrary.Enumeration;

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
        public decimal B { get; set; }
        public decimal Sum { get; set; }

        public Calculator(decimal a, MathOperator mathOperator, decimal b, decimal sum)
        {
            A = a;
            MathOperator = mathOperator;
            B = b;
            Sum = sum;
        }
    }
}
