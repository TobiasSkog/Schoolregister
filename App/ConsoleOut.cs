namespace Schoolregister.App
{
    public static class ConsoleOut
    {
        public static readonly string WelcomeMessage =
            "Welcome to Edugrade School Registry Application!\n";
        public static readonly string GoodByeMessage =
            "Thank you for using Edugrade's School Registry Application!";

        public static readonly string AppMenuEmptyRegister =
            "~ Edugrade School Registry ~" +
            "\n0). Exit.\n" +
            "\n1). Add a new person to the school registry.";
        public static readonly int AppMenuEmptyRegisterMenuCount = 1;

        public static readonly string AppMenu = AppMenuEmptyRegister +
            "\n2). Show all the people in the registry." +
            "\n3). Show all the teachers in the registry." +
            "\n4). Show all the students in the registry.";
        public static readonly int AppMenuMenuCount = 4;

        public static readonly string AddPersonToTheList =
            "0). Exit.\n" +
            "\n1). Add a: Student." +
            "\n2). Add a: Teacher." +
            "\n3). Go Back.";
        public static readonly int AddPersonToTheListMenuCount = 3;


    }
}
