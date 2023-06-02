using Moq;
using UsingXUnit.Interfaces;

namespace UsingXUnit.UnitTests;

public class CalculatorTests
{
    [Fact]
    public void Run_ShouldCallMenu_WhenAppIsStarted()
    {
        // Arrange
        var mockUserInterface = new Mock<IUserInterface>();
        var calculator = new Calculator(mockUserInterface.Object);

        // Act
        calculator.Run();

        // Assert
        mockUserInterface.Verify(x => x.Menu(), Times.Once);
    }
    
    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 4)]
    [InlineData(5, 6.3)]
    public void Add_ShouldReturnTheSumOfTwoNumbers(double a, double b)
    {
        // Arrange
        var mockUserInterface = new Mock<IUserInterface>();
        var calculator = new Calculator(mockUserInterface.Object);

        // Act
        var result = calculator.Add(a, b);

        // Assert
        Assert.Equal(a + b, result);
    }
    
    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 4)]
    [InlineData(5, 6.3)]
    public void Subtract_ShouldReturnTheDifferenceOfTwoNumbers(double a, double b)
    {
        // Arrange
        var mockUserInterface = new Mock<IUserInterface>();
        var calculator = new Calculator(mockUserInterface.Object);

        // Act
        var result = calculator.Subtract(a, b);

        // Assert
        Assert.Equal(a - b, result);
    }
    
    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 4)]
    [InlineData(5, 6.3)]
    public void Multiply_ShouldReturnTheProductOfTwoNumbers(double a, double b)
    {
        // Arrange
        var mockUserInterface = new Mock<IUserInterface>();
        var calculator = new Calculator(mockUserInterface.Object);

        // Act
        var result = calculator.Multiply(a, b);

        // Assert
        Assert.Equal(a * b, result);
    }
    
    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 4)]
    [InlineData(5, 6.3)]
    public void Divide_ShouldReturnTheQuotientOfTwoNumbers(double a, double b)
    {
        // Arrange
        var mockUserInterface = new Mock<IUserInterface>();
        var calculator = new Calculator(mockUserInterface.Object);

        // Act
        var result = calculator.Divide(a, b);

        // Assert
        Assert.Equal(a / b, result);
    }
    
    [Fact]
    public void Divide_ShouldThrowDivideByZeroException_WhenSecondNumberIsZero()
    {
        // Arrange
        var mockUserInterface = new Mock<IUserInterface>();
        var calculator = new Calculator(mockUserInterface.Object);

        // Act
        var exception = Assert.Throws<DivideByZeroException>(() => calculator.Divide(1, 0));

        // Assert
        Assert.Equal("Attempted to divide by zero.", exception.Message);
    }
}