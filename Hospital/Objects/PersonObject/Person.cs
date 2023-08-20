using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Utilities;

namespace Hospital.Objects.PersonObject
{
    /// <summary>
    /// Represents a base entity for all person types in the hospital system.
    /// implements the <see cref="IHasIntroduceString"/> interface.
    /// </summary>
    internal abstract class Person : IHasIntroduceString
    {
        /// <summary>
        /// Gets or sets a string to represent the introduction of the person.
        /// </summary>
        public string IntroduceString { get; set; }

        /// <summary>
        /// Represents the maximum age a person can have.
        /// </summary>
        internal const int MAX_AGE = 150;

        private string _name;

        /// <summary>
        /// Gets or sets the name of the person. Throws an exception if the value is null or empty.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(UIMessages.FactoryMessages.EmptyFieldPrompt);
                }
                _name = value;
            }
        }

        private string _surname;

        /// <summary>
        /// Gets or sets the surname of the person. Throws an exception if the value is null or empty.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(UIMessages.FactoryMessages.EmptyFieldPrompt);
                }
                _surname = value;
            }
        }

        private Gender _gender;

        /// <summary>
        /// Gets or sets the gender of the person. Throws an exception if the gender is not defined in the Gender enumeration.
        /// </summary>
        public Gender Gender
        {
            get => _gender;
            set
            {
                if (!Enum.IsDefined(typeof(Gender), value))
                {
                    throw new ArgumentException(UIMessages.FactoryMessages.InvalidGenderPrompt);
                }
                _gender = value;
            }
        }

        private DateTime _birthday;

        /// <summary>
        /// Gets or sets the birthday of the person. Throws an exception if the date is in the future or exceeds the maximum age.
        /// </summary>
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException(UIMessages.FactoryMessages.InvalidBirthdayPrompt);
                }
                if (value < DateTime.Now.AddYears(-MAX_AGE))
                {
                    throw new ArgumentException(UIMessages.FactoryMessages.InvalidDatePrompt);
                }
                _birthday = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="name">The name of the person.</param>
        /// <param name="surname">The surname of the person.</param>
        /// <param name="gender">The gender of the person.</param>
        /// <param name="birthday">The birth date of the person.</param>
        public Person(string name, string surname, Gender gender, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            Birthday = birthday;
        }
    }
}
