using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.PatronIterator
{
    public class Iterator : IIterador
    {
        private Collection _collection;
        private int _current = 0;
        private int _step = 1;

        public Iterator(Collection collection)
        {
            this._collection = collection;
        }

        public IOperation First()
        {
            _current = 0;
            return _collection[_current] as IOperation;
        }

        public IOperation Next()
        {
            _current += _step;
            if (!IsDone)
                return _collection[_current] as IOperation;

            return null;
        }

        public bool IsDone
        {
            get { return _current >= _collection.Count; }
        }

        public IOperation CurrentItem
        {
            get { return _collection[_current] as IOperation; }
        }



    }
}
