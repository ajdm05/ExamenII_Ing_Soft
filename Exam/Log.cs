using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Log : ILog
    {
        private string _result;

        public Log()
        {
            _result = "";
        }

        public void Opertation(IOperation ioperation, int value)
        {
            _result += string.Format("{0}: {1}{2}", ioperation.GetType().Name, value, Environment.NewLine);
        }


        public string Result
        {
            get { return _result; }
        }
    }
}
