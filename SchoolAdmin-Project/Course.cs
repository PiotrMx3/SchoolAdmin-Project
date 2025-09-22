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
            Console.WriteLine($"{this.Title}");

            foreach (var item in Students)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

    }
}
