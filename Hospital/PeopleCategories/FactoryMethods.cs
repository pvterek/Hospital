using Hospital.Database;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.UserClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;
using NHibernate;

namespace Hospital.PeopleCategories
{
    internal class FactoryMethods
    {
        private static string PromptAndValidate(string promptMessage, Func<string, bool> validator, string errorMessage)
        {
            string value;
            do
            {
                Console.Clear();
                Console.Write(promptMessage);
                value = Console.ReadLine();

                if (!validator(value))
                {
                    Ui.ShowMessage(errorMessage);
                }

            } while (!validator(value));
            
            return value;
        }

        internal static string AskForValue(string message, string errorMessage)
        {
            return PromptAndValidate(message, input => !string.IsNullOrWhiteSpace(input), errorMessage);
        }

        protected static Gender AskForGender()
        {
            var genderString = PromptAndValidate(
                UiMessages.FactoryMessages.ProvideGenderPrompt,
                input => Enum.TryParse(typeof(Gender), input, true, out var result) 
                         && ((Gender)result == Gender.Male || (Gender)result == Gender.Female),
                UiMessages.FactoryMessages.InvalidGenderPrompt);
            return Enum.Parse<Gender>(genderString);
        }

        protected static DateTime AskForBirthday()
        {
            return DateTime.Parse(PromptAndValidate(
                UiMessages.FactoryMessages.ProvideBirthdayPrompt,
                input => DateTime.TryParse(input, out var birthday) 
                         && birthday <= DateTime.Today 
                         && birthday >= DateTime.Now.AddYears(-Person.MaxAge),
                UiMessages.FactoryMessages.InvalidDateFormatPrompt));
        }

        protected static Ward AssignToWard(List<Ward> wards)
        {
            var assignedWard = Ui.ShowInteractiveMenu(wards);
            if (assignedWard.AssignedPatients.Count >= assignedWard.Capacity)
            {
                throw new Exception(UiMessages.FactoryMessages.FullWardPrompt);
            }
            return assignedWard;
        }

        protected static Ward AskForAssignedWard(List<Ward> wards)
        {
            return Ui.ShowInteractiveMenu(wards);
        }

        protected static string AskForPesel(ISession session)
        {
            var peselList = DatabaseOperations<Patient>.GetAll(session).Select(x => x.Pesel).ToList();
            return PromptAndValidate(
                UiMessages.FactoryMessages.ProvidePeselPrompt,
                input => IsValidPesel(input, peselList),
                UiMessages.FactoryMessages.InvalidPeselPrompt);
        }

        private static bool IsValidPesel(string input, List<string> peselList)
        {
            return !string.IsNullOrWhiteSpace(input) && 
                   input.Length == 11 && 
                   input.All(char.IsDigit) && 
                   !peselList.Contains(input);
        }

        internal static int AskForCapacity()
        {
            return int.Parse(PromptAndValidate(
                UiMessages.FactoryMessages.ProvideCapacityPrompt,
                input => int.TryParse(input, out int parsedInt) && parsedInt > 0,
                UiMessages.FactoryMessages.NotValidNumberPrompt));
        }

        internal static string AskForLogin()
        {
            using var session = CreateSession.SessionFactory.OpenSession();
            return PromptAndValidate(
                UiMessages.FactoryMessages.EnterLoginPrompt,
                input => !string.IsNullOrWhiteSpace(input) 
                         && !DatabaseOperations<User>.GetAll(session).Any(u => u.Login == input),
                UiMessages.FactoryMessages.TakenLoginPrompt);
        }

        internal static string AskForPassword()
        {
            return PromptAndValidate(
                UiMessages.FactoryMessages.EnterPasswordPrompt,
                input => !string.IsNullOrWhiteSpace(input) && input.Length >= 9,
                UiMessages.FactoryMessages.TooShortPasswordPrompt);
        }

        internal static string AskForWardName(ISession session)
        {
            var wardsNameList = DatabaseOperations<Ward>.GetAll(session).Select(x => x.Name).ToList();
            return PromptAndValidate(
                UiMessages.WardObjectMessages.ProvideNamePrompt,
                input => !string.IsNullOrWhiteSpace(input) && !wardsNameList.Contains(input),
                UiMessages.WardObjectMessages.EmptyNamePrompt);
        }
    }
}