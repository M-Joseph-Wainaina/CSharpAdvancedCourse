using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.Data;
using FiedValidationAPI;


namespace ClubMembershipApplication.FieldValidator
{
    public class UserRegistrationValidator : IFieldValidator
    {
        const int FirstName_Min_Length = 2;
        const int FirstName_Max_Length = 10;
        const int LastName_Min_Length = 2;
        const int LastName_Max_Length = 10;

        delegate bool EmailExistsDel(string emailAddress);

        FieldValidatorDel _fieldValidatorDel = null;

        RequiredValidDel _requiredValidDel = null;
        StringLengthValidDel _stringLengthValidDel = null;
        DateValidDel _dateVaildDel = null;
        PatternMatchValidDel _patternMatchValidDel = null;
        CompareFieldIsValid _compareFieldValidDel = null;

        EmailExistsDel _emailExistsDel = null;

        IRegister _register = null;

        string[] _fieldArray = null;

        public string[] FieldArray
        {
            get
            {
                if (_fieldArray == null)
                {
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
                }
                return _fieldArray;

            }
        }

        public FieldValidatorDel ValidatorDel => _fieldValidatorDel;

        public UserRegistrationValidator(IRegister register)
        {
            _register = register;
        }

        public void InitialiseValidatorDelegates()
        {
            _fieldValidatorDel = new FieldValidatorDel(ValidateField); 
            _emailExistsDel = new EmailExistsDel(_register.EmailExists);
            _requiredValidDel = CommonFieldValidatorFucntions.RequiredFieldValidDel;
            _stringLengthValidDel = CommonFieldValidatorFucntions.StringLenghtValidField;
            _dateVaildDel = CommonFieldValidatorFucntions.DateFieldIsValid;
            _patternMatchValidDel = CommonFieldValidatorFucntions.PatternMatchIsValid;
            _compareFieldValidDel = CommonFieldValidatorFucntions.CompareFieldIsValid;

        }

        public bool ValidateField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = "";

            FieldConstants.UserRegistrationField userRegistrationFields = (FieldConstants.UserRegistrationField)fieldIndex;

            switch (userRegistrationFields)
            {
                case FieldConstants.UserRegistrationField.EmailAddress:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a valid field for : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPattern.Email_Address_RegEx_Pattern)) ? $"You must enter a valid email address {Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = (fieldInvalidMessage == "" && _emailExistsDel(fieldValue)) ? $"Your email already exists. Please try again {Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.FirstName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a valid field for : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthValidDel(fieldValue,FirstName_Min_Length, FirstName_Max_Length)) ? $"The length for the field is betweeen {FirstName_Min_Length} and {FirstName_Max_Length} {Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.LastName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a valid field for : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthValidDel(fieldValue, LastName_Min_Length, LastName_Max_Length)) ? $"The length for the field is betweeen {LastName_Min_Length} and {LastName_Max_Length} {Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.Password:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a valid field for : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPattern.Strong_Password_RegEx_Pattern)) ? $"Password must contain at least one small case letter, one capital letter, special character and must be between 6 to 10 characters  in length {Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PasswordCompare:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a valid field for : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_compareFieldValidDel(fieldValue, fieldArray[(int)FieldConstants.UserRegistrationField.Password] )) ? $"Password did not match {Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.DateOfBirth:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a valid field for : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_dateVaildDel(fieldValue, out DateTime validDate) )? $"You did not enter a valid date {Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PhoneNumber:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a valid field for : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPattern.Uk_PhoneNumber_RegEx_Pattern) )? $"You did not enter a valid UK phone number {Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.AddressFirstLine:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a valid field for : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationField.AddressSecondLine:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a valid field for : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationField.AddressCity:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a valid field for : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationField.PostalCode:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a valid field for : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPattern.Uk_Post_Code_RegEx_Pattern)) ? $"You did not enter a valid UK postal code {Environment.NewLine}" : fieldInvalidMessage;
                    break;
                default:
                    throw new ArgumentException("This field does not exist");
                    break;


            }

            return (fieldInvalidMessage == "");
        }
    }
}
