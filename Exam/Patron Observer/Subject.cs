using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    public class Subject : ISubject
    {
        private readonly IObserver _objectObserver;

        public Subject(IObserver objectObserver)
        {
            _objectObserver = objectObserver;
        }

        public int CalculateAverage(List<Results> resultsOfClasses)
        {
            var sum = resultsOfClasses.Sum(item => item.ResultOfClass);
            var average = sum / resultsOfClasses.Count;

            return average;
        }

        public void NotifyChange(int average)
        {
            _objectObserver.Update(average);
        }
    }
}
