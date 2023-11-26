using Hospital.PeopleCategories.UserClass;
using Hospital.Utilities.ListManagment;

namespace Hospital.Utilities
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IListsStorage _listsStorage;

        public AuthenticationService(IListsStorage listsStorage)
        {
            _listsStorage = listsStorage;
        }
        
        public bool Authenticate(string login, string password)
        {
            var user = GetUserByLogin(login);
            return user != null && user.Password == password;
        }

        public User? GetUserByLogin(string login)
        {
            return _listsStorage.Users.FirstOrDefault(u => u.Login == login);
        }
    }
}