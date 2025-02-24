namespace SimpleDelegateExample
{
    internal class Program
    {
        public delegate void WriteTextDel(string text);
        static void Main(string[] args)
        {
            WriteTextDel writeTextToFile = new WriteTextDel(Log.PrintTextToFile);

            WriteTextDel writeTextToScreen = new WriteTextDel(Log.PrintTextToScreen);

           

            WriteTextDel writeTextToFileandScreen = writeTextToFile + writeTextToScreen;
            Console.WriteLine("Please Enter your name");
            writeTextToFileandScreen(Console.ReadLine());

        }

       
    }
    public static class Log
    {
        public static void PrintTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now} : { text}");
        }

        public static void PrintTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now} : {text}");
            }
        }


    }

}
