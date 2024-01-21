using ProjectLibrary.Interface;

namespace ProjectLibrary.Calc
{
    class CalcStrategy
    {
        private ICalc _calc;

        public void setCalcStrategy(ICalc newCalc)
        {
            _calc = newCalc;
        }

        public decimal ExecuteCalcStrategy(decimal a, decimal b)
        {
            return _calc.Calc(a, b);
        }
    }
}
