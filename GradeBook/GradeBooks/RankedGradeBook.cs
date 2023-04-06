using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            int topGrades = 0;
            int allGrades = 0;
            foreach (Student student in Students)
            {
                allGrades++;
                if (averageGrade >= student.AverageGrade)
                {
                    topGrades++;
                }
            }

            double topPercent = (topGrades / allGrades) * 100;

            if (allGrades < 5)
                throw new InvalidOperationException();
            else
            {
                if (topPercent >= 80)
                    return 'A';
                else if (topPercent >= 60)
                    return 'B';
                else if (topPercent >= 40)
                    return 'C';
                else if (topPercent >= 20)
                    return 'D';
                else
                    return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
                base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
                base.CalculateStudentStatistics(name);
        }
    }
}

