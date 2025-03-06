using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.Data;
using ClubMembershipApplication.Models;
using ClubMembershipApplication.FieldValidator;

namespace ClubMembershipApplication.Views
{
    public class UserLoginView : IViews
    {
        public IFieldValidator FieldValidator => null ;

        ILogin _loginUser = null;

        public UserLoginView(ILogin login)
        {
            _loginUser = login;


        }

        public void Runview()
        {
            CommonOutputText.WriteMainHeading();

            CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please Enter Your Email Address");

            string EmailAddress = Console.ReadLine();

            Console.WriteLine("Please Enter Your Password");

            string Password = Console.ReadLine();

            User user = _loginUser.Login(EmailAddress, Password);

            if (user != null)
            {
                WelcomeUserView welcomeUserView = new WelcomeUserView(user);
                welcomeUserView.Runview();

            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);

                Console.WriteLine("The entered credentials does not match any of the systems records");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();
            }
        }
    }
}
