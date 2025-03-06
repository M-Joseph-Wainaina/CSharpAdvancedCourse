using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.FieldValidator;
using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Views
{
    public class WelcomeUserView : IViews
    {
        User _user = null;

        public WelcomeUserView(User user)
        {
            _user = user;
        }

        public IFieldValidator FieldValidator => null;

        public void Runview()
        {
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"Welcome {_user.FirstName}!!!{Environment.NewLine} Welcome to the cycling club");
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.ReadKey();

        }
    }
}
