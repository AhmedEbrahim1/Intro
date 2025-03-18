namespace Intro.TEST_SOLID
{
    public class LogTEST //High Level Class 
    {
        //ConsoleLog _consoleLog = new ConsoleLog();
        SQLLog _SQLLog; //Low Level class 

        public LogTEST(SQLLog SQLLog)
        {
            _SQLLog = new SQLLog();
        }

        public void Print(string msg)
        {
            //invoke==> log Method
            _SQLLog.Log(msg);
        }


    }


    public class MainTest
    {
        public void TEST()
        {
            //SQLLog s = new SQLLog();
            //LogTEST logTEST = new LogTEST(null);//tightly coupled 
            //logTEST.Print("Hello Ahmed");

            ILog log = new SQLLog();//DI
            PrinciplesUsingDI obj = new PrinciplesUsingDI(log);
            obj.Print("Hello");


        }
    }

}
