using System;
using System.Collections.Generic;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = new AdditionCreator();
            var res = new SubtractionCreator();
            var mult = new MultiplicationCreator();

            Console.WriteLine("Suma: {0}", sum.FactoryMethod().Execute(1, 3));
            Console.WriteLine("Resta: {0}", res.FactoryMethod().Execute(5, 6));
            Console.WriteLine("Multiplicacion: {0}", mult.FactoryMethod().Execute(4, 3));

            // Patron Observer
            var listResults = new List<Results>
            {
                new Results {NameClass = "Addition", ResultOfClass = sum.FactoryMethod().Execute(1, 3)},
                new Results {NameClass = "Subtraction", ResultOfClass = res.FactoryMethod().Execute(5, 6)},
                new Results {NameClass = "Multiplication", ResultOfClass = mult.FactoryMethod().Execute(4, 3)}
            };

            var observer = new Observer();
            var subject = new Subject(observer);

            var average = subject.CalculateAverage(listResults);

            Console.WriteLine("Subject: " + average);

            subject.NotifyChange(average);
            Console.WriteLine("Observer: " + observer.GetAverage());

            Console.ReadKey();
        }
    }
}
