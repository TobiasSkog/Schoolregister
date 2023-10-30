namespace Schoolregister.Register
{
    public class Student : Person
    {
        public string Class { get; set; }
        public Student(string firstName, string lastName, int personalNumber, string studentClass) : base(firstName, lastName, personalNumber)
        {
            Role = Role.Student;
            Class = studentClass;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Student\t{PersonalNumber}: {FirstName}, {LastName} of {Class}.");
        }
    }


}

