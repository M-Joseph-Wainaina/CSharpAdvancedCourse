namespace Covariance_and_Contravariance
{
    internal class Program
    {
        delegate Car CarFactoryDelegate(int id, string name);
        delegate void LogCarDetailsDEl(Car car);
        static void Main(string[] args)
        {
            //CarFactoryDelegate carFactoryDelegate = CarFactory.ReturnICECar;

            Car iceCar = CarFactory.ReturnICECar(1, "Toyota");
            
           // Console.WriteLine(iceCar.GetCarDetails());

            //carFactoryDelegate = CarFactory.ReturnEVCar;

            Car evCar = CarFactory.ReturnEVCar(2, "B.Y.D");

            // Console.WriteLine(evCar.GetCarDetails());
            LogCarDetailsDEl logCarDetailsDEL = LogCarDetails.LogCarDetailsToConsolAndFile;
            logCarDetailsDEL(iceCar);
            logCarDetailsDEL(evCar);


        }
    }
    public static class CarFactory
    {
        public static ICECar ReturnICECar(int id, string name)
        {
            return new ICECar { Id = id, Name = name };
        }

        public static EVCar ReturnEVCar(int id, string name)
        {
            return new EVCar { Id = id, Name = name };
        }
    }

    public static class LogCarDetails
    {
        public static void LogCarDetailsToConsolAndFile(Car car)
        {
            Console.WriteLine(car.GetCarDetails());
            using (StreamWriter sw = new StreamWriter($"{AppDomain.CurrentDomain.BaseDirectory}/logfile.txt", true))
            {
                sw.WriteLine(car.GetCarDetails());
            }
        }
    }



    public abstract class Car
    { 
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual string GetCarDetails() 
        {
            return $"Car Id {Id} and Car Name {Name}";
        }

    }
    public class EVCar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - and Engine type EV Car" ;
        }

    }
    public class ICECar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} -and Engine Type ICE Car";
        }
    }
}
