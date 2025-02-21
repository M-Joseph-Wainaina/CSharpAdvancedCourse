
namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int a = 1;
            int b = 1;

            Console.WriteLine(a == b);

            string c = "name";
            string d = "name";

            var e = c.ToCharArray()[1] = 'b';
            Console.WriteLine(new string(e));
            
             

        }
    }
}
