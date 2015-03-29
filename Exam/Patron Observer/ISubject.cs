using System.Collections.Generic;

namespace Exam
{
    public interface ISubject
    {
        int CalculateAverage(List<Results> resultsOfClasses);

        void NotifyChange(int average);
    }
}
