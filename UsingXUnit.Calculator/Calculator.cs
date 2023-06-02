using UsingXUnit.Interfaces;

namespace UsingXUnit;

public class Calculator
{
    private readonly IUserInterface _userInterface;

    public Calculator(IUserInterface userInterface)
    {
        _userInterface = userInterface;
    }

    public void Run()
    {
        _userInterface.Menu();
    }
}