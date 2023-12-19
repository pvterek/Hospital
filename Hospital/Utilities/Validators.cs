using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.Interfaces;
using Hospital.Utilities.ListManagment;

namespace Hospital.Utilities
{
    public class Validators : IValidators
    {
        private readonly IListsStorage _listsStorage;
        private readonly int MaxAge = 150;

        public Validators(IListsStorage populateLists)
        {
            _listsStorage = populateLists;
        }

        public bool ValidateString(string input) => !string.IsNullOrWhiteSpace(input);

        public bool ValidatePesel(string input)
        {
            return !string.IsNullOrWhiteSpace(input)
                && input.Length == 11
                && input.All(char.IsDigit)
                && _listsStorage.Pesels.Add(input);
        }

        public bool ValidateBirthday(DateTime birthday)
            => birthday <= DateTime.Today && birthday >= DateTime.Today.AddYears(-MaxAge);

        public bool ValidateGender(Gender gender)
            => Enum.IsDefined(typeof(Gender), gender);

        public bool ValidateCapacity(int input) => input > 0;

        public bool ValidateLogin(string input)
            => !string.IsNullOrWhiteSpace(input) && _listsStorage.Logins.Add(input);

        public bool ValidatePassword(string input)
            => !string.IsNullOrWhiteSpace(input) && input.Length >= 9;

        public bool ValidateWardName(string input)
            => !string.IsNullOrWhiteSpace(input) && _listsStorage.WardsNames.Add(input);

        public bool ValidatePossibiltyAssignToWard(Ward ward)
            => ward.AssignedPatients.Count < ward.Capacity;
    }
}