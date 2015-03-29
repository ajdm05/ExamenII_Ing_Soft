using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = new CreatorSum();
            var res = new CreatorSubtract();
            var mult = new CreatorMultiply();

            Console.WriteLine("Suma: {0}", sum.FactoryMethod().Execute(1, 3));
            Console.WriteLine("Resta: {0}", res.FactoryMethod().Execute(5, 6));
            Console.WriteLine("Multiplicacion: {0}", mult.FactoryMethod().Execute(4, 3));

            Console.ReadKey();
        }
    }
}
