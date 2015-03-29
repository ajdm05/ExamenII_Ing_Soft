using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Multiply : IOperation
    {
        public int Execute(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}
