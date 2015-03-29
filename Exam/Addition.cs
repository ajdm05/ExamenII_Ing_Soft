using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam;

namespace Exam
{
    public class Addition : IOperation
    {
        public int Execute(int firstAddend, int secondAddend)
        {
            return firstAddend + secondAddend;
        }
    }
}
