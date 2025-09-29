using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class StudyProgram
    {
		private string _name;

		private List<Course> _courses = new();

        public void ShowOverview()
        {
            Console.WriteLine($"Studie Programam voor {this._name}: ");

			foreach (var item in Courses )
			{
				Console.WriteLine($"{item.Title} | Studiepunten {item.CreditPoints} | ID {item.Id}");

			}
			Console.WriteLine();
        }

        public StudyProgram(string name)
		{
			_name = name;
		}

		public List<Course> Courses
		{
			get { return _courses; }
			private set { _courses = value; }
		}

		public string Name
		{
			get { return _name; }

		}

	}
}
