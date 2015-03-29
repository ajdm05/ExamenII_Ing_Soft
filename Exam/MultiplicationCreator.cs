using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class MultiplicationCreator : ICreator
    {
        public IOperation FactoryMethod()
        {
            return new Multiplication();
        }
    }
}
