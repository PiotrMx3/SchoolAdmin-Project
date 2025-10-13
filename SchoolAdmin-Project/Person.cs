using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal abstract class Person
    {
		private uint _id;
		private string _name;
		private DateTime _birthDate;
		private static uint maxId = 1;
		public abstract string GenerateNameCard();
		public abstract double DetermineWorkload();

		private static List<Person> _allPersons = new();

		public Person(string name, DateTime birthDate)
		{
			this._name = name;
			this._birthDate = birthDate;
			this._id = maxId;

			_allPersons.Add(this);

			maxId++;
		}

		public static ImmutableList<Person> AllPersons
		{
			get { return _allPersons.ToImmutableList<Person>() ; }
		}


        public int Age
		{
			get 
			{
				DateTime now = DateTime.Now;

				int years = now.Year - Birthdate.Year;

				if (Birthdate.AddYears(years) > now.Date) years--;

				return years;
			}

		}


		public DateTime Birthdate
		{
			get { return this._birthDate; }
		}


		public string Name
		{
			get { return this._name; }
			set { this._name = value; }
		}

		public uint Id
		{
			get { return this._id; }
		}

	}
}
