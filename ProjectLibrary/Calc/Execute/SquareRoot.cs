namespace ProjectLibrary.Calc.Execute
{
    public class SquareRoot
    {
        public decimal Calc(decimal a)
        {
            double result = Math.Sqrt((double)a);
            return (decimal)result;
        }
    }
}
