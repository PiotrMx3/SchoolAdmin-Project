namespace SchoolAdmin_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wat Wil jij doen ?");
            Console.WriteLine("1: DemonstreerStudenten uitvoren.");
            Console.WriteLine("2: DemonstreerCursussen uitvoren.");

            string k = Console.ReadLine() ?? "";

            switch (k)
            {
                case "1":
                    DemoStudents();
                    break;
                case "2":
                    DemoCourses();
                    break;
                default:
                    Console.WriteLine("Fout maak een nieuwe keuze !");
                    break;
            }

        }


        public static void DemoCourses()
        {
            Student said = new();
            said.Name = "Said Aziz";

            Student mieke = new();
            mieke.Name = "Mieke Vermeulen";

            Course communicatie = new();
            communicatie.Title = "Communicatie";

            Course programmeren = new();
            programmeren.Title = "Programmeren";

            Course webtechnologie = new();
            webtechnologie.Title = "Webtechnologie";

            Course databanken = new();
            databanken.Title = "Databanken";

            communicatie.Students.Add(said);
            communicatie.Students.Add(mieke);


            programmeren.Students.Add(said);
            programmeren.Students.Add(mieke);

            webtechnologie.Students.Add(said);

            databanken.Students.Add(mieke);

            communicatie.ShowOverview();
            Console.WriteLine();
            programmeren.ShowOverview();
            Console.WriteLine();
            webtechnologie.ShowOverview();
            Console.WriteLine();
            databanken.ShowOverview();
            Console.WriteLine();




        }

        public static void DemoStudents()
        {
            Student said = new();
            said.Name = "Said Aziz";
            said.Birthdate = new DateTime(2000, 06, 1);
            said.StudentNmber = Student.StudentCounter;

            Student.StudentCounter++;

            said.RegisterForCourse("Programmeren");
            said.RegisterForCourse("Databanken");


            Console.WriteLine(said.GenerateNameCard());
            Console.WriteLine(said.DetermineWorkload());


            Student mieke = new();
            mieke.Name = "Mieke Vermeulen";
            mieke.Birthdate = new DateTime(1998, 1, 1);
            mieke.StudentNmber = Student.StudentCounter;

            Student.StudentCounter++;

            mieke.RegisterForCourse("Communicatie");

            Console.WriteLine(mieke.GenerateNameCard());
            Console.WriteLine(mieke.DetermineWorkload());
            
            
        }
    }
}
