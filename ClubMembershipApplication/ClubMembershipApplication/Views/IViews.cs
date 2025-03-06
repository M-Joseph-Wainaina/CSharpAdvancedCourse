using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.FieldValidator;

namespace ClubMembershipApplication.Views
{
    public interface IViews
    {
        void Runview();

        IFieldValidator FieldValidator { get; }


    }
}
