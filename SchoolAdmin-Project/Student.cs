using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
        public uint StudentNumber = 0;
        private List<CourseRegistration> _courseRegistration = [];


        public Student(string name, DateTime birthDate)
        {
            Name = name;
            Birthdate = birthDate;

            StudentNumber = StudentCounter;
            StudentCounter++;

        }

        public List<CourseRegistration> CoursesResults
        {
            get { return this._courseRegistration; }
            private set { this._courseRegistration = value; }
        }


        public int Age
        {
            get 
            {

                DateTime now = DateTime.Now;
                int age = now.Year - Birthdate.Year;

                if (Birthdate.Date > now.AddYears(-age)) age--;

                return age;
            }
        }
        public void ShowOverview()
        {
            Console.WriteLine();
            Console.WriteLine($"{this.Name} ({Age})");
            Console.WriteLine($"Werkbelasting: {DetermineWorkload()}");
            Console.WriteLine();
            Console.WriteLine("Cijferrapport");
            Console.WriteLine($"************");

            foreach (var item in CoursesResults)
            {
                if(item.Result is null )
                {
                    Console.WriteLine($"{item.Course.Title + ":",-20}Geen Resultaat");
                }
                else
                {
                    Console.WriteLine($"{item.Course.Title + ":",-20}{item.Result:F2}");
                }
            }
            Console.WriteLine($"{"Gemiddelde:", -20}{Average():F2}");
            Console.WriteLine();
        }

        public double Average()
        {
            double result = 0.00;
            int counter = 0;

            foreach (var item in CoursesResults)
            {   
                if (item.Result is not null)
                {
                    result += (byte)item.Result;
                    counter++;
                }
                
            }

            return result / counter ;
        }

        public void RegisterCourseResult(Course course, byte? result)
        {

            CourseRegistration newCourseResult = new(course,result);

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
