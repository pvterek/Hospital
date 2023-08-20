using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PersonObject;

namespace Hospital.Utilities
{
    internal class UIMessages
    {
        //ManagePatients
        public static class AdmitPatientMessages
        {
            public const string Introduce = "Admit a patient.";
            public const string NoWardErrorPrompt = "No wards created to assign patient! Please create one first.";
            public const string PatientCreatedPrompt = "Patient created";
        }

        public static class AssignToDoctorMessages
        {
            public const string Introduce = "Assign to doctor";
            public const string SelectPatientPrompt = "Pick what patient you want assing";
            public const string SelectDoctorPrompt = "Pick to which doctor you want assing patient";
        }

        public static class ChangeHealthStatusMessages
        {
            public const string Introduce = "Change health status.";
            public const string SelectPatientPrompt = "Pick for which patient you want change health status";
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
            public const string ErrorSignOutPrompt = "Error while removing patient!";
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
            public const string EmployeeFiredSuccessPrompt = "{0} was removed successfully.";
            public const string EmployeeFiredErrorPrompt = "Error while removing the employee.";
        }

        public static class HireEmployeeMessages
        {
            public const string Introduce = "Hire employee";
            public const string HiredSuccessPrompt = "{0} hired!";
        }

        public static class ManageStaffMessages
        {
            public const string Introduce = "Manage staff";
        }

        //ManageWards
        public static class AddWardMessages
        {
            public const string Introduce = "Add ward";
            public const string WardCreated = "Ward {0} created!";
        }

        public static class DeleteWardMessages
        {
            public const string Introduce = "Delete ward";
            public const string WardRemoved = "Ward removed: {0}.";
            public const string ErrorWhileRemoving = "Error while removing ward!";
        }

        public static class DisplayWardMessages
        {
            public const string Introduce = "Display wards";
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
            public const string InvalidHealthPrompt = "Invalid health status!";
            public const string ProvideCapacityPrompt = "Please enter a positive capacity value:";
            public const string NegativeValuePrompt = "The value cannot be negative or zero. Please try again.";
            public const string NotValidNumberPrompt = "Please enter a valid number.";
            public const string FullWardPrompt = "This ward is full. Create a new one!";
        }

        //WardObject
        public static class WardObjectMessages
        {
            public const string ProvideNamePrompt = "Provide ward name: ";
            public const string EmptyNamePrompt = "Name can't be empty.";
            public const string NullPrompt = "Ward cannot be null.";
        }

        //ExitCommand
        public static class ExitCommandMessages
        {
            public const string Introduce = "Go back";
        }

        //MainWindow
        public static class MainWindowMessages
        {
            public const string Introduce = "Main window";
        }
    }
}
