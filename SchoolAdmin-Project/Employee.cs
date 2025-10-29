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
        private byte _seniority;

        private Dictionary<string, byte> _tasks = new();

        protected Employee(string name, DateTime birthDate, Dictionary<string,byte> tasks) : base(name, birthDate)
        {
            this._tasks = tasks;
           
        }
        public ImmutableDictionary<string,byte> Tasks
        {
            get { return _tasks.ToImmutableDictionary(); }
  
        }

        
        public void AddOrUpdatetask(string task, byte hours)
        {   
            if(this._tasks.ContainsKey(task))
            {
                this._tasks[task] = hours;
            }
            else
            {
                this._tasks.Add(task, hours);
            }
        }

        public byte Seniority
        {
            get  { return this._seniority; }
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
            get
            {
                var allEmployees = ImmutableList.CreateBuilder<Employee>();

                foreach (Person employee in Person.AllPersons)
                {
                    if (employee is Employee e) allEmployees.Add(e);
                }

                return allEmployees.ToImmutableList(); ;
            }
        }

    }
}
