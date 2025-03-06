using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidator;
using ClubMembershipApplication.Views;

namespace ClubMembershipApplication
{
    public static class Factory
    {
        public static IViews GetMainViewObject()
        { 
            ILogin login = new LoginUser();
            IRegister register = new RegisterUser();
            IFieldValidator userRegisterationValidator = new UserRegistrationValidator(register);
            userRegisterationValidator.InitialiseValidatorDelegates();

            IViews registerView = new UserRegistrationView(register, userRegisterationValidator);
            IViews loginView = new UserLoginView(login);
            IViews mainView = new MainView(registerView, loginView);

            return mainView;

        }
    }
}
