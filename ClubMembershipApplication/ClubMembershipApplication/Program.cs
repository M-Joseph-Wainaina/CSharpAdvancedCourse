using ClubMembershipApplication.Views;

namespace ClubMembershipApplication
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            IViews mainView = Factory.GetMainViewObject();
            mainView.Runview();

            Console.ReadKey();
        }
    }
}
