using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Data
{
    internal interface ILogin
    {
        User Login(string emailAddress , string password);

    }
}
