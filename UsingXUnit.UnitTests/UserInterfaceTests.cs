using Microsoft.Extensions.Logging;
using Moq;
using UsingXUnit.Data.Entities;
using UsingXUnit.Data.Repositories.Interfaces;
using UsingXUnit.Interfaces;

namespace UsingXUnit.UnitTests;

public class UserInterfaceTests
{
    [Fact]
    public void Menu_ShouldLoopUntilExitOptionIsSelected()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        var mockInputReader = new Mock<IConsole>();

        mockInputReader.SetupSequence(x => x.ReadLine())
            .Returns("5")
            .Returns("6");

        var userInterface = new UserInterface(mockInputReader.Object, mockLogger.Object, mockRepository.Object);

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
        var mockRepository = new Mock<IRepository<Calculation>>();
        var mockConsole = new Mock<IConsole>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns("1") // Input for menu selection
            .Returns("3") // Input for the first number
            .Returns("4") // Input for the second number
            .Returns("6"); // Input to exit the menu

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

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
    public void GetNumbersFromUser_ShouldCatchExceptionAndReturnEmptyList_WhenUserEntersInvalidNumber(string firstInput,
        string secondInput)
    {
        // Arrange
        var mockConsole = new Mock<IConsole>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        var mockLogger = new Mock<ILogger<UserInterface>>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns(firstInput)
            .Returns(secondInput);

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        var numberList = userInterface.GetNumbersFromUser();

        // Assert
        Assert.Empty(numberList);
    }

    [Theory]
    [InlineData("3", "3")]
    [InlineData("3,3", "6")]
    [InlineData("3", "9,9")]
    public void GetNumbersFromUser_ShouldListOfTwoDoubles_WhenUserEntersValidNumbers(string firstInput,
        string secondInput)
    {
        // Arrange
        var mockConsole = new Mock<IConsole>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        var mockLogger = new Mock<ILogger<UserInterface>>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns(firstInput)
            .Returns(secondInput);

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        List<double> numberList = userInterface.GetNumbersFromUser();

        // Assert
        Assert.Equal(2, numberList.Count);
    }

    [Fact]
    public void PrintResult_ShouldPrintResult_WhenGivenResult()
    {
        // Arrange
        var mockConsole = new Mock<IConsole>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        userInterface.PrintResult(5);

        // Assert
        mockConsole.Verify(x => x.WriteLine("The result is: 5"), Times.Once);
    }

    [Fact]
    public void ReturnToMainMenu_ShouldPrintAndReadLine_WhenCalled()
    {
        // Arrange
        var mockConsole = new Mock<IConsole>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        userInterface.ReturnToMainMenu();

        // Assert
        mockConsole.Verify(x => x.WriteLine("Press any key to return to the main menu..."), Times.Once);
        mockConsole.Verify(x => x.ReadKey(), Times.Once);
    }

    [Fact]
    public void Menu_ShouldCallGetNumbersFromUser_WhenSubtractOptionIsSelected()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        var mockConsole = new Mock<IConsole>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns("2") // Input for menu selection
            .Returns("3") // Input for the first number
            .Returns("4") // Input for the second number
            .Returns("6"); // Input to exit the menu

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        userInterface.Menu();

        // Assert
        mockConsole.Verify(x => x.Write("Enter the first number: "), Times.Once);
        mockConsole.Verify(x => x.Write("Enter the second number: "), Times.Once);
        mockConsole.Verify(x => x.ReadLine(), Times.Exactly(4));
    }

    [Fact]
    public void Menu_ShouldCallGetNumbersFromUser_WhenMultiplyOptionIsSelected()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        var mockConsole = new Mock<IConsole>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns("3") // Input for menu selection
            .Returns("3") // Input for the first number
            .Returns("4") // Input for the second number
            .Returns("6"); // Input to exit the menu

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        userInterface.Menu();

        // Assert
        mockConsole.Verify(x => x.Write("Enter the first number: "), Times.Once);
        mockConsole.Verify(x => x.Write("Enter the second number: "), Times.Once);
        mockConsole.Verify(x => x.ReadLine(), Times.Exactly(4));
    }

    [Fact]
    public void Menu_ShouldCallGetNumbersFromUser_WhenDivideOptionIsSelected()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        var mockConsole = new Mock<IConsole>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns("4") // Input for menu selection
            .Returns("3") // Input for the first number
            .Returns("4") // Input for the second number
            .Returns("6"); // Input to exit the menu

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        userInterface.Menu();

        // Assert
        mockConsole.Verify(x => x.Write("Enter the first number: "), Times.Once);
        mockConsole.Verify(x => x.Write("Enter the second number: "), Times.Once);
        mockConsole.Verify(x => x.ReadLine(), Times.Exactly(4));
    }

    [Fact]
    public void Menu_WhenAddIsCalledAndResultIsPrinted_ShouldCallCreate()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockConsole = new Mock<IConsole>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns("1") // Input for menu selection
            .Returns("3") // Input for the first number
            .Returns("4") // Input for the second number
            .Returns("6"); // Input to exit the menu

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        userInterface.Menu();

        // Assert
        mockRepository.Verify(x => x.Create(It.IsAny<Calculation>()), Times.Once);
    }

    [Fact]
    public void Menu_WhenSubtractIsCalledAndResultIsPrinted_ShouldCallCreate()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockConsole = new Mock<IConsole>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns("2") // Input for menu selection
            .Returns("3") // Input for the first number
            .Returns("4") // Input for the second number
            .Returns("6"); // Input to exit the menu

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        userInterface.Menu();

        // Assert
        mockRepository.Verify(x => x.Create(It.IsAny<Calculation>()), Times.Once);
    }

    [Fact]
    public void Menu_WhenMultiplyIsCalledAndResultIsPrinted_ShouldCallCreate()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockConsole = new Mock<IConsole>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns("3") // Input for menu selection
            .Returns("3") // Input for the first number
            .Returns("4") // Input for the second number
            .Returns("6"); // Input to exit the menu

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        userInterface.Menu();

        // Assert
        mockRepository.Verify(x => x.Create(It.IsAny<Calculation>()), Times.Once);
    }

    [Fact]
    public void Menu_WhenDivideIsCalledAndResultIsPrinted_ShouldCallCreate()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockConsole = new Mock<IConsole>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns("4") // Input for menu selection
            .Returns("3") // Input for the first number
            .Returns("4") // Input for the second number
            .Returns("6"); // Input to exit the menu

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        userInterface.Menu();

        // Assert
        mockRepository.Verify(x => x.Create(It.IsAny<Calculation>()), Times.Once);
    }

    [Fact]
    public void Menu_WhenListPreviousResultsIsCalled_ShouldPrintPreviousResults()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockConsole = new Mock<IConsole>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        mockConsole.SetupSequence(x => x.ReadLine())
            .Returns("5") // Input for menu selection
            .Returns("6"); // Input to exit the menu

        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        userInterface.Menu();

        // Assert
        mockConsole.Verify(x => x.WriteLine("These are the previous calculations:"), Times.Once);
    }

    [Fact]
    public void ListPreviousResults_ShouldCallReadAll()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockConsole = new Mock<IConsole>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        userInterface.ListPreviousResults();

        // Assert
        mockRepository.Verify(x => x.ReadAll(), Times.Once);
    }
    
    [Fact]
    public void ListPreviousResults_ShouldCallWriteLineForEachCalculation()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UserInterface>>();
        var mockConsole = new Mock<IConsole>();
        var mockRepository = new Mock<IRepository<Calculation>>();
        mockRepository.Setup(x => x.ReadAll()).Returns(new List<Calculation>
        {
            new Calculation(3, 4, '+', 7),
            new Calculation(3, 4, '-', -1)
        });
        var userInterface = new UserInterface(mockConsole.Object, mockLogger.Object, mockRepository.Object);

        // Act
        userInterface.ListPreviousResults();

        // Assert
        mockConsole.Verify(x => x.WriteLine("3 + 4 = 7"), Times.Once);
        mockConsole.Verify(x => x.WriteLine("3 - 4 = -1"), Times.Once);
    }
}