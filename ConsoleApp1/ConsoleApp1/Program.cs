
using System.Diagnostics.CodeAnalysis;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            ////implicit type conversion
            //byte a  = 3;
            //int b = a;

            ////explicit type conversion

            //int c = 3;
            //byte d = (byte)c;

            ////using the Convert class library

            //string e = "3";
            //int f = Convert.ToInt32(e);
            //int g = int.Parse(e);

            //Console.WriteLine(b);
            //Console.WriteLine(d);
            //Console.WriteLine(g);

            ////handling exceptions 
            //try
            //{
            //    string number = "1234";
            //    byte a = Convert.ToByte(number);
            //    Console.WriteLine(a);
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine("Cannot convert the number to a byte");
            //}

            //arithematic operators(+, -, *, / , %)

            //int a = 1;
            //int b = 2;
            //int c = 3;


            //Console.WriteLine(c > a || c > b);

            //static modifier : to declar a static member which belongs to the class iteself rather than a specific object

            Car car1 = new Car("Mustang");
            Car car2 = new Car("Corvette");

            Console.WriteLine(Car.numberOfCars);

            Car.StartRace();

            Console.WriteLine(Math.Add(1,2,3,4,5));

        }
    }
    class Car
    {
        string model;
        public static int numberOfCars;

        public Car(string model)
        {
            this.model = model;
            numberOfCars += 1;
        }

        public static void StartRace()
        {
            Console.WriteLine("The race has began");
        }
    }

    //methods overloading => having a method with the same name but different signaatures

    class Point
    {
        public void Move(int x, int y) { }
        public void Move(Point newLocation) { }
        public void Move(Point newLocation, int speed) { }
    }

    // params modifier , used to pass a varying number of args to a method

   class Math
    {
        public static int Add(params int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }
    }

}
