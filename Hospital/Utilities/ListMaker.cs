using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects;

namespace Hospital.Utilities
{
    /// <summary>
    /// Provides functionalities related to displaying lists of entities that implement the <see cref="IHasIntroduceString"/> interface.
    /// </summary>
    internal class ListMaker
    {
        /// <summary>
        /// Displays a list of entities, presenting their 'IntroduceString' properties.
        /// </summary>
        /// <param name="persons">A list of entities that implement the <see cref="IHasIntroduceString"/> interface.</param>
        public static void DisplayList(List<IHasIntroduceString> persons)
        {
            StringBuilder introduceStrings = new();

            foreach (IHasIntroduceString person in persons)
            {
                introduceStrings.AppendLine(person.IntroduceString);
            }

            UserInterface.ShowMessage(introduceStrings.ToString());
        }
    }
}
