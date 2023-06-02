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
}