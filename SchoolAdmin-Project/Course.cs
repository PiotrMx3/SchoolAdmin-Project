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
