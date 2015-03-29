using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.PatronIterator
{
    public interface IIterador
    {
        IOperation First();
        IOperation Next();
        bool IsDone { get; }
        IOperation CurrentItem { get; }
    }
}
