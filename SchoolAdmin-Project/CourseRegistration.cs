using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class CourseRegistration
    {
        private Course _course;
        private byte? _result;


        public CourseRegistration(Course course, byte? result)
        {
            this._course = course ;
            Result = result;

        }
        public byte? Result
        {
            get { return this._result; }
            set
            {
                if (!(value is null) && !(value > 20))
                {
                    this._result = value;
                }

            }
        }

        public Course Course
        {
            get { return this._course; }
            set { this._course = value; }

        }


    }
}
