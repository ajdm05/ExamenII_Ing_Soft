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

        public void Opertation()
        {
            throw new NotImplementedException();
        }


        public string Result
        {
            get { return _result; }
        }
    }
}
