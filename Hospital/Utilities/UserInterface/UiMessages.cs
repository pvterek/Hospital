﻿namespace Hospital.Utilities.UserInterface
{
    internal static class UiMessages
    {
        public static class AdmitPatientMessages
        {
            public const string Introduce = "Admit a patient.";
            public const string NoWardErrorPrompt = "No wards created to assign patient! Please create one first.";
            public const string PatientCreatedPrompt = "Patient {0} {1} admited sucesfully!";
        }

        public static class AssignToDoctorMessages
        {
            public const string Introduce = "Assign to doctor";
            public const string SelectPatientPrompt = "Pick for which patient you want assing doctor";
            public const string SelectDoctorPrompt = "Pick to which doctor you want to assing the patient";
            public const string NoDoctorsPrompt = "There is no doctors in selected ward yet.";
            public const string OperationSuccessPrompt = "{0} {1} has been assgined to the {2} {3}";
        }

        public static class ChangeHealthStatusMessages
        {
            public const string Introduce = "Change health status.";
            public const string SelectPatientPrompt = "Pick for which patient you want change health status";
            public const string OperationSuccessPrompt = "Health status of {0} {1} was changed successfully!";
        }

        public static class DisplayPatientsMessages
        {
            public const string Introduce = "Display all patients.";
            public const string NoPatientsPrompt = "There is no patients in selected ward yet.";
        }

        public static class ManagePatientMessages
        {
            public const string Introduce = "Manage patient.";
        }

        public static class ManagePatientsMessages
        {
            public const string Introduce = "Manage patients.";
        }

        public static class SignOutPatientMessages
        {
            public const string Introduce = "Sign out patient";
            public const string SignOutPrompt = "Pick which patient you want sign out.";
            public const string SuccessSignOutPrompt = "Patient {0} {1} removed sucesfully!";
        }

        //ManageStaff
        public static class DisplayEmployeesMessages
        {
            public const string Introduce = "Display employees";
            public const string NoEmployeesPrompt = "There is no employees in selected ward yet.";
        }

        public static class FireEmployeeMessages
        {
            public const string Introduce = "Fire employee";
            public const string SelectEmployeePrompt = "Pick which employee you want to fire.";
            public const string EmployeeFiredSuccessPrompt = "{0} {1} was fired successfully!";
            public const string NoEmployeesPrompt = "There is no employees to fire.";
        }

        public static class HireEmployeeMessages
        {
            public const string Introduce = "Hire employee";
            public const string SuccessHireEmployeePrompt = "{0} {1} hired!";
            public const string ErrorHireEmployeePrompt = "Error occured while trying to hire employee!";
        }

        public static class ManageEmployeesMessages
        {
            public const string Introduce = "Manage employees";
        }

        //ManageWards
        public static class AddWardMessages
        {
            public const string Introduce = "Add ward";
            public const string WardCreatedPrompt = "Ward {0} created!";
        }

        public static class DeleteWardMessages
        {
            public const string Introduce = "Delete ward";
            public const string WardRemovedPrompt = "Ward removed: {0}!";
            public const string WardNonEmptyPrompt = "Connot delete a ward to which patients or employees are assigned";
            public const string SelectWardPrompt = "Select ward which you want to delete.";
            public const string NoWardPrompt = "There are no ward that can be deleted! Please create one first.";
        }

        public static class DisplayWardMessages
        {
            public const string Introduce = "Display wards";
            public const string NoWardPrompt = "There are no ward that can be displayed!";
        }

        public static class ManageWardsMessages
        {
            public const string Introduce = "Manage wards";
        }

        //Factory
        public static class FactoryMessages
        {
            public const string ProvideNamePrompt = "Enter a name: ";
            public const string ProvideSurnamePrompt = "Enter a surname: ";
            public const string EmptyFieldPrompt = "Field can't be empty!";
            public const string ProvideGenderPrompt = "Enter a gender (Male, Female): ";
            public const string InvalidGenderPrompt = "Invalid input. Please choose 'Male' or 'Female'.";
            public const string ProvidePeselPrompt = "Enter a PESEL: ";
            public const string InvalidPeselPrompt = "Invalid PESEL. It should be an 11-digit number. Please try again.";
            public const string ProvideBirthdayPrompt = "Enter a birthday (e.g., DD-MM-YYYY):";
            public const string InvalidBirthdayPrompt = "Birthday cannot be a future date. Please try again.";
            public const string InvalidDateFormatPrompt = "Invalid date format. Please try again.";
            public const string InvalidDatePrompt = "Invalid date. Please try again.";
            public const string ProvideCapacityPrompt = "Please enter a positive capacity value:";
            public const string NotValidNumberPrompt = "Please enter a valid number.";
            public const string FullWardPrompt = "This ward is full. Create a new one!";
            public const string EnterLoginPrompt = "Enter login: ";
            public const string EmptyLoginPrompt = "Login can't be empty!";
            public const string TakenLoginPrompt = "This login already exists! Try a different one";
            public const string EnterPasswordPrompt = "Enter password: ";
            public const string EmptyPasswordPrompt = "Login can't be empty!";
            public const string TooShortPasswordPrompt = "The password is too short. It must be at least 9 characters long.";
            public const string NoWardErrorPrompt = "No wards created to assign employee! Please create one first.";
        }

        //WardObject
        public static class WardObjectMessages
        {
            public const string Introduce = "Ward: {0} [{1}/{2}]";
            public const string ProvideNamePrompt = "Provide ward name: ";
            public const string EmptyNamePrompt = "Name can't be empty.";
        }

        //ExitCommand
        public static class ExitCommandMessages
        {
            public const string Introduce = "Exit";
        }

        //MainWindow
        public static class MainWindowMessages
        {
            public const string Introduce = "Main window";
        }

        //BackCommand
        public static class BackCommandMessages
        {
            public const string Introduce = "Go back";
        }

        //LoginWindow
        public static class LoginWindowCommandMessages
        {
            public const string Introduce = "Login window";
        }

        public static class CreateAccountCommandMessages
        {
            public const string Introduce = "Create account";
            public const string CreatedAccountPrompt = "User {0} created successfully!";
            public const string ErrorCreateAccountPrompt = "Error occured while trying to create an account!";
        }

        public static class LoginCommandMessages
        {
            public const string Introduce = "Login";
            public const string WrongPasswordPrompt = "Wrong password!";
            public const string CantFindLoginPrompt = "No user with this login found!";
        }

        public static class AuthenticationServiceMessages
        {
            public const string ErrorGetUserByLoginPrompt = "Error occured while trying to get user login";
        }

        public static class LogoutCommandMessages
        {
            public const string Introduce = "Logout";
        }

        //UserObject
        public static class UserObjectMessages
        {
            public const string Introduce = "Welcome {0} {1}!";
        }

        //PatientObject
        public static class PatientObjectMessages
        {
            public const string Introduce = "{0} {1} [{2}] - patient at {3}.";
        }

        //NurseObject
        public static class NurseObjectMessages
        {
            public const string Introduce = "{0} {1} - {2} at {3} Ward.";
            public const string Position = "Nurse";
        }

        public static class DoctorObjectMessages
        {
            public const string Introduce = "{0} {1} - {2} at {3} Ward.";
            public const string Position = "Doctor";
        }
    }
}