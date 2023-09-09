using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PersonObject;
using Hospital.Utilities.UI.UserInterface;

namespace Hospital.Objects.WardObject
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
        public static Ward CreateWard()
        {
            string name = FactoryMethods.AskForValue(UIMessages.WardObjectMessages.ProvideNamePrompt, UIMessages.WardObjectMessages.EmptyNamePrompt);
            int capability = FactoryMethods.AskForCapacity();

            return new Ward(name, capability);
        }
    }
}
