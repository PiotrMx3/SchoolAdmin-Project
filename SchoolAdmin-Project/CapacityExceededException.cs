using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class CapacityExceededException : Exception
    {
        public CapacityExceededException(string msg) : base(msg)
        {

        }
    }
}
