using System;

namespace Grades{


public class DisregardGradeBook : GradeBook
{

    public override Statistics ComputeStatistics()
    {
        float lowestGrade = float.MaxValue;
        foreach (float grade in currentGrades)
        {
            lowestGrade = Math.Min(grade, lowestGrade);
        }

        currentGrades.Remove(lowestGrade);

        return base.ComputeStatistics();
    }
}

}