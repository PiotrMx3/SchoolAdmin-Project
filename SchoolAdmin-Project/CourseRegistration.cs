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
            if (_allCourseRegistrations.Count() == 20) throw new CapacityExceededException($"Er zijn al teveel studenten ingeschrijven voor {Course.Title}");

            foreach (CourseRegistration r in _allCourseRegistrations)
            {
                if (r.Student == student && r.Course == course) throw new ArgumentException("Een student kan niet meermaals inschrijven voor dezelfde cursus.");
            }

            Result = result;

            _allCourseRegistrations.Add(this);
        }

        public Student Student
        {
            get { return this._student; }
            private set
            {
                if (value is null) throw new ArgumentException("Student/cursus mag niet ontbreken.");
                this._student = value;
            }

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
            private set
            {
                if (value is null) throw new ArgumentException("Student/cursus mag niet ontbreken.");
                this._course = value;
            }

        }


    }
}
