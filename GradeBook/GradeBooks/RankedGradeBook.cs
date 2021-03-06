﻿using System.Globalization;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isweighted) : base(name, isweighted)
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

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {

            if (Students.Count < 5)
            {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
