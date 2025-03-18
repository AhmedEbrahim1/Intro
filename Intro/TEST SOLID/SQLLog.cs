namespace Intro.TEST_SOLID
{
    public class SQLLog :ILog
    {
        public void Log(string message)
        {
            Console.WriteLine($"this msg {message} from SQLLog  ");
        }

    }
}
