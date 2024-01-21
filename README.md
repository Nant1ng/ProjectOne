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
