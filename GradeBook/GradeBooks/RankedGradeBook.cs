using System.Globalization;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {

            var StudentNumber = base.Students.Count;
            if(StudentNumber < 5)
                throw new InvalidOperationException("Ranked Grading Requires at least 5 students");

            var treshhold = (int)Math.Ceiling(StudentNumber * 0.2); // Since we want to grade students divided into 5 groups (A,B,C,D,F) 0.2 = 1/5

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[treshhold - 1] <= averageGrade)
                return 'A';
            else if (grades[(treshhold * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(treshhold * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(treshhold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}
