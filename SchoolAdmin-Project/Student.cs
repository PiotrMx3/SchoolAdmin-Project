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
        public List<string> Courses = [];


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
