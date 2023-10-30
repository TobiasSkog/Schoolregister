namespace Schoolregister.Register
{
    public enum Role
    {
        Teacher,
        TempTeacher,
        Student,
        Parent,
    }
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public int PersonalNumber { get; set; }

        public Person(string firstName, string lastName, int personalNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"{PersonalNumber}: {FirstName}, {LastName}");
        }
    }
}
