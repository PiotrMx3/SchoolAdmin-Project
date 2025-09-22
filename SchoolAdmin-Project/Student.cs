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

        public void ShowOverview()
        {
            Console.WriteLine(this.Name);
            Console.WriteLine($"Werkbelasting: {DetermineWorkload()}");
            Console.WriteLine();
            Console.WriteLine("Cijferrapport");
            Console.WriteLine($"************");

            foreach (var item in CoursesResults)
            {
                Console.WriteLine($"{item.Name + ":", -20}{item.Result:F2}");
            }
            Console.WriteLine($"{"Gemiddelde:", -20}{Average():F2}");
            Console.WriteLine();
        }

        public double Average()
        {
            double result = 0.00;

            foreach (var item in CoursesResults)
            {
                result += item.Result;
            }

            return result / CoursesResults.Count ;
        }

        public void RegisterCourseResult(string course, byte result)
        {

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
