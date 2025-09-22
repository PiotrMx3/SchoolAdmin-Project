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
        private List<string> _courses = [];


        public List<string> Courses
        {
            get { return this._courses; }
            private set { this._courses = value; }
        }

        public void RegisterForCourse(string nameCourse)
        {
            if (!Courses.Contains(nameCourse)) Courses.Add(nameCourse); 

        }
        public string GenerateNameCard()
        {
            return this.Name + " (Student)";
        }

        public byte DetermineWorkload()
        {

            return (byte)(this.Courses.Count * 10);
        }

    }
}
