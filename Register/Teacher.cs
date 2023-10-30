namespace Schoolregister.Register
{
    public class Teacher : Person
    {
        public string Subject { get; set; }
        public Teacher(string firstName, string lastName, int personalNumber, string subject) : base(firstName, lastName, personalNumber)
        {
            Role = Role.Teacher;
            Subject = subject;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Teacher\t{PersonalNumber}: {FirstName}, {LastName} teaches {Subject}.");
        }
    }
}
