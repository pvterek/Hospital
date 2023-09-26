using Hospital.Utilities.UserInterface;

namespace Hospital.PeopleCategories.PersonClass
{
    /// <summary>
    /// Represents a base entity for all person types in the hospital system.
    /// implements the <see cref="IHasIntroduceString"/> interface.
    /// </summary>
    public abstract class Person : IHasIntroduceString
    {
        /// <summary>
        /// Gets or sets the unique identifier for the person.
        /// </summary>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Gets or sets a string to represent the introduction of the person.
        /// </summary>
        public virtual string IntroduceString { get; set; }

        /// <summary>
        /// Represents the maximum age a person can have.
        /// </summary>
        internal const int MaxAge = 150;

        private string _name;

        /// <summary>
        /// Gets or sets the name of the person. Throws an exception if the value is null or empty.
        /// </summary>
        public virtual string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(UiMessages.FactoryMessages.EmptyFieldPrompt);
                }
                _name = value;
            }
        }

        private string _surname;

        /// <summary>
        /// Gets or sets the surname of a person. Throws an exception if the value is null or empty.
        /// </summary>
        public virtual string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(UiMessages.FactoryMessages.EmptyFieldPrompt);
                }
                _surname = value;
            }
        }

        private Gender _gender;

        /// <summary>
        /// Gets or sets the gender of the person. Throws an exception if the gender is not defined in the Gender enumeration.
        /// </summary>
        public virtual Gender Gender
        {
            get => _gender;
            set
            {
                if (!Enum.IsDefined(typeof(Gender), value))
                {
                    throw new ArgumentException(UiMessages.FactoryMessages.InvalidGenderPrompt);
                }
                _gender = value;
            }
        }

        private DateTime _birthday;

        /// <summary>
        /// Gets or sets the birthday of the person. Throws an exception if the date is in the future or exceeds the maximum age.
        /// </summary>
        public virtual DateTime Birthday
        {
            get => _birthday;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException(UiMessages.FactoryMessages.InvalidBirthdayPrompt);
                }
                if (value < DateTime.Now.AddYears(-MaxAge))
                {
                    throw new ArgumentException(UiMessages.FactoryMessages.InvalidDatePrompt);
                }
                _birthday = value;
            }
        }

        /// <summary>
        /// Constructor needed for NHibernate.
        /// </summary>
        protected Person() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class with specified properties.
        /// </summary>
        /// <param name="name">The first name of the person.</param>
        /// <param name="surname">The last name of the person.</param>
        /// <param name="gender">The gender of the person.</param>
        /// <param name="birthday">The date of birth of the person.</param>
        protected Person(string name, string surname, Gender gender, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            Birthday = birthday;
        }
    }
}