using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal abstract class Employee : Person
    {
        private static List<Employee> _allEmployees = new();
        private byte _seniority;

        private Dictionary<string, byte> _tasks = new();

        public ImmutableDictionary<string,byte> Tasks
        {
            get { return _tasks.ToImmutableDictionary(); }
  
        }

        protected Employee(string name, DateTime birthDate, Dictionary<string,byte> tasks) : base(name, birthDate)
        {
            _tasks = tasks;
           
        }

        public void AddOrUpdatetask(string task, byte hours)
        {   
            if(_tasks.ContainsKey(task))
            {
                _tasks[task] = hours;
            }
            else
            {
                _tasks.Add(task, hours);
            }
        }

        public byte Seniority
        {
            get  { return _seniority; }
            set 
            {
                if (value > 50)
                {
                    this._seniority = 50;
                }
                else
                {
                    this._seniority = value;

                }
            }

        }

        public abstract uint CalculateSalary();


        public static ImmutableList<Employee> AllEmployees
        {
            get { return _allEmployees.ToImmutableList(); }
        }

    }
}
