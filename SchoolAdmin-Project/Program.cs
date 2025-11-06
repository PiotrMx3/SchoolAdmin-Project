using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SchoolAdmin_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool isRunning = true;
            Student s1 = new("Anna Kowalska", new DateTime(2001, 3, 14));
            Student s2 = new("Jan Nowak", new DateTime(2000, 11, 2));
            Student s3 = new("Ewa Zielińska", new DateTime(2002, 6, 25));
            Student s4 = new("Piotr Wiśniewski", new DateTime(1999, 9, 8));
            Student s5 = new("Kamil Lewandowski", new DateTime(2003, 1, 17));

            Course c1 = new("Programmeren in C#", 5);
            Course c2 = new("Databanken", 4);
            Course c3 = new("Webontwikkeling", 6);
            Course c4 = new("Cloudsystemen", 3);
            Course c5 = new("IT Essentials", 2);

            while (isRunning)
            {

                Console.WriteLine("Wat Wil jij doen ?");
                Console.WriteLine("0: Stopen");
                Console.WriteLine("1: Demonstreer Studenten uitvoren");
                Console.WriteLine("2: Demonstreer Cursussen uitvoren");
                Console.WriteLine("3: Student uit tekstformaat inlezen");
                Console.WriteLine("4: Demonstreer StudyProgram uitvoeren");
                Console.WriteLine("5: Demonstreer AdministrativePersonnel uitvoeren");
                Console.WriteLine("6: Demonstreer Lectoren uitvoeren");
                Console.WriteLine("7: Student toevoegen");
                Console.WriteLine("8: Cursus toevoegen");
                Console.WriteLine("9: Vakinschrijving toevoegen");
                Console.WriteLine("10: Inschrijvingegevens tonen");

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
                        DemoAdministrativePersonnel();
                        break;
                    case "6":
                        DemoLectures();
                        break;
                    case "7":
                        AddStudent();
                        break;
                    case "8":
                        AddCourse();
                        break;
                    case "9":
                        AddCourseRegistration();
                        break;
                    case "10":
                        ShowCourseRegistrations();
                        break;
                    case "0":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Fout maak een nieuwe keuze !");
                        break;
                }

            }

        }

        public static void ShowCourseRegistrations()
        {
            Console.WriteLine("Alle Studenten");
            Console.WriteLine();

            for (int i = 0; i < Student.AllStudents.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Student.AllStudents[i].Name} ");
            }

            Console.WriteLine();

            Console.WriteLine("Alle curssusen");
            Console.WriteLine();

            for (int i = 0; i < Course.AllCourses.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Course.AllCourses[i].Title} ");
            }

            Console.WriteLine();


            Console.WriteLine("Alle Inschrijvingen");
            Console.WriteLine();

            foreach (var item in CourseRegistration.AllCourseRegistrations)
            {
                Console.WriteLine($"{item.Student.Name} ingeschreven voor {item.Course.Title}");
            }

            Console.WriteLine();



        }

        public static void AddCourseRegistration()
        {

            if (Student.AllStudents.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Vaak inschrijving niet mogelijk!\nEr zijn geen studenten");
                Console.WriteLine();
                return;
            }
            else if (Course.AllCourses.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Vaak inschrijving niet mogelijk!\nEr zijn geen cursussen");
                Console.WriteLine();
                return;
            }


            Console.WriteLine("Welke Student ?");

            Console.WriteLine();

            for (int i = 0; i < Student.AllStudents.Count; i++)
            {
                Console.WriteLine($"{i+1}: {Student.AllStudents[i].Name} ");
            }

            Console.WriteLine();

            int userChoiceStudent = Convert.ToInt16(Console.ReadLine());


            Console.WriteLine("Welke Cursus ?");

            Console.WriteLine();

            for (int i = 0; i < Course.AllCourses.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Course.AllCourses[i].Title} ");
            }

            Console.WriteLine();

            int userChoiceCourse = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Wil jij een resultat toekennen  (ja/nee)?");

            string addResultUser = Console.ReadLine() ?? "";


            if(string.IsNullOrWhiteSpace(addResultUser))
            {
                Console.WriteLine();
                Console.WriteLine("Antwoordt mag niet leeg zijn");
                Console.WriteLine();
                return;
            }

            if(addResultUser.ToLower() == "ja" )
            {
                Console.WriteLine();
                Console.WriteLine("Wat is het resultaat ?");
                byte resultatFromUser = Convert.ToByte(Console.ReadLine());
                Console.WriteLine();

                CourseRegistration cr = new CourseRegistration(Course.AllCourses[userChoiceCourse - 1], resultatFromUser, Student.AllStudents[userChoiceStudent - 1]);

            }
            else if(addResultUser.ToLower() == "nee") 
            {
                CourseRegistration cr = new CourseRegistration(Course.AllCourses[userChoiceCourse - 1], null, Student.AllStudents[userChoiceStudent - 1]);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Veerkerde keuze probeer op het nieuw !");
                Console.WriteLine();
            }





        }

        public static void AddCourse()
        {
            Console.WriteLine("Titel van de cursus ?");
            string courseUser = Console.ReadLine() ?? "";
            Console.WriteLine("Aantal studiepunten ?");
            string studyPoint = Console.ReadLine() ?? "";
            byte parsed = 0;

            if(byte.TryParse(studyPoint, out parsed))
            {
                Course c = new Course(courseUser, parsed);
                Console.WriteLine();
                Console.WriteLine($"Cursus: {c.Title}\nStudiepunten: {c.CreditPoints}\nSuccesvol aangemaakt\n");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Studiepunten moet een getal zijn !");
                Console.WriteLine();
            }

        }


        public static void AddStudent()
        {
            bool isInvalid;
            string studentName = "";
            DateTime birthDate = DateTime.MinValue;
            CultureInfo dutch = new CultureInfo("nl-BE");

            do
            {
                isInvalid = false;

                Console.WriteLine("Naam van de student?");
                studentName = Console.ReadLine() ?? "";

                Console.WriteLine("Geboortdatum van de student ? (dd/MM/jjjj)");
                string birthDateToParse = Console.ReadLine() ?? "";

                if(string.IsNullOrWhiteSpace(studentName) | string.IsNullOrWhiteSpace(birthDateToParse))
                {
                    Console.WriteLine("Naam of Geboortdatum mag niet leeg zijn !");
                    Console.WriteLine("Probeer op het nieuw !");
                    Console.WriteLine();

                    isInvalid = true;
                }
                else
                {

                    if (DateTime.TryParse(birthDateToParse, out DateTime result))
                    {
                        birthDate = result;
                    }
                    else
                    {
                        Console.WriteLine("Formaat moet dd/MM/jjjj zijn !");
                        Console.WriteLine();
                        isInvalid = true;
                    }

                }

            } while (isInvalid);


            Student newStudent = new Student(studentName, birthDate);

            Console.WriteLine();
            Console.WriteLine($"Student: {newStudent.Name}\n" +
                $"Gebooren op: {newStudent.Birthdate.ToString("d",dutch)} is aangemaakt");

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

        public static void DemoStudyProgram()
        {

            // TODO: Aanpasen wijzigingen


            Course communicatie = new Course("Communicatie");
            Course programmeren = new Course("Programmeren");
            Course databanken = new Course("Databanken");


            StudyProgram programmerenProgram = new StudyProgram("Programmeren");
            StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer");

            programmerenProgram.AddCourse(new Course(communicatie), 1);
            programmerenProgram.AddCourse(new Course(programmeren), 1);
            programmerenProgram.AddCourse(new Course(databanken), 1);


            snbProgram.AddCourse(new Course(communicatie), 1);
            snbProgram.AddCourse(new Course(programmeren), 1);
            snbProgram.AddCourse(new Course(databanken), 1);

            //we willen hieronder Databanken schrappen uit het programma SNB
            snbProgram.RemoveCourse(databanken);

            //voor SNB wordt de titel van de cursus Programmeren veranderd naar "Scripting"
            snbProgram.ChangeCourseTitle(programmeren, "Scripting");
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

            Course communicatie = new("Communicatie",6);
            Course programmeren = new("Programmeren");

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
