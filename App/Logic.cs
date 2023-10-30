using Schoolregister.Register;

namespace Schoolregister.App
{
    public class Logic
    {
        public List<Person> Register { get; set; }
        public bool RunApp { get; private set; }
        public Logic()
        {
            Register = new();
            RunApp = true;
        }
        public void Quit()
        {
            Console.Clear();
            RunApp = false;
        }
        public (string MenuText, int MaxMenuItems) GetMenu()
        {
            if (Register.Count == 0)
            {
                return (ConsoleOut.AppMenuEmptyRegister, ConsoleOut.AppMenuEmptyRegisterMenuCount);
            }
            else
            {
                return (ConsoleOut.AppMenu, ConsoleOut.AppMenuMenuCount);
            }
        }
        public void StartLogicLoop()
        {

            while (RunApp)
            {
                var menuChoice = GetMenu();
                var userChoice = GetUserChoice(menuChoice.MenuText, menuChoice.MaxMenuItems);
                switch (userChoice)
                {
                    case 0:
                        Quit();
                        break;
                    case 1:
                        AddPersonToRegistry();
                        break;
                    case 2:
                        ShowAllPeopleInRegistry();
                        break;
                    case 3:
                        ShowTeachersInRegistry();
                        break;
                    case 4:
                        ShowStudentsInRegistry();
                        break;
                }
            }
        }
        private void ShowAllPeopleInRegistry()
        {
            Console.Clear();
            Console.WriteLine("Retrieving all the Registered people from the Edugrade School Registry...");
            foreach (var person in Register)
            {
                person.PrintInfo();
            }
            Console.WriteLine("\n");
        }
        private void ShowTeachersInRegistry()
        {
            Console.Clear();
            Console.WriteLine("Retrieving all the Teachers from the Edugrade School Registry...");
            var foundTeacher = false;

            foreach (var person in Register)
            {
                if (person is Teacher teacher)
                {
                    foundTeacher = true;
                    teacher.PrintInfo();
                }
            }
            if (!foundTeacher)
            {
                Console.WriteLine("There was no teachers in the Registry!");
            }
            Console.WriteLine("\n");
        }
        private void ShowStudentsInRegistry()
        {
            Console.Clear();
            Console.WriteLine("Retrieving all the Students from the Edugrade School Registry...");
            var foundStudent = false;
            foreach (var person in Register)
            {
                if (person is Student student)
                {
                    foundStudent = true;
                    student.PrintInfo();
                }
            }
            if (!foundStudent)
            {
                Console.WriteLine("There was no students in the Registry!");
            }
            Console.WriteLine("\n");
        }
        private void AddPersonToRegistry()
        {
            Console.Clear();
            Student student;
            Teacher teacher;
            var choice = GetUserChoice(ConsoleOut.AddPersonToTheList, ConsoleOut.AddPersonToTheListMenuCount);
            switch (choice)
            {
                case 0:
                    Quit();
                    break;
                case 1:
                    student = (Student)PersonSetup(Role.Student);
                    if (student is not null)
                    {
                        Register.Add(student);
                    }
                    break;
                case 2:
                    teacher = (Teacher)PersonSetup(Role.Teacher);
                    if (teacher is not null)
                    {
                        Register.Add(teacher);
                    }
                    break;
                case 3:
                    break;
            }
            Console.Clear();
        }

        private Person PersonSetup(Role personToAdd)
        {
            Console.Clear();
            string name, lastName, subject, classInfo;
            int personalNumber;
            switch (personToAdd)
            {
                case Role.Teacher:
                    name = GetStringFromUser("Teachers Name: ");
                    lastName = GetStringFromUser("Teachers Last Name: ");
                    personalNumber = GetIntegerFromUser("Teachers Personal Number: ");
                    subject = GetStringFromUser("Teachers Subject: ");
                    Console.Clear();
                    return new Teacher(name, lastName, personalNumber, subject);
                case Role.Student:
                    name = GetStringFromUser("Students Name: ");
                    lastName = GetStringFromUser("Students Last Name: ");
                    personalNumber = GetIntegerFromUser("Students Personal Number: ");
                    classInfo = GetStringFromUser("Students Class: ");
                    Console.Clear();
                    return new Student(name, lastName, personalNumber, classInfo);

                default:
                    return null;
            }
        }
        private string GetStringFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var userString = Console.ReadLine();
                if (!string.IsNullOrEmpty(userString))
                {
                    return userString;
                }

                Console.WriteLine("You cannot leave this text field empty.");
            }
        }
        private int GetIntegerFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int validChoice))
                {
                    if (validChoice > 0)
                    {
                        return validChoice;
                    }
                    else if (validChoice == 0)
                    {
                        Quit();
                    }

                    Console.WriteLine($"Please enter a positive integer.");
                }
            }
        }
        private int GetUserChoice(string prompt, int maxMenuChoice)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                Console.Write("\n\nMenu Choice: ");

                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int validChoice))
                {
                    if (validChoice >= 0 && validChoice <= maxMenuChoice)
                    {
                        Console.Clear();
                        return validChoice;
                    }
                    Console.Clear();
                    Console.WriteLine($"Please enter a number from the menu (0 - {maxMenuChoice}): ");
                }
                else if (userInput.ToUpper() == "EXIT")
                {
                    Quit();
                }
            }
        }


    }
}
