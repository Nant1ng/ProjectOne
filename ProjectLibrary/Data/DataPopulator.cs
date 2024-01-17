using Microsoft.EntityFrameworkCore;
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
            //PopulateShape(dbContext);
            dbContext.SaveChanges();
        }

        private void PopulateCalculator(AppDBContext dbContext)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            if (!dbContext.Calculator.Any(c => c.Id == 1))
                dbContext.Calculator.Add(new Calculator(1, MathOperator.Plus, 1, 2, today));
        }
        private void PopulateRockPaperScissor(AppDBContext dbContext)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            if (!dbContext.RockPaperScissor.Any(rps => rps.Id == 1))
                dbContext.RockPaperScissor.Add(new RockPaperSicssor(RockPaperScissor.Rock, RockPaperScissor.Rock, Result.Draw, today));
        }
        //private void PopulateShape(AppDBContext dbContext)
        //{
        //    DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        //    if (!dbContext.Shape.Any(s => s.Id == 1))
        //        dbContext.Shape.Add(new Shape());
        //}
    }
}
