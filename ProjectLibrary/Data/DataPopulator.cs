﻿using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Enumeration;
using ProjectLibrary.Models;

namespace ProjectLibrary.Data
{
    public class DataPopulator
    {
        public void MigrateAndPopulate(AppDBContext dbContext)
        {
            dbContext.Database.Migrate();
            PopulateCalculator(dbContext);
            PopulateRockPaperScissor(dbContext);
            PopulateShape(dbContext);
            dbContext.SaveChanges();
        }
        private void PopulateCalculator(AppDBContext dbContext)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            if (!dbContext.Calculator.Any(c => c.Id == 1))
                dbContext.Calculator.Add(new Calculator(0, MathOperator.Addition, '+', 1, 2, today));
            if (!dbContext.Calculator.Any(c => c.Id == 2))
                dbContext.Calculator.Add(new Calculator(3, MathOperator.Subtraction, '-', 2, 1, today));
            if (!dbContext.Calculator.Any(c => c.Id == 3))
                dbContext.Calculator.Add(new Calculator(1, MathOperator.Times, '*', 1, 1, today));
            if (!dbContext.Calculator.Any(c => c.Id == 4))
                dbContext.Calculator.Add(new Calculator(1, MathOperator.Division, '/', 1, 1, today));
            if (!dbContext.Calculator.Any(c => c.Id == 5))
                dbContext.Calculator.Add(new Calculator(3, MathOperator.NthSquareRoot, '√', 27, 3, today));
            if (!dbContext.Calculator.Any(c => c.Id == 6))
                dbContext.Calculator.Add(new Calculator(10, MathOperator.Modulus, '%', 3, 1, today));
            if (!dbContext.Calculator.Any(c => c.Id == 7))
                dbContext.Calculator.Add(new Calculator(4, MathOperator.SquareRoot, '+', null, 2, today));
        }
        private void PopulateRockPaperScissor(AppDBContext dbContext)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            if (!dbContext.RockPaperScissorGame.Any(rps => rps.Id == 1))
                dbContext.RockPaperScissorGame.Add(new RockPaperSicssorGame(RockPaperScissor.Rock, RockPaperScissor.Rock, Result.Draw, today));
            if (!dbContext.RockPaperScissorGame.Any(rps => rps.Id == 2))
                dbContext.RockPaperScissorGame.Add(new RockPaperSicssorGame(RockPaperScissor.Rock, RockPaperScissor.Scissor, Result.Win, today));
            if (!dbContext.RockPaperScissorGame.Any(rps => rps.Id == 3))
                dbContext.RockPaperScissorGame.Add(new RockPaperSicssorGame(RockPaperScissor.Rock, RockPaperScissor.Paper, Result.Lose, today));
        }
        private void PopulateShape(AppDBContext dbContext)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            if (!dbContext.Shape.Any(s => s.Id == 1))
                dbContext.Shape.Add(new Shape(TypeOfShape.Rectangle, 22, 64, null, null, 172, 1408, today));
            if (!dbContext.Shape.Any(s => s.Id == 2))
                dbContext.Shape.Add(new Shape(TypeOfShape.Parallelogram, 10.1, 37.3, 12.5, null, 99.6, 376.73, today));
            if (!dbContext.Shape.Any(s => s.Id == 3))
                dbContext.Shape.Add(new Shape(TypeOfShape.Triangle, 0.16, 0.34, 0.23, 0.54, 1.11, 0.0272, today));
            if (!dbContext.Shape.Any(s => s.Id == 4))
                dbContext.Shape.Add(new Shape(TypeOfShape.Rhombus, 13, 17, null, null, 68, 221, today));
        }
    }
}
