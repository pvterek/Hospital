using Hospital.PeopleCategories.UserClass;

namespace Hospital.Utilities
{
    internal interface IAuthenticationService
    {
        bool Authenticate(User user, string password);
        User? GetUserByLogin(string login);
    }
}