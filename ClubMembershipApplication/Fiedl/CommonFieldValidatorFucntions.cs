using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FiedValidationAPI
{
    public delegate bool RequiredFieldDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldValue, out DateTime validDate);
    public delegate bool PatternMatch(string fieldValue, string pattern);
    public delegate bool CompareFieldIsValid(string fieldValue, string fieldValueCompare);

    public class CommonFieldValidatorFucntions
    {
        private static RequiredFieldDel _requiredFieldDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatch _patternMatch = null;
        private static CompareFieldIsValid _compareFieldIsValid = null;

        public static RequiredFieldDel RequiredFieldValidDel
        {
            get
            {
                if (_requiredFieldDel == null)
                    _requiredFieldDel = new RequiredFieldDel(RequiredFieldValid);
              
                return _requiredFieldDel;
            }
        }

        public static StringLengthValidDel StringLenghtValidField
        {
            get
            {
                if (_stringLengthValidDel == null)
                    _stringLengthValidDel = new StringLengthValidDel(StringLengthValid);

                return _stringLengthValidDel;
            }
        }

        public static DateValidDel DateFieldIsValid
        {
            get
            {
                if (_dateValidDel == null)
                    _dateValidDel = new DateValidDel(DateFieldValid);

                return _dateValidDel;
            }
        }

        public static PatternMatch PatternMatchIsValid
        {
            get
            {
                if (_patternMatch == null)
                    _patternMatch = new PatternMatch(PatternMatchValid);

                return _patternMatch;
            }
        }

        public static CompareFieldIsValid CompareFieldIsValid
        {
            get
            {
                if (_compareFieldIsValid == null)
                    _compareFieldIsValid = new CompareFieldIsValid(CompareFieldValid);

                return _compareFieldIsValid;
            }
        }
        private static bool RequiredFieldValid(string fieldValue)
        {
            if (!string.IsNullOrEmpty(fieldValue))
            {
                return true;
            }
            else return false;
        }

        private static bool StringLengthValid(string fieldValue, int min, int max)
        {
            if (fieldValue.Length >= min && fieldValue.Length >= max)
            {
                return true;
            }
            else return false;
        }

        private static bool DateFieldValid(string fieldValue, out DateTime validDate)
        {
            if (DateTime.TryParse(fieldValue, out validDate)) return true;
            else return false;
        }

        private static bool PatternMatchValid(string fieldValue, string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);

            if (regex.IsMatch(fieldValue))
                return true;
            else
                return false;
        }

        private static bool CompareFieldValid(string fieldValue, string fieldValueCompare)
        {
            if (fieldValue.Equals(fieldValueCompare))
                return true;
            else
                return false;
        }

    }
}
