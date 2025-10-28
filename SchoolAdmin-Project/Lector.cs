using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class Lector : Employee
    {
        private static List<Lector> _allLectors = new();
        private Dictionary<Course, byte> _lectorTasks;
        public Lector(string name, DateTime birthDate, Dictionary<Course,byte> courses) : base(name, birthDate, new Dictionary<string,byte>())
        {
            _allLectors.Add(this);
            _lectorTasks = courses;
        }


        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                $"Lector";

        }


        public void AddCourseToLector(Course course, byte hours)
        {
            if (this._lectorTasks.ContainsKey(course))
            {
                this._lectorTasks[course] = hours;
            }
            else
            {
                this._lectorTasks.Add(course, hours);
            }
        }

        public ImmutableDictionary<Course,byte> LectorTasks
        {
            get { return this._lectorTasks.ToImmutableDictionary(); }
        }

        public static ImmutableList<Lector> AllLectors
        {
            get { return _allLectors.ToImmutableList(); }
        }


        public override uint CalculateSalary()
        {
            uint salary = 2200;
            uint seniority = (uint)(Seniority / 4);

            uint extraSalary = seniority < 1 ? 0 : seniority * 120;

            salary += extraSalary;

            double workLoad = DetermineWorkload();

            return (uint)((salary / 40) * workLoad);
        }

        public override double DetermineWorkload()
        {
            double workload = 0.00;

            foreach (var item in _lectorTasks)
            {
                workload += item.Value;
            }

            return workload;
        }

        public override string GenerateNameCard()
        {
            string outPut = "";

            foreach (var item in _lectorTasks)
            {
                outPut += $"{item.Key.Title}\n";
                
            }

            return $"{Name} (LECTOR)\n" +
                $"Lector voor:\n" +
                $"{outPut}";
        }
    }
}
