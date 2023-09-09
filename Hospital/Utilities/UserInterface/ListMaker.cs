using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects;

namespace Hospital.Utilities.UI
{
    /// <summary>
    /// Provides functionalities related to displaying lists of entities that implement the <see cref="IHasIntroduceString"/> interface.
    /// </summary>
    internal class ListMaker
    {
        /// <summary>
        /// Displays a list of entities, presenting their 'IntroduceString' properties.
        /// </summary>
        /// <param name="objects">A list of entities that implement the <see cref="IHasIntroduceString"/> interface.</param>
        public static void DisplayList<TEntity>(List<TEntity> objects) where TEntity : class
        {
            StringBuilder introduceStrings = new();

            foreach (IHasIntroduceString obj in objects.Cast<IHasIntroduceString>())
            {
                introduceStrings.AppendLine(obj.IntroduceString);
            }

            UI.ShowMessage(introduceStrings.ToString());
        }
    }
}
