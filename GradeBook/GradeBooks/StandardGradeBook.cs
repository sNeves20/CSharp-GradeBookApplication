
namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool isweighted) : base(name, isweighted)
        {
            Type = Enums.GradeBookType.Standard;
        }
    }
}


