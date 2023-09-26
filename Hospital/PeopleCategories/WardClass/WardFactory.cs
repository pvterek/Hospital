using Hospital.Utilities.UserInterface;
using NHibernate;

namespace Hospital.PeopleCategories.WardClass
{
    /// <summary>
    /// Provides methods to create objects of the <see cref="Ward"/> class.
    /// </summary>
    internal class WardFactory
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Ward"/> class by prompting the user for necessary information.
        /// </summary>
        /// <returns>A new <see cref="Ward"/> object.</returns>
        public static Ward CreateWard(ISession session)
        {
            var name = FactoryMethods.AskForWardName(session);
            var capability = FactoryMethods.AskForCapacity();

            return new Ward(name, capability);
        }
    }
}
