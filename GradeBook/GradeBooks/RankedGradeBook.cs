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
            if(base.Students.Count < 5)
            {
                return 'F';
            }
            return base.GetLetterGrade(averageGrade);
        }
    }
}
