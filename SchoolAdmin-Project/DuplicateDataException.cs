using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class DuplicateDataException : Exception
    {
		private Object _object1;
        private Object _object2;


        public DuplicateDataException(string msg, Object obj1, Object obj2) : base(msg)
        {
            this._object1 = obj1;
            this._object2 = obj2;
        }

        public Object Object2
        {
            get { return this._object2; }
        }
        public Object Object1
		{
			get { return this._object1; }
		}

	}
}
