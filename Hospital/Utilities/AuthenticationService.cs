using Hospital.PeopleCategories.UserClass;
using Hospital.Utilities.ListManagment;

namespace Hospital.Utilities
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IListsStorage _listsStorage;

        public AuthenticationService(IListsStorage listsStorage)
        {
            _listsStorage = listsStorage;
        }
        
        public bool Authenticate(User user, string password)
        {
            return user != null && user.Password == password;
        }

        public User? GetUserByLogin(string login)
        {
            return _listsStorage.Users.FirstOrDefault(u => u.Login == login);
        }
    }
}