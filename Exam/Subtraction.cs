using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Subtraction :IOperation
    {
        public int Execute(int minuend, int subtrahend)
        {
            return minuend - subtrahend;
        }
    }
}
