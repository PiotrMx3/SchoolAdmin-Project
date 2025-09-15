namespace SchoolAdmin_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wat Wil jij doen ?");
            Console.WriteLine("1: DemonstreerStudenten uitvoren.");

            string k = Console.ReadLine() ?? "";

            switch (k)
            {
                case "1":
                    DemoStudents();
                    break;
                default:
                    Console.WriteLine("Fout maak een nieuwe keuze !");
                    break;
            }

        }

        public static void DemoStudents()
        {
            Student said = new();
            said.Name = "Said Aziz";
            said.Birthdate = new DateTime(2000, 06, 1);
            said.StudentNmber = Student.StudentCounter;

            Student.StudentCounter++;

            said.Courses = new List<string>() { "Programmeren", "Databanken" };

            Console.WriteLine(said.GenerateNameCard());
            Console.WriteLine(said.DetermineWorkload());


            Student mieke = new();
            mieke.Name = "Said Aziz";
            mieke.Birthdate = new DateTime(1998, 1, 1);
            mieke.StudentNmber = Student.StudentCounter;

            Student.StudentCounter++;

            mieke.Courses = new List<string>() { "Communicatie"};
            Console.WriteLine(mieke.GenerateNameCard());
            Console.WriteLine(mieke.DetermineWorkload());
            
            
        }
    }
}
