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


            Student said = new("Said Aziz", new DateTime(2000, 06, 1));

            Student mieke = new("Mieke Vermeulen", new DateTime(1998, 1, 1));

            List<Student> listStudents = new() { said, mieke };

            Course communicatie = new("Communicatie",listStudents,6);
            Course programmeren = new("Programmeren",listStudents);

            Course webtechnologie = new("Webtechnologie");
            Course databanken = new("Databanken");

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
            Student said = new("Said Aziz", new DateTime(2000, 06, 1));

            said.RegisterCourseResult("Communicatie", 12);
            said.RegisterCourseResult("Programmeren", 15);
            said.RegisterCourseResult("Webtechnologie", 13);

            said.ShowOverview();

           
            Student mieke = new("Mieke Vermeulen", new DateTime(1998, 1, 1));


            mieke.RegisterCourseResult("Communicatie",13);
            mieke.RegisterCourseResult("Programmeren",16);
            mieke.RegisterCourseResult("Databanken", 14);


            mieke.ShowOverview();





        }
    }
}
