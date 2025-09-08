namespace UserInterface.Models
{
    public class CalculationResult
    {
        public int A { get; set; }
        public int B { get; set; }
        public string? Operation { get; set; }
        public string? Result { get; set; } // Use string for error messages or decimal output
    }
}
