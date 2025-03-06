using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidator;

namespace ClubMembershipApplication.Views
{
    public class UserRegistrationView: IViews
    {
        IFieldValidator _fieldValidator = null;

        IRegister _register = null;

        public IFieldValidator FieldValidator { get => _fieldValidator;  }

        public UserRegistrationView (IRegister register, IFieldValidator fieldValidator)
        {
            _fieldValidator = fieldValidator;
            _register = register;

        }

        public void Runview()
        {
            CommonOutputText.WriteMainHeading();
            
            CommonOutputText.WriteRegisterationHeading();

            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.EmailAddress] = GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please Enter Your Email Address:");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.FirstName] = GetInputFromUser(FieldConstants.UserRegistrationField.FirstName, "Please Enter Your First Name:");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.LastName] = GetInputFromUser(FieldConstants.UserRegistrationField.LastName, "Please Enter Your Last Name: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.Password] = GetInputFromUser(FieldConstants.UserRegistrationField.Password, $"Please Enter Your Password . {Environment.NewLine} Your Password must contain at least one small case letter, One capital Letter, One digit one special character and length must be beween 6-10 chars");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PasswordCompare] = GetInputFromUser(FieldConstants.UserRegistrationField.PasswordCompare, "Please Re-Enter Your Password");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.DateOfBirth] = GetInputFromUser(FieldConstants.UserRegistrationField.DateOfBirth, "Please Enter Your DAte of Birth");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressFirstLine] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressFirstLine, "Please Enter Your Address First Line");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressSecondLine] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressSecondLine, "Please Enter Your Address Second Line");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressCity] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressCity, "Please Enter the city where you live");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PostalCode] = GetInputFromUser(FieldConstants.UserRegistrationField.PostalCode, "Please Enter Your Postal Code");

            RegisterUser();
        }

        private void RegisterUser()
        {
            _register.Register(_fieldValidator.FieldArray);

            CommonOutputFormat.ChangeFontColor(FontTheme.Success);

            Console.WriteLine($"YOU HAVE SUCCESSFULLY REGISGERED! {Environment.NewLine} PRESS ANY KEY TO LOGIN.");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);

            Console.ReadKey();

        }
        private string GetInputFromUser(FieldConstants.UserRegistrationField field, string promptText)
        {
            string fieldVal = "";

            do
            {
                Console.WriteLine(promptText);
                fieldVal = Console.ReadLine();


            }
            while (!FieldValid(field, fieldVal));
            
            return fieldVal;
        }

        private bool FieldValid(FieldConstants.UserRegistrationField field, string fieldValue)
        {
            if(!_fieldValidator.ValidatorDel((int)field, fieldValue, _fieldValidator.FieldArray, out string invalidMessage))
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine(invalidMessage);
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                return false;
                
            }

            return true;
        }

    }
}
