namespace Exam
{
    public class Observer : IObserver
    {
        private int AverageTotal { get; set; }

        public void Update(int myAverage)
        {
            AverageTotal = myAverage;
        }

        public int GetAverage()
        {
            return AverageTotal;
        }
    }
}
