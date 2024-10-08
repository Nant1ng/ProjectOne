﻿using ProjectLibrary.Enumeration;

namespace ProjectLibrary.Models
{
    /// <summary>
    /// Represents a geometric shape. This class holds information about the type of shape,
    /// its length, width, perimeter, and area. It is used to calculate and store the properties of a shape.
    /// </summary>
    public class Shape
    {
        public int Id { get; set; }
        public TypeOfShape TypeOfShape { get; set; }
        public double Lenght { get; set; }
        public double Width { get; set; }
        public double? CathetusLeft { get; set; }
        public double? CathetusRight { get; set; }
        public double Perimeter { get; set; }
        public double Area { get; set; }
        public DateOnly CalculationDate { get; set; }
        public bool IsActive { get; set; } = true;

        public Shape(TypeOfShape typeOfShape, double lenght, double width, double? cathetusLeft, double? cathetusRight, double perimeter, double area, DateOnly calculationDate)
        {
            TypeOfShape = typeOfShape;
            Lenght = lenght;
            Width = width;
            CathetusLeft = cathetusLeft;
            CathetusRight = cathetusRight;
            Perimeter = perimeter;
            Area = area;
            CalculationDate = calculationDate;
        }
    }
}
