namespace Events
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Publisher
    {
        public event EventHandler<EventArgs> PublisherChanged;

        public void TriggerEvent(string message)
        {
            PublisherChanged?.Invoke(this, new EventArgs());
        }

    }

    public class Subscriber
    {
        public void OnEventTriggered(string message) 
        {
            Console.WriteLine($"the event was triggered with the message : {message}");
        }
    }

}
