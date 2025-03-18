namespace Intro.TEST_SOLID
{

    public interface ILog
    {
        void Log(string message);
    }

    public class PrinciplesUsingDI //TopLVl
    {
        ILog _log;//null
        public PrinciplesUsingDI(ILog log)//Console,SQL,File ==> Interface ==> ILog
        {
            _log = log;
        }

        public void Print(string msg)
        {
            _log.Log(msg);
        }

    }
}
