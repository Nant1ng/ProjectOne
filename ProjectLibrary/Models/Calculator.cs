using ProjectLibrary.Enumeration;

namespace ProjectLibrary.Models
{
    public class Calculator
    {
        public int Id { get; set; }
        public decimal A { get; set; }
        public Operator Operator { get; set; }
        public decimal B { get; set; }
        public decimal Sum { get; set; }

    }
}
