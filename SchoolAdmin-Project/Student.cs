using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class Student
    {
        public static uint StudentCounter = 1;

        public string Name = "";
        public DateTime Birthdate = new DateTime(1900, 1, 1);
        public uint StudentNmber = 0;
        private List<CourseResult> _coursesResults = [];


        public List<CourseResult> CoursesResults
        {
            get { return this._coursesResults; }
            private set { this._coursesResults = value; }
        }

        public void RegisterCourseResult(string course, byte result)
        {

            if(result > 20)
            {
                Console.WriteLine("Warde moet tussen 0 en 20 liggen !");
                return;
            }

            CourseResult newCourseResult = new();
            newCourseResult.Name = course;
            newCourseResult.Result = result;

            CoursesResults.Add(newCourseResult);



        }
        public string GenerateNameCard()
        {
            return this.Name + " (Student)";
        }

        public byte DetermineWorkload()
        {

            return (byte)(this.CoursesResults.Count * 10);
        }

    }
}
