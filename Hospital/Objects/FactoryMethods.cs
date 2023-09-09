using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Database;
using Hospital.Objects.PersonObject;
using Hospital.Objects.UserObject;
using Hospital.Objects.WardObject;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;
using NHibernate;

namespace Hospital.Objects
{
    /// <summary>
    /// Provides factory methods to aid in the creation of objects within the hospital system.
    /// </summary>
    internal class FactoryMethods
    {
        /// <summary>
        /// Asks the user for input based on a provided message and validates it.
        /// </summary>
        /// <param name="message">Message to display to the user.</param>
        /// <param name="errorMessage">Error message to display for invalid input.</param>
        /// <returns>Returns a valid input from the user.</returns>
        internal static string AskForValue(string message, string errorMessage)
        {
            string value;

            do
            {
                Console.Clear();

                Console.Write(message);
                value = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(value))
                {
                    UI.ShowMessage(errorMessage);
                }
            }
            while (string.IsNullOrWhiteSpace(value));

            return value;
        }

        /// <summary>
        /// Asks the user for gender input and ensures its validity.
        /// </summary>
        /// <returns>Returns a valid gender input from the user.</returns>
        protected static Gender AskForGender()
        {
            while (true)
            {
                Console.Clear();

                Console.Write(UIMessages.FactoryMessages.ProvideGenderPrompt);

                string input = Console.ReadLine();

                if (Enum.TryParse(typeof(Gender), input, out object genderObj))
                {
                    Gender gender = (Gender)genderObj;
                    if (gender == Gender.Male || gender == Gender.Female)
                    {
                        return gender;
                    }
                }

                UI.ShowMessage(UIMessages.FactoryMessages.InvalidGenderPrompt);
            }
        }

        /// <summary>
        /// Asks the user for a birthday input and ensures its validity.
        /// </summary>
        /// <returns>Returns a valid birthday input from the user.</returns>
        protected static DateTime AskForBirthday()
        {
            while (true)
            {
                Console.Clear();

                Console.Write(UIMessages.FactoryMessages.ProvideBirthdayPrompt);

                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthday))
                {
                    if (!(birthday <= DateTime.Today))
                    {
                        UI.ShowMessage(UIMessages.FactoryMessages.InvalidBirthdayPrompt);
                    }
                    else if (birthday < DateTime.Now.AddYears(-Person.MAX_AGE))
                    {
                        UI.ShowMessage(UIMessages.FactoryMessages.InvalidDatePrompt);
                    }
                    else
                    {
                        return birthday;
                    }
                }
                else
                {
                    UI.ShowMessage(UIMessages.FactoryMessages.InvalidDateFormatPrompt);
                }
            }
        }

        /// <summary>
        /// Assigns a person to a ward based on availability.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>Returns a valid ward assignment.</returns>
        protected static Ward? AssignToWard(ISession session)
        {
            try
            {
                Ward assignedWard = UI.ShowInteractiveMenu(DatabaseOperations<Ward>.GetAll(session).ToList());

                if (assignedWard.AssignedPatients.Count < assignedWard.Capacity)
                {
                    return assignedWard;
                }

                UI.ShowMessage(UIMessages.FactoryMessages.FullWardPrompt);

                return null;
            }
            catch (Exception ex)
            {
                UIHelper.HandleError(UIMessages.FactoryMessages.GetWardsErrorPrompt, ex);

                return null;
            }
        }

        /// <summary>
        /// Asks the user for ward assignment input.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>Returns a valid ward assignment from the user.</returns>
        protected static Ward? AskForAssignedWard(ISession session)
        {
            try
            {
                Ward assignedWard = UI.ShowInteractiveMenu(DatabaseOperations<Ward>.GetAll(session).ToList());

                return assignedWard;
            }
            catch (Exception ex)
            {
                UIHelper.HandleError(UIMessages.FactoryMessages.GetWardsErrorPrompt, ex);

                return null;
            }
        }

        /// <summary>
        /// Asks the user for a PESEL input and ensures its validity.
        /// </summary>
        /// <returns>Returns a valid PESEL input from the user.</returns>
        protected static string AskForPesel()
        {
            while (true)
            {
                Console.Clear();

                Console.Write(UIMessages.FactoryMessages.ProvidePeselPrompt);

                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && input.Length == 11 && input.All(char.IsDigit))
                {
                    return input;
                }

                UI.ShowMessage(UIMessages.FactoryMessages.InvalidPeselPrompt);
            }
        }

        /// <summary>
        /// Asks the user for capacity input for a specific ward and ensures its validity.
        /// </summary>
        /// <returns>Returns a valid capacity input from the user.</returns>
        internal static int AskForCapacity()
        {
            while (true)
            {
                Console.Clear();

                Console.Write(UIMessages.FactoryMessages.ProvideCapacityPrompt);

                string input = Console.ReadLine();

                if (int.TryParse(input, out int parsedInt))
                {
                    if (parsedInt > 0)
                    {
                        return parsedInt;
                    }
                    else
                    {
                        UI.ShowMessage(UIMessages.FactoryMessages.NegativeValuePrompt);
                    }
                }
                else
                {
                    UI.ShowMessage(UIMessages.FactoryMessages.NotValidNumberPrompt);
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter a login, checks if the provided login is non-empty and unique.
        /// </summary>
        /// <returns>A unique and non-empty user login.</returns>
        internal static string AskForLogin()
        {
            using var session = Program.sessionFactory.OpenSession();

            while (true)
            {
                Console.Clear();

                Console.Write(UIMessages.FactoryMessages.EnterLoginPrompt);

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    UI.ShowMessage(UIMessages.FactoryMessages.EmptyLoginPrompt);
                }
                else if (DatabaseOperations<User>.GetAll(session).Any(u => u.Login == input))
                {
                    UI.ShowMessage(UIMessages.FactoryMessages.TakenLoginPrompt);
                }
                else
                {
                    return input;
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter a password, checks if the provided password is non-empty and meets the length criteria.
        /// </summary>
        /// <returns>A password that meets the length criteria.</returns>
        internal static string AskForPassword()
        {
            while (true)
            {
                Console.Clear();

                Console.Write(UIMessages.FactoryMessages.EnterPasswordPrompt);

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    UI.ShowMessage(UIMessages.FactoryMessages.EmptyPasswordPrompt);
                }
                else if (input.Length < 9)
                {
                    UI.ShowMessage(UIMessages.FactoryMessages.TooShortPasswordPrompt);
                }
                else
                {
                    return input;
                }
            }
        }
    }
}