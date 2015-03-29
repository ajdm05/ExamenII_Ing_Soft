using System;
using System.Collections.Generic;
using Exam.PatronIterator;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = new AdditionCreator();
            var res = new SubtractionCreator();
            var mult = new MultiplicationCreator();

            Console.WriteLine("Factory Method:");
            Console.WriteLine("Suma: {0}", sum.FactoryMethod().Execute(1, 3));
            Console.WriteLine("Resta: {0}", res.FactoryMethod().Execute(5, 6));
            Console.WriteLine("Multiplicacion: {0}", mult.FactoryMethod().Execute(4, 3));
            Console.WriteLine();


            // Patron Iterator
            Console.WriteLine("Patron Iterator:");
            var collection = new Collection();
            collection[0] = sum.FactoryMethod();
            collection[1] = res.FactoryMethod();
            collection[2] = mult.FactoryMethod();

            var iter = collection.CreateIterator();

            var temp = iter.First();
            while (temp != null)
            {
                Console.Write(temp.GetType() + ": ");
                Console.WriteLine(temp.Execute(2, 1));
                temp = iter.Next();
            }
            Console.WriteLine();


            // Patron Observer
            Console.WriteLine("Patron Observer:");
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
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
