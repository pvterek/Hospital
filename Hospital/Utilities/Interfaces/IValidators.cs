using Hospital.Entities.Employee;
using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;

namespace Hospital.Utilities.Interfaces
{
    public interface IValidators
    {
        bool ValidateString(string input);
        bool ValidatePesel(string input);
        bool ValidateBirthday(DateTime birthday);
        bool ValidateGender(Gender gender);
        bool ValidateCapacity(int input);
        bool ValidateLogin(string input);
        bool ValidatePassword(string input);
        bool ValidateWardName(string input);
        bool ValidatePossibiltyAssignToWard(Ward ward);
        bool ValidatePosition(Position position);
    }
}