using System.Net.NetworkInformation;

namespace Delegates
{
    internal class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            var log = new Log();
            LogDel logDelToFile = new LogDel(log.LogTextToFile);
            LogDel logDelToScreen = new LogDel(log.LogTextToScreen);

            LogDel multiLogDel = logDelToFile + logDelToScreen;

            Console.WriteLine("Please Enter your name:");
            var text = Console.ReadLine();

            LogText(multiLogDel, text);
                                  
        }

        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }

     
    }
    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now} : {text}");
            }
        }
    }
}
