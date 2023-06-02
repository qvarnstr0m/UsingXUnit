using Microsoft.Extensions.Logging;
using Moq;
using UsingXUnit.Interfaces;

namespace UsingXUnit.UnitTests;

public class UserInterfaceTests
{
    [Fact]
    public void Menu_ShouldLoopUntilExitOptionIsSelected()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockInputReader = new Mock<IConsole>();
        mockInputReader.SetupSequence(x => x.ReadLine())
            .Returns("5")
            .Returns("6");
        
        var userInterface = new UserInterface(mockInputReader.Object, mockLogger.Object);
        
        // Act
        userInterface.Menu();
        
        // Assert
        mockInputReader.Verify(x => x.ReadLine(), Times.Exactly(2));
    }
    
    [Fact]
    public void Menu_ShouldCallGetNumbersFromUser_WhenAddOptionIsSelected()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockConsole = new Mock<IConsole>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns("1")  // Input for menu selection
            .Returns("3")  // Input for the first number
            .Returns("4")  // Input for the second number
            .Returns("6"); // Input to exit the menu

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object);
    
        // Act
        userInterface.Menu();
    
        // Assert
        mockConsole.Verify(x => x.Write("Enter the first number: "), Times.Once);
        mockConsole.Verify(x => x.Write("Enter the second number: "), Times.Once);
        mockConsole.Verify(x => x.ReadLine(), Times.Exactly(4));
    }
    
    [Theory]
    [InlineData("3", "s")]
    [InlineData("s", "6")]
    [InlineData("s", "s")]
    public void GetNumbersFromUser_ShouldCatchExceptionAndReturnEmptyList_WhenUserEntersInvalidNumber(string firstInput, string secondInput)
    {
        // Arrange
        var mockConsole = new Mock<IConsole>();
        var mockLogger = new Mock<ILogger<UserInterface>>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns(firstInput)
            .Returns(secondInput); 

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object);
    
        // Act
        var numberList = userInterface.GetNumbersFromUser();
    
        // Assert
        Assert.Empty(numberList);
    }
    
    [Theory]
    [InlineData("3", "3")]
    [InlineData("3,3", "6")]
    [InlineData("3", "9,9")]
    public void GetNumbersFromUser_ShouldListOfTwoDoubles_WhenUserEntersValidNumbers(string firstInput, string secondInput)
    {
        // Arrange
        var mockConsole = new Mock<IConsole>();
        var mockLogger = new Mock<ILogger<UserInterface>>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns(firstInput)
            .Returns(secondInput); 

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object);
    
        // Act
        List<double> numberList = userInterface.GetNumbersFromUser();
    
        // Assert
        Assert.Equal(2, numberList.Count);
    }
}