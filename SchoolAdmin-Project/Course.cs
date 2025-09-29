using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class Course
    {
        public List<Student> Students = new();
        public string Title;
        private int _id;
        private byte _creditPoints;
        public static int maxId = 1;
        public static List<Course> AllCourses = new();


        public Course(string title) : this(title, new List<Student>(), 3)
        {

        }
        public Course(string title, List<Student> students) :this(title, students, 3)
        {

        }

        public Course(string title, List<Student> students, byte creditPoints)
        {
            this.Title = title;
            this.Students.AddRange(students);
            CreditPoints = creditPoints;
            this._id = maxId;

            AllCourses.Add(this);

            maxId++;

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
