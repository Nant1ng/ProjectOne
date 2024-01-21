# ProjectOne

## Shape
* Description: The Shape module in ProjectOne allows users to input dimensions and calculates area and perimeter for various geometric shapes, including rectangles, parallelograms, triangles, and rhombuses.
* Methodologies/Patterns/Principles Used:
  * Object-Oriented Programming (OOP): Utilized for creating shape entities and encapsulating properties and methods.
  * Factory Pattern: Implemented to create instances of different shapes based on user input.
  * SOLID Principles: Adhered to for maintainable and scalable code. For example, the Single Responsibility Principle is            applied to ensure each class has a single job.
  * Methods:
    * Create:
      * Allows the user to create a new geometric shape entity. The user inputs the necessary dimensions (like length, width, or sides), and the shape is then stored with these properties.
    * Read:
      *  Retrieves and displays information about existing geometric shapes from the database. This can include details like type of shape, dimensions, area, and perimeter.
    * Update:
      * Enables modification of existing shape entities. Users can alter the dimensions or properties of a shape, and the system recalculates and updates the area and perimeter as necessary.
    * Delete:
      * Removes a shape entity from the database. As with other components, this might involve a soft delete mechanism.
    * Recover:
      * Restores a previously deleted shape entity, making it active and visible in the system again.
    * Rectangle, Perimeter and Area:
      * Calculates the area and perimeter of a rectangle based on its length and width.
    * Parallelogram, Perimeter and Area:
      * Computes the area and perimeter of a parallelogram given its base, height, and side length.
    * Triangle, Perimeter and Area:
      * Calculates the area and perimeter of a triangle, with input parameters varying based on the type of triangle (e.g., equilateral, isosceles, or scalene).
    * Rhombus, Perimeter and Area:
      * Determines the area and perimeter of a rhombus, typically requiring inputs such as the lengths of its diagonals and sides.

## Calculator
* Description: This module performs basic arithmetic operations. Users can input two numbers and an operator, and the application returns the calculated result.
* Methodologies/Patterns/Principles Used:
  * Command Pattern: Used for encapsulating arithmetic operations, allowing for easy extension with new operations.
  * Strategy Pattern: Allows switching between different arithmetic operations at runtime.
  * Error Handling: Robust error handling for invalid inputs and arithmetic exceptions.
* Methods:
  * Create:
    * Create a new calculation. This involves inputting numbers and selecting an operation to perform a mathematical       calculation.
  * Read:
    * Displays existing calculations. This method retrieves and shows the details of past calculations, including the numbers used, the operation performed, and the result.
  * Update:
    * Modify an existing calculation. This allows changes to be made to the numbers or the mathematical operation of a previously stored calculation.
  * Delete:
    * Removes a calculation from the display or database. This is a soft delete where the data is hidden but not permanently removed.
  * Recover:
    * Restores a previously deleted calculation. Useful in cases of soft deletes where the user wants to retrieve and display a calculation that was earlier removed.
  * Addition:
    * Takes two decimal numbers and adds them together to get the sum.
  * Subtraction:
    * Subtracts the second decimal number from the first, providing the difference between the two numbers.
  * Times:
    * Multiplies two decimal numbers together to get the product.
  * Division:
    * Divides the first decimal number by the second, resulting in the quotient. Handles division by zero by providing an appropriate error message or alternative result.
  * NthSquareRoot:
    * Calculates the nth root of a given decimal number, where 'n' is a specified value.
  * Modulus:
    * Computes the remainder of the division of the first decimal number by the second.
  * SquareRoot:
    * Calculates the square root of a given decimal number.

## Rock Paper Scissor
* Description: An interactive game where users can play Rock Paper Scissors against the computer. The outcomes of the games (win/lose/draw) are tracked and stored.
* Methodologies/Patterns/Principles Used:
* Randomization: For the computer's choices, ensuring unpredictability in each game.
MVC Pattern (Model-View-Controller): Applied to separate the game logic (model), user interface (view), and the control flow (controller).
* Data Persistence: Game results are stored and retrieved from a database, demonstrating Create and Read operations from CRUD. Currently, the system is designed to maintain a permanent record of each game, hence Update and Delete operations are not implemented in this module.
* Methods:
  * Game:
    * This is the main method that orchestrates the Rock Paper Scissors game. It initiates each round of the game, invokes methods to get choices from the user and the computer, determines the result of each round, and updates the game statistics.
  * GetUserChoice:
    * Prompts the user to select an option (Rock, Paper, or Scissors). It ensures the user input is valid and converts it into a format that can be used in the game logic.
  * GetComputerChoice:
    * Randomly generates the computer's selection for the game, choosing between Rock, Paper, or Scissors. This method ensures a fair and unpredictable choice by the computer in each round.
  * DetermineResult:
    * Compares the choices made by the user and the computer to determine the outcome of a game round. It follows the standard rules of Rock Paper Scissors to ascertain whether the round results in a win, loss, or draw for the user.
  * UpdateGameStats:
    * After each round, this method updates the game statistics, including the number of games played, wins, losses, and draws. It ensures the game history is accurately recorded and allows for statistical analysis of the player's performance over time.
