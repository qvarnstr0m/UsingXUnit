using UsingXUnit.Interfaces;

namespace UsingXUnit;

public class Calculator
{
    private readonly IUserInterface _userInterface;

    public Calculator()
    {
        
    }
    
    public Calculator(IUserInterface userInterface)
    {
        _userInterface = userInterface;
    }

    public void Run()
    {
        _userInterface.Menu();
    }
    
    public double Add(double a, double b)
    {
        return a + b;
    }
    
    public double Subtract(double a, double b)
    {
        return a - b;
    }
    
    public double Multiply(double a, double b)
    {
        return a * b;
    }
    
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException();
        }
        return a / b;
    }
}