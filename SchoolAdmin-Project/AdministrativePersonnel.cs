using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin_Project
{
    internal class AdministrativePersonnel : Employee
    {
        private static List<AdministrativePersonnel> _allAdministrativeStaff = new();

        public static ImmutableList<AdministrativePersonnel> AdministrativeStaff
        {
            get { return _allAdministrativeStaff.ToImmutableList(); }
        }

        public AdministrativePersonnel(string name, DateTime birthDate, Dictionary<string, byte> tasks) : base(name, birthDate, tasks)
        {
            _allAdministrativeStaff.Add(this);
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                $"Administratief personeel";

        }

        public override uint CalculateSalary()
        {   
            uint salary = 2000;
            uint seniority = (uint)(Seniority / 3);

            uint extraSalary = seniority < 1 ? 0 : seniority * 75;

            salary += extraSalary;

            double workLoad = DetermineWorkload();

            return (uint)((salary / 40) * workLoad);

        }

        public override double DetermineWorkload()
        {
            double workLoad = 0.00;

            foreach (byte h in Tasks.Values)
            {
                workLoad = (byte)(workLoad + h);
            }

            return workLoad;

        }

        public override string GenerateNameCard()
        {
            return $"{this.Name} (ADMINISTRATIE)";
        }
    }
}
