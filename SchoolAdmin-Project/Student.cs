using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class Student : Person
    {

        public uint StudentNumber = 0;
        private List<CourseRegistration> _courseRegistration = [];
        private static List<Student> _allStudents = new List<Student>();
        private Dictionary<DateTime,string> _studenFile = new Dictionary<DateTime, string>();

        public ImmutableDictionary<DateTime,string> StudentFile
        {
            get { return _studenFile.ToImmutableDictionary<DateTime,string>(); }

        }


        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                $"Student";

        }


        public void AddStudentFileEntry(string note)
        {
            _studenFile.Add(DateTime.Now, note);
        }


        public Student(string name, DateTime birthDate) : base(name, birthDate)
        {
            _allStudents.Add(this);
        }

        public static ImmutableList<Student> AllStudents
        {
            get { return _allStudents.ToImmutableList<Student>(); }
        }


        public List<CourseRegistration> CoursesResults
        {
            get { return this._courseRegistration; }
            private set { this._courseRegistration = value; }
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

        public override string GenerateNameCard()
        {
            return this.Name + " (Student)";
        }

        public override double DetermineWorkload()
        {
            return this.CoursesResults.Count * 10;
        }
    }
}
