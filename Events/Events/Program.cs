namespace Events
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press A to simulate a button click");

            var key = Console.ReadLine();

            if (key == "A")
            {
                KeyPressed();
            }

            
        }

        public static void KeyPressed()
        {
            Button button1 = new Button();

            button1.ClickEvent += (s, e) =>
            {
                Console.WriteLine("This is button 1 response");
            };

            Button button2 = new Button();

            button2.ClickEvent += (s, e) => { Console.WriteLine("This is button 2 response"); };


            button1.OnClick();
            button2.OnClick();
        }
    }

    public class Button
    {
        public EventHandler ClickEvent;


        public void OnClick()
        {
            ClickEvent.Invoke(this, EventArgs.Empty);
        }
    }

}
