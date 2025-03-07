namespace Covariance_and_Contravariance
{
    internal class Program
    {
        delegate Car CarFactoryDelegate(int id, string name);
        static void Main(string[] args)
        {
            CarFactoryDelegate carFactoryDelegate = CarFactory.ReturnICECar;

            Car iceCar = carFactoryDelegate(1, "Toyota");

            Console.WriteLine(iceCar.GetCarDetails());

            carFactoryDelegate = CarFactory.ReturnEVCar;

            Car evCar = carFactoryDelegate(2, "B.Y.D");

            Console.WriteLine(evCar.GetCarDetails());


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
