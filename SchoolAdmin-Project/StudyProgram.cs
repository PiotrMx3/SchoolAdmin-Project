using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class StudyProgram
    {
		private string _name;

		private List<Course> _courses = new List<Course>();

        public void ShowOverview()
        {
            Console.WriteLine($"Studie Programam voor {this._name}: ");

			foreach (var item in Courses )
			{
				Console.WriteLine($"{item.Title} | Studiepunten {item.CreditPoints} | ID {item.Id}");

			}
			Console.WriteLine();
        }

		public void AddCourse(Course course)
		{
            _courses.Add(course);
        }

        public void AddCourse(List<Course> listCourse)
        {
            _courses.AddRange(listCourse);
        }
        public StudyProgram(string name)
		{
			_name = name;
		}

		public ImmutableList<Course> Courses
		{
			get { return _courses.ToImmutableList<Course>(); }
		}

		public string Name
		{
			get { return _name; }

		}

	}
}
