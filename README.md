# Using TDD, XUnit and Entity Framework. 
## Intro
Simple console app that serves as a basic calculator developed from acceptance tests and using TDD, which was the point in this school assignment so no focus on the calculator but rather on the tests and TDD.  
  
This is my first stab at test driven development and I took it pretty seriously, no code was written before a unit test was there to turn red before turning green. A fun experience and I hope to be able to continue working this way in the future.  
  
The inital development phase may take more time using TDD, but I feel it probably can be worth it since it should result in better code quality and a project that is more understandable and maintainable.  

## Techstack & tools
+ .NET 6.0
+ Entity Framework
+ Moq
+ XUnit
+ Jetbrains Rider
+ Docker for running SQL Server on MacOs
+ Jetbrains Datagrip for manual DB checking

## Acceptance Tests.

### Test 1: Perform an addition.
+ Open the application
+ Choose the operation: Addition
+ Enter the first number, e.g. "5"
+ Enter the second number, e.g. "7"
+ Press Enter
+ Check that the result is displayed as "12". 

Expected result: The application presents the result "12" after the user has entered the numbers "5" and "7" and selected the operation of addition.  

### Test 2: Perform a subtraction.
+ Open the application
+ Choose the operation: Subtraction
+ Enter the first number, e.g. "5"
+ Enter the second number, e.g. "7"
+ Press Enter
+ Check that the result is displayed as "-2". 

Expected result: The application presents the result "-2" after the user has entered the numbers "5" and "7" and selected the operation of subtraction.

### Test 3: Perform a multiplication.
+ Open the application
+ Choose the operation: Multiplication
+ Enter the first number, e.g. "5"
+ Enter the second number, e.g. "7"
+ Press Enter
+ Check that the result is displayed as "35". 

Expected result: The application presents the result "35" after the user has entered the numbers "5" and "7" and selected the operation of multiplication.
