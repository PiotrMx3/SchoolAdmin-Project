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

        private Dictionary<DateTime,string> _studenFile = new Dictionary<DateTime, string>();

        public ImmutableList<Course> Courses
        {
            get
            {
                var allCoursesByStudent = ImmutableList.CreateBuilder<Course>();

                foreach (var item in CourseRegistrations)
                {
                    allCoursesByStudent.Add(item.Course);
                }

                return allCoursesByStudent.ToImmutableList();
            }

        }

        public Student(string name, DateTime birthDate) : base(name, birthDate)
        {
    
        }

        public ImmutableList<CourseRegistration> CourseRegistrations
        {
            get
            {
                var allCourseRegistrationsByStudent = ImmutableList.CreateBuilder<CourseRegistration>();

                foreach (var item in CourseRegistration.AllCourseRegistrations)
                {
                    if (this.Equals(item.Student)) allCourseRegistrationsByStudent.Add(item);
                }

                return allCourseRegistrationsByStudent.ToImmutableList();
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                $"Student";
        }

        public ImmutableDictionary<DateTime,string> StudentFile
        {
            get { return _studenFile.ToImmutableDictionary<DateTime,string>(); }

        }


        public void AddStudentFileEntry(string note)
        {
            _studenFile.Add(DateTime.Now, note);
        }



        public static ImmutableList<Student> AllStudents
        {
            get
            {
                var allStudentsBuilder = ImmutableList.CreateBuilder<Student>();

                foreach (Person student in Person.AllPersons)
                {
                    if(student is Student s)
                    {
                        allStudentsBuilder.Add(s);
                    }
                }

                return allStudentsBuilder.ToImmutableList();
            }
        }


        public ImmutableList<CourseRegistration> CoursesResults
        {
            get
            {
                return CourseRegistrations; 
            }
        }


        public void ShowOverview()
        {
            Console.WriteLine();
            Console.WriteLine($"{Name} ({Age})");
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

            CourseRegistration newCourseResult = new(course, result, this);

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
