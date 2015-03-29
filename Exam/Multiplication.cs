using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Multiplication : IOperation
    {
        public int Execute(int multiplicand, int multiplier)
        {
            return multiplicand * multiplier;
        }
    }
}
