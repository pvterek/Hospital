using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.PeopleCategories.UserClass;

namespace Hospital.Utilities
{
    internal interface IAuthenticationService
    {
        public bool Authenticate(string login, string password);
        public User? GetUserByLogin(string login);
    }
}
