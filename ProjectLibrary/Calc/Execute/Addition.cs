using ProjectLibrary.Interface;

namespace ProjectLibrary.Calc.Execute
{
    public class Addition : ICalc
    {
        public decimal Calc(decimal a, decimal b)
        {
            decimal sum = a + b;
            return sum;
        }
    }
}
