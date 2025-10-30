using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class Course
    {
        public string Title;
        private int _id;
        private byte _creditPoints;
        public static int maxId = 1;
        private static List<Course> _allCourses = new();

        public Course(string title, byte creditPoints)
        {
            this.Title = title;
            CreditPoints = creditPoints;
            this._id = maxId;
            _allCourses.Add(this);

            maxId++;

        }
        public Course(string title) : this(title, 3)
        {

        }


        public ImmutableList<Student> Students
        {
            get
            {
                var allStudents = ImmutableList.CreateBuilder<Student>();

                foreach (var item in CourseRegistrations)
                {
                    allStudents.Add(item.Student);
                }

                return allStudents.ToImmutableList();
            }
        }
        public ImmutableList<CourseRegistration> CourseRegistrations
        {
            get
            {
                var allCourses = ImmutableList.CreateBuilder<CourseRegistration>();

                foreach (var item in CourseRegistration.AllCourseRegistrations)
                {
                    if (this.Equals(item.Course)) allCourses.Add(item);
                }

                return allCourses.ToImmutableList();
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Course other) return false;

            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }



        public static ImmutableList<Course> AllCourses
        {
            get { return _allCourses.ToImmutableList<Course>(); }
        }


        public static Course? SearchCourseById(int id)
        {

            return AllCourses.Find(el => el.Id == id);
        }

        public int Id
        {
            get { return this._id; }

        }

        public byte CreditPoints
        {
            get { return this._creditPoints; }
            private set { this._creditPoints = value; }
        }


        public void ShowOverview()
        {
            Console.WriteLine($"{this.Title} ({Id}) ({CreditPoints}stp)");

            foreach (var item in Students)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

    }
}
