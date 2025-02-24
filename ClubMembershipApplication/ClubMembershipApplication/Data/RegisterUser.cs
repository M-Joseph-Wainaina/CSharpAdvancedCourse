using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;
using ClubMembershipApplication.FieldValidator;

namespace ClubMembershipApplication.Data
{
    internal class RegisterUser : IRegister
    {
        public bool EmailExists(string emailAddress)
        {
            bool emailExists = false;

            using (var dbContext = new ClubMembershipDbContext())
            {
                emailExists = dbContext.Users.Any(u => u.EmailAddress.ToLower().Trim() == emailAddress.Trim().ToLower());
            }

            return emailExists;
        }

        public bool Register(string[] fields)
        {
            using(var dbContext = new ClubMembershipDbContext() )
            {
                User user = new User
                {
                    EmailAddress = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                    AddressCity = fields[(int)FieldConstants.UserRegistrationField.AddressCity],
                    Password = fields[(int)FieldConstants.UserRegistrationField.Password],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
                    PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
                    PostCode = fields[(int)FieldConstants.UserRegistrationField.PostalCode]

                };

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                
            }

            return true;
        }
    }
}
