using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class CourseResult
    {
        private string _name;
        private byte _result;


        public CourseResult(string name, byte result)
        {
            this._name = name;
            Result = result;
        }
        public byte Result
        {
            get { return this._result; }
            set
            {
                if (value > 20)
                {
                    Console.WriteLine("Warde moet tussen 0 en 20 liggen !");
                    return;
                }

                this._result = value;
            }
        }

        public string Name
        {
            get { return this._name; }

        }


    }
}
