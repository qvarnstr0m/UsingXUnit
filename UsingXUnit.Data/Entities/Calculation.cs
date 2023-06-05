namespace UsingXUnit.Data.Entities;

public class Calculation
{
    public double FirstNumber { get; set; }
    public double SecondNumber { get; set; }
    public char Operation { get; set; }
    public double Result { get; set; }
    
    //Constructor
    public Calculation(double firstNumber, double secondNumber, char operation, double result)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
        Operation = operation;
        Result = result;
    }
}