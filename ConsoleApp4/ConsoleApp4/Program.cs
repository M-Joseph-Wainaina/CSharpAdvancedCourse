namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int overtimeHours, time;
            while (true)
            {
                Console.WriteLine("Enter the time you left");

                time = Convert.ToInt32(Console.ReadLine());
                                
                if (IsOvertime(time, out overtimeHours))
                {
                    Console.WriteLine($"You have been awarded {overtimeHours} hours");
                }
                else
                {
                    Console.WriteLine("you have not been awarded overtime hours");
                }
                Console.WriteLine($"{time}, {overtimeHours}");
            }

        }

        public static  bool IsOvertime(int time, out int overtimeHours)
        {
            if (time > 17)
            {
                overtimeHours = time - 17;
                return true;
            }
            else
            {
                overtimeHours = 0;
                return false;
            }
        }
    }
}
