namespace HelloWebService.Models
{
    public class MathFunction
    {
        public int FirstOperand { get; set; }
        public int SecondOperand { get;set; }
        

        //public Operations Operation { get; set; }
        public char charOperation { get; set; }
        public string? stringOperation { get; set; }


        public double? Result { get; set; }
    }
    public enum Operations { Add ='+', Subtract='-', Multiple='*', Divide='/'};
    ///public enum Operations { Add, Subtract, Multiple, Divide };
}
