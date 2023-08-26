using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.UserObject;
using Hospital.Objects.WardObject;
using Hospital.Utilities;

namespace Hospital.Objects.PersonObject
{
    /// <summary>
    /// Provides factory methods to aid in the creation of person objects within the hospital system.
    /// </summary>
    internal class PersonFactory
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
                Console.Write(message);
                value = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine(errorMessage);
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

                Console.WriteLine(UIMessages.FactoryMessages.InvalidGenderPrompt);
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
                Console.Write(UIMessages.FactoryMessages.ProvideBirthdayPrompt);
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthday))
                {
                    if (!(birthday <= DateTime.Today))
                    {
                        Console.WriteLine(UIMessages.FactoryMessages.InvalidBirthdayPrompt);
                    }
                    else if (birthday < DateTime.Now.AddYears(-Person.MAX_AGE))
                    {
                        Console.WriteLine(UIMessages.FactoryMessages.InvalidDatePrompt);
                    }
                    else
                    {
                        return birthday;
                    }
                }
                else
                {
                    Console.WriteLine(UIMessages.FactoryMessages.InvalidDateFormatPrompt);
                }
            }
        }

        /// <summary>
        /// Assigns a person to a ward based on availability.
        /// </summary>
        /// <returns>Returns a valid ward assignment.</returns>
        protected static Ward AssignToWard()
        {
            Ward assignedWard = (Ward)UserInterface.ShowInteractiveMenu(Storage.wards);
        
            if (assignedWard.Patients.Count >= assignedWard.Capacity)
            {
                throw new Exception(UIMessages.FactoryMessages.FullWardPrompt);
            }
        
            return assignedWard;
        }

        /// <summary>
        /// Asks the user for ward assignment input.
        /// </summary>
        /// <returns>Returns a valid ward assignment from the user.</returns>
        protected static Ward AskForAssignedWard()
        {
            return (Ward)UserInterface.ShowInteractiveMenu(Storage.wards);
        }

        /// <summary>
        /// Asks the user for a PESEL input and ensures its validity.
        /// </summary>
        /// <returns>Returns a valid PESEL input from the user.</returns>
        protected static string AskForPesel()
        {
            while (true)
            {
                Console.Write(UIMessages.FactoryMessages.ProvidePeselPrompt);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && input.Length == 11 && input.All(char.IsDigit))
                {
                    return input;
                }

                Console.WriteLine(UIMessages.FactoryMessages.InvalidPeselPrompt);
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
                        Console.WriteLine(UIMessages.FactoryMessages.NegativeValuePrompt);
                    }
                }
                else
                {
                    Console.WriteLine(UIMessages.FactoryMessages.NotValidNumberPrompt);
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter a login, checks if the provided login is non-empty and unique.
        /// </summary>
        /// <returns>A unique and non-empty user login.</returns>
        internal static string AskForLogin()
        {
            while (true)
            {
                Console.Write(UIMessages.FactoryMessages.EnterLoginPrompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(UIMessages.FactoryMessages.EmptyLoginPrompt);
                }
                else if (Storage.users.Any(u => u.Login == input))
                {
                    Console.WriteLine(UIMessages.FactoryMessages.TakenLoginPrompt);
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
                Console.Write(UIMessages.FactoryMessages.EnterPasswordPrompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(UIMessages.FactoryMessages.EmptyPasswordPrompt);
                }
                else if (input.Length < 9)
                {
                    Console.WriteLine(UIMessages.FactoryMessages.TooShortPasswordPrompt);
                }
                else
                {
                    return input;
                }
            }
        }
    }
}
