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

		private Dictionary<Course, byte> _courses = new();
		public StudyProgram(string name)
		{
			_name = name;
		}

        public void ShowOverview()
        {
			Console.WriteLine();
            Console.WriteLine($"Studie Programma voor {this._name}: ");
			Console.WriteLine();

			List<Course> semesterOne = new();
			List<Course> semesterTwo = new();

			foreach (var item in Courses)
			{
				if (item.Value == 1) 
				{
					semesterOne.Add(item.Key);
				}
				else
				{
					semesterTwo.Add(item.Key);
				}
			}

			Console.WriteLine("Semester 1:");
			Console.WriteLine();

			if(semesterOne.Count == 0)
			{
				Console.WriteLine("Er zijn geen cursussen in semester 1");
			} 
			else
			{
				foreach (var item in semesterOne)
				{
					Console.WriteLine($"{item.Title,-15} | Studiepunten {item.CreditPoints,-5} | ID {item.Id}");

				}
			}
			Console.WriteLine();

            Console.WriteLine("Semester 2:");
            Console.WriteLine();

            if (semesterTwo.Count == 0)
            {
                Console.WriteLine("Er zijn geen cursussen in semester 2");
            }
            else
            {
                foreach (var item in semesterTwo)
                {
                    Console.WriteLine($"{item.Title,-15} | Studiepunten {item.CreditPoints,-5} | ID {item.Id}");

                }
            }
            Console.WriteLine();

        }

		public void ChangeCourseTitle(Course course, string newTitle)
		{
			if (_courses.ContainsKey(course))
			{
				Course? other = null;

				foreach (var item in this._courses.Keys)
				{
					if(course.Equals(item))
					{
						other = item;
						break;
					}
				}

				if(other is not null)
				{
					byte value = this._courses[other];
					byte creditPoints = other.CreditPoints;

					Course newCourse = new(newTitle, creditPoints);

					this._courses.Remove(other);

					this._courses[newCourse] = value;
                }
            }
        }
		public void RemoveCourse(Course course)
		{
			if(_courses.ContainsKey(course))
			{
				this._courses.Remove(course);
			}
		}
		public void AddCourse(Course course, byte semester)
		{
			if(this._courses.ContainsKey(course))
			{
				this._courses[course] = semester;
			}
			else
			{
				this._courses.Add(course,semester);
			}
		}

		public ImmutableDictionary<Course,byte> Courses
		{
			get { return _courses.ToImmutableDictionary(); }
		}

		public string Name
		{
			get { return _name; }

		}

	}
}
