using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class CoursesSortByCreditPoints : IComparer<Course>
    {
        public int Compare(Course? x, Course? y)
        {
            return x.CreditPoints.CompareTo(y.CreditPoints);
        }
    }
}
