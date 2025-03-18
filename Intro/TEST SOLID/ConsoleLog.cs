namespace Intro.TEST_SOLID
{
    public class ConsoleLog : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine($"this msg {message} from ConsoleLog  ");
        }

    }
}
