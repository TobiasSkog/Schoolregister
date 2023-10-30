namespace Schoolregister.App
{
    public class App
    {

        public Logic Logic { get; set; }

        public App()
        {
            Logic = new();
        }
        public void Run()
        {
            Console.WriteLine(ConsoleOut.WelcomeMessage);
            Logic.StartLogicLoop();
            Console.WriteLine(ConsoleOut.GoodByeMessage);
        }

    }
}
