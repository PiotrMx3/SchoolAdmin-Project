namespace SchoolAdmin_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wat Wil jij doen ?");
            Console.WriteLine("1: DemonstreerStudenten uitvoren.");
            Console.WriteLine("2: DemonstreerCursussen uitvoren.");
            Console.WriteLine("3: CSV inlezen uitvoren.");

            string k = Console.ReadLine() ?? "";

            switch (k)
            {
                case "1":
                    DemoStudents();
                    break;
                case "2":
                    DemoCourses();
                    break;
                case "3":
                    ReadTextFormatStudent();
                    break;
                default:
                    Console.WriteLine("Fout maak een nieuwe keuze !");
                    break;
            }

        }


        public static void ReadTextFormatStudent()
        {
            Console.WriteLine("Geef de tekstvoorstelling van 1 student in CSV-formaat:");
            string newCsv = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(newCsv))
            {
                Console.WriteLine("Input mag niet leeg zijn");
                return;
            }


            if (!newCsv.Contains(';'))
            {
                Console.WriteLine("Formaat klopt niet moet met ;");
                return;
            }

            string[] dataStudent = newCsv.Split(';');

            //
            // Bart Van Steen;    0
            // 04;                1
            // 03;                2   
            // 1998;              3
            // Boekhouden;        4 0
            // 14;                5 1
            // Macro-economie;    6 2
            // 8;                 7 3
            // Frans, deel 2;     8 4
            // 18                 9 5

            string name = dataStudent[0];
            string birthDay = dataStudent[1];
            string birthMonth = dataStudent[2];
            string birthYear = dataStudent[3];

            DateTime birthDate = DateTime.Parse($"{birthDay}/{birthMonth}/{birthYear}");
            Student newStudent = new Student(name, birthDate);


            string[] dataCourses = dataStudent.Skip(4).ToArray();


            for (int i = 0; i < dataCourses.Length; i += 2)
            {
                string courseName = dataCourses[i];
                byte courseResult = Convert.ToByte(dataCourses[i + 1]);

                newStudent.RegisterCourseResult(courseName,courseResult);
            }

            newStudent.ShowOverview();



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
