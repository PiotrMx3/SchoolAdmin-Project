using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class CourseRegistration
    {
        private Course _course;
        private byte? _result;
        private Student _student;

        private static List<CourseRegistration> _allCourseRegistrations = new();

        public CourseRegistration(Course course, byte? result, Student student)
        {
            Course = course;
            Result = result;
            Student = student;

            _allCourseRegistrations.Add(this);
        }
         
        public Student Student
        {
            get { return this._student; }
            private set { this._student = value; }
        }



        public static ImmutableList<CourseRegistration> AllCourseRegistrations
        {
            get { return _allCourseRegistrations.ToImmutableList(); }
        }


        public void AddCourseRegistration(CourseRegistration courseReg)
        {
            _allCourseRegistrations.Add(courseReg);
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
