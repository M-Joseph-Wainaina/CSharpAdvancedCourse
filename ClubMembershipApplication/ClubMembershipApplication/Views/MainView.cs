using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.FieldValidator;

namespace ClubMembershipApplication.Views
{
    public class MainView : IViews
    {
        public IFieldValidator FieldValidator => null;

        IViews _regiserView = null;
        IViews _loginView = null;


        public MainView(IViews registerView, IViews loginview) 
        { 
            _regiserView = registerView;
            _loginView = loginview;

        }

        public void Runview()
        {
            CommonOutputText.WriteMainHeading();

            Console.WriteLine("Please Press The L key to login or the R key to register");

            string UserOption = Console.ReadLine();

            switch (UserOption)
            {
                case "L":
                    RunUserLogin();
                    break;
                case "R":
                    RunUserRegisteration();
                    RunUserLogin();

                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Goodbye!!!");
                    Console.ReadKey();
                    break;
            }
        }

        private void RunUserRegisteration()
        {
            _regiserView.Runview();
        }

        public void RunUserLogin()
        {
            _loginView.Runview();
        }
    }
}
