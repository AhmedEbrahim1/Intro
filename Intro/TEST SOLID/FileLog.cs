namespace Intro.TEST_SOLID
{
    public class FileLog : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine($"this msg {message} from FileLog  ");
        }

    }
}
