using ProjectLibrary.Interface;

namespace ProjectLibrary.Calc.Execute
{
    public class Modulus : ICalc
    {
        public decimal Calc(decimal a, decimal b)
        {
            decimal sum = a % b;
            return sum;
        }
    }
}
