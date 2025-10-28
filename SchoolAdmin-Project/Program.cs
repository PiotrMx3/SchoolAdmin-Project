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
            Console.WriteLine("4: DemoStudyProgram uitvoeren.");
            Console.WriteLine("5: DemoStudyProgramTwo uitvoeren.");
            Console.WriteLine("6: DemoAdministrativePersonnel uitvoeren.");
            Console.WriteLine("7: DemoLectures uitvoeren.");



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
                case "4":
                    DemoStudyProgram();
                    break;
                case "5":
                    DemoStudyTwo();
                    break;
                case "6":
                    DemoAdministrativePersonnel();
                    break;
                case "7":
                    DemoLectures();
                    break;
                default:
                    Console.WriteLine("Fout maak een nieuwe keuze !");
                    break;
            }

        }


        public static void DemoLectures()
        {
            Course course1 = new Course("Economie");
            Course course2 = new Course("Statistiek");
            Course course3 = new Course("Analytische meetkunde");

            Lector anna = new Lector("Anna", new DateTime(1990,02,01), new Dictionary<Course, byte> { { course1, 3 }, {course2, 3 }, {course3, 4 } });
            anna.Seniority = 9;

            foreach (var item in Lector.AllLectors)
            {
                Console.WriteLine($"{item.GenerateNameCard()}");
                Console.WriteLine($"Solaris: {item.CalculateSalary()} euro");
                Console.WriteLine($"Werkbelasting: {item.DetermineWorkload()} h");

            }
        }

        public static void DemoAdministrativePersonnel()
        {
            AdministrativePersonnel ahmed = new AdministrativePersonnel("Ahmed Azzaoui", new DateTime(1988,02,04), new Dictionary<string, byte> { {"Roostering", 10 }, {"Correspondentie", 10 }, {"Animatie", 10 } });
            ahmed.Seniority = 7;

            foreach (var item in AdministrativePersonnel.AdministrativeStaff)
            {
                Console.WriteLine($"{item.GenerateNameCard()}");
                Console.WriteLine($"Solaris: {item.CalculateSalary()} euro");
                Console.WriteLine($"Werkbelasting: {item.DetermineWorkload()} h");

            }

        }

        public static void DemoStudyTwo()
        {

            // TODO: Aanpasen wijzigingen


            Course communicatie = new Course("Communicatie");
            Course programmeren = new Course("Programmeren");
            Course databanken = new Course("Databanken");

            List<Course> coursesProgrammeren = new List<Course>() { communicatie, programmeren, databanken };
            List<Course> coursesSNB = new List<Course>() { communicatie, programmeren, databanken };

            StudyProgram programmerenProgram = new StudyProgram("Programmeren");
            StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer");

            programmerenProgram.AddCourse(coursesProgrammeren);
            snbProgram.AddCourse(coursesSNB);

            //we willen hieronder Databanken schrappen uit het programma SNB
            snbProgram.Courses.Remove(databanken);

            //voor SNB wordt de titel van de cursus Programmeren veranderd naar "Scripting"
            snbProgram.Courses[1].Title = "Scripting";
            programmerenProgram.ShowOverview();
            snbProgram.ShowOverview();
        }


        public static void DemoStudyProgram()
        {
            Course communicatie = new Course("Communicatie");
            Course programmeren = new Course("Programmeren");
            Course databanken = new Course("Databanken");

            List<Course> courses = new List<Course>() { communicatie, programmeren, databanken };

            StudyProgram programmerenProgram = new StudyProgram("Programmeren");
            StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer");

           
            programmerenProgram.AddCourse(courses);

            snbProgram.AddCourse(courses);


            snbProgram.Courses.Remove(databanken);
            snbProgram.Courses.Add(programmeren);

            programmerenProgram.ShowOverview();

            snbProgram.ShowOverview();
        }


        public static void ReadTextFormatStudent()
        {

            Course comunication = new Course("Communicatie");
            Course programing = new Course("Programmeren");
            Course webtechologies = new Course("Webtechnologie");
            Course databases = new Course("Databanken");

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
            // Boekhouden;        4
            // 14;                5
            // Macro-economie;    6
            // 8;                 7
            // Frans, deel 2;     8
            // 18                 9

            string name = dataStudent[0];
            string birthDay = dataStudent[1];
            string birthMonth = dataStudent[2];
            string birthYear = dataStudent[3];

            DateTime birthDate = DateTime.Parse($"{birthDay}/{birthMonth}/{birthYear}");
            Student newStudent = new Student(name, birthDate);


            string[] dataCourses = dataStudent.Skip(4).ToArray();

            // Boekhouden;        0
            // 14;                1
            // Macro-economie;    2
            // 8;                 3
            // Frans, deel 2;     4
            // 18                 5



            for (int i = 0; i < dataCourses.Length; i += 2)
            {
                Course? course = Course.SearchCourseById(Convert.ToInt32(dataCourses[i]));


                if (course is not null)
                {

                    byte courseResult = Convert.ToByte(dataCourses[i + 1]);

                    newStudent.RegisterCourseResult(course, courseResult);
                }

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


            said.RegisterCourseResult(communicatie, 12);
            said.RegisterCourseResult(programmeren, null);
            said.RegisterCourseResult(webtechnologie, 13);

            mieke.RegisterCourseResult(communicatie, 13);
            mieke.RegisterCourseResult(programmeren, 16);
            mieke.RegisterCourseResult(databanken, 14);




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

            Course comunication = new Course("Communicatie");
            Course programing = new Course("Programmeren");
            Course webtechologies = new Course("Webtechnologie");
            Course databases = new Course("Databanken");



            said.RegisterCourseResult(comunication, 12);
            said.RegisterCourseResult(programing, null);
            said.RegisterCourseResult(webtechologies, 13);

            said.ShowOverview();

           
            Student mieke = new("Mieke Vermeulen", new DateTime(1998, 1, 1));


            mieke.RegisterCourseResult(comunication,13);
            mieke.RegisterCourseResult(programing,16);
            mieke.RegisterCourseResult(databases, 14);


            mieke.ShowOverview();



        }
    }
}
