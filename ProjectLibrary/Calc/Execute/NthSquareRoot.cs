using Microsoft.EntityFrameworkCore.Query.Internal;
using ProjectLibrary.Interface;

namespace ProjectLibrary.Calc.Execute
{
    public class NthSquareRoot : ICalc
    {
        public decimal Calc(decimal a, decimal b)
        {
            double sum = Math.Pow((double)b, 1 / (double)a);
            return (decimal)sum;
        }
    }
}
