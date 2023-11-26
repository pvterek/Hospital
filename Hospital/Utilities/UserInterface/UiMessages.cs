namespace Hospital.Utilities.UserInterface
{
    internal static class UiMessages
    {
        internal static class AdmitPatientMessages
        {
            internal const string Introduce = "Admit a patient.";
            internal const string NoWardErrorPrompt = "No wards created to assign patient! Please create one first.";
            internal const string PatientCreatedPrompt = "Patient {0} {1} admited sucesfully!";
        }

        internal static class AssignToDoctorMessages
        {
            internal const string Introduce = "Assign to doctor";
            internal const string SelectPatientPrompt = "Pick for which patient you want assing doctor";
            internal const string SelectDoctorPrompt = "Pick to which doctor you want to assing the patient";
            internal const string NoDoctorsPrompt = "There is no doctor to assigned! Please add one first.";
            internal const string OperationSuccessPrompt = "{0} {1} has been assgined to the {2} {3}";
        }

        internal static class ChangeHealthStatusMessages
        {
            internal const string Introduce = "Change health status.";
            internal const string SelectPatientPrompt = "Pick for which patient you want change health status";
            internal const string OperationSuccessPrompt = "Health status of {0} {1} was changed successfully!";
        }

        internal static class DisplayPatientsMessages
        {
            internal const string Introduce = "Display all patients.";
            internal const string NoPatientsPrompt = "There is no patients in your hospital! Please add one first.";
        }

        internal static class ManagePatientMessages
        {
            internal const string Introduce = "Manage patient.";
        }

        internal static class ManagePatientsMessages
        {
            internal const string Introduce = "Manage patients.";
        }

        internal static class SignOutPatientMessages
        {
            internal const string Introduce = "Sign out patient";
            internal const string SignOutPrompt = "Pick which patient you want sign out.";
            internal const string SuccessSignOutPrompt = "Patient {0} {1} removed sucesfully!";
        }

        //ManageStaff
        internal static class DisplayEmployeesMessages
        {
            internal const string Introduce = "Display employees";
            internal const string NoEmployeesPrompt = "There is no employees in your hospital! Please add one first.";
        }

        internal static class FireEmployeeMessages
        {
            internal const string Introduce = "Fire employee";
            internal const string SelectEmployeePrompt = "Pick which employee you want to fire.";
            internal const string EmployeeFiredSuccessPrompt = "{0} {1} was fired successfully!";
            internal const string NoEmployeesPrompt = "There is no employees to fire.";
        }

        internal static class HireEmployeeMessages
        {
            internal const string Introduce = "Hire employee";
            internal const string SuccessHireEmployeePrompt = "{0} {1} hired!";
            internal const string ErrorHireEmployeePrompt = "Error occured while trying to hire employee!";
            internal const string UnsupportedEntityPrompt = "Unsupported entity type {0}.";
        }

        internal static class ManageEmployeesMessages
        {
            internal const string Introduce = "Manage employees";
        }

        //ManageWards
        internal static class AddWardMessages
        {
            internal const string Introduce = "Add ward";
            internal const string WardCreatedPrompt = "Ward {0} created!";
        }

        internal static class DeleteWardMessages
        {
            internal const string Introduce = "Delete ward";
            internal const string WardRemovedPrompt = "Ward removed: {0}!";
            internal const string WardNonEmptyPrompt = "Connot delete a ward to which patients or employees are assigned";
            internal const string SelectWardPrompt = "Select ward which you want to delete.";
            internal const string NoWardPrompt = "There are no ward that can be deleted! Please create one first.";
        }

        internal static class DisplayWardMessages
        {
            internal const string Introduce = "Display wards";
            internal const string NoWardPrompt = "There are no ward that can be displayed!";
        }

        internal static class ManageWardsMessages
        {
            internal const string Introduce = "Manage wards";
        }

        //Factory
        internal static class FactoryMessages
        {
            internal const string ProvideNamePrompt = "Enter a name: ";
            internal const string ProvideSurnamePrompt = "Enter a surname: ";
            internal const string EmptyFieldPrompt = "Field can't be empty!";
            internal const string ProvideGenderPrompt = "Enter a gender (Male, Female): ";
            internal const string InvalidGenderPrompt = "Invalid input. Please choose 'Male' or 'Female'.";
            internal const string ProvidePeselPrompt = "Enter a PESEL: ";
            internal const string InvalidPeselPrompt = "Invalid PESEL. It should be an 11-digit number. Please try again.";
            internal const string ProvideBirthdayPrompt = "Enter a birthday (e.g., DD-MM-YYYY):";
            internal const string InvalidBirthdayPrompt = "Birthday cannot be a future date. Please try again.";
            internal const string InvalidDateFormatPrompt = "Invalid date format. Please try again.";
            internal const string InvalidDatePrompt = "Invalid date. Please try again.";
            internal const string ProvideCapacityPrompt = "Please enter a positive capacity value:";
            internal const string NotValidNumberPrompt = "Please enter a valid number.";
            internal const string FullWardPrompt = "This ward is full. Create a new one!";
            internal const string ProvideLoginPrompt = "Enter login: ";
            internal const string EmptyLoginPrompt = "Login can't be empty!";
            internal const string TakenLoginPrompt = "This login already exists! Try a different one";
            internal const string ProvidePasswordPrompt = "Enter password: ";
            internal const string EmptyPasswordPrompt = "Login can't be empty!";
            internal const string TooShortPasswordPrompt = "The password is too short. It must be at least 9 characters long.";
            internal const string NoWardErrorPrompt = "No wards created to assign employee! Please create one first.";
            internal const string AbortedOperationPrompt = "User aborted the operation.";
            internal const string StopMessage = "stop";
        }

        //WardObject
        internal static class WardObjectMessages
        {
            internal const string Introduce = "Ward: {0} [{1}/{2}]";
            internal const string ProvideNamePrompt = "Provide ward name: ";
            internal const string EmptyNamePrompt = "Name can't be empty.";
        }

        //ExitCommand
        internal static class ExitCommandMessages
        {
            internal const string Introduce = "Exit";
        }

        //MainWindow
        internal static class MainWindowMessages
        {
            internal const string Introduce = "Main window";
        }

        //BackCommand
        internal static class BackCommandMessages
        {
            internal const string Introduce = "Go back";
        }

        //LoginWindow
        internal static class LoginWindowCommandMessages
        {
            internal const string Introduce = "Login window";
        }

        internal static class CreateAccountCommandMessages
        {
            internal const string Introduce = "Create account";
            internal const string CreatedAccountPrompt = "User {0} created successfully!";
        }

        internal static class LoginCommandMessages
        {
            internal const string Introduce = "Login";
            internal const string WrongPasswordPrompt = "Wrong password!";
            internal const string CantFindLoginPrompt = "No user with this login found!";
        }

        internal static class AuthenticationServiceMessages
        {
            internal const string ErrorGetUserByLoginPrompt = "Error occured while trying to get user login";
        }

        internal static class LogoutCommandMessages
        {
            internal const string Introduce = "Logout";
        }

        //UserObject
        internal static class UserObjectMessages
        {
            internal const string Introduce = "Welcome {0} {1}!";
        }

        //PatientObject
        internal static class PatientObjectMessages
        {
            internal const string Introduce = "{0} {1} [{2}] - patient at {3}.";
        }

        //NurseObject
        internal static class NurseObjectMessages
        {
            internal const string Introduce = "{0} {1} - {2} at {3} Ward.";
            internal const string Position = "Nurse";
        }

        internal static class DoctorObjectMessages
        {
            internal const string Introduce = "{0} {1} - {2} at {3} Ward.";
            internal const string Position = "Doctor";
        }

        internal static class DatabaseExceptions
        {
            internal const string QueryException = "Exception occured while trying to gather data from database!";
            internal const string ItemNull = "The provided item is null.";
            internal const string AddException = "Exception occurred while adding: {0}";
            internal const string RemoveException = "Exception occurred while removing: {0}";
            internal const string ItemNotFound = "Item of type {0} with ID {1} not found in the list.";
            internal const string UpdateException = "Exception occurred while updating: {0}";
        }

        //Exceptions
        internal static class ExceptionMessages
        {
            internal const string String = "Invalid or empty value provided!";
            internal const string Gender = "Invalid gender provided!";
            internal const string Date = "Invalid date provided!";
            internal const string Login = "Login is already taken!";
            internal const string Password = "Password don't meet requirements!";
            internal const string Pesel = "Provided pesel already taken or don't meet requirements!";
            internal const string WardName = "Provided invalid or already taken ward name!";
            internal const string Capacity = "Provided invalid capacity!";
            internal const string Command = "Invalid command selected!";
            internal const string EntityType = "Unsupported entity type {0}.";
            internal const string DTOValidation = "DTO validation failed.";
            internal const string WardFull = "Ward you want to assign patient is already full!";
        }
    }
}