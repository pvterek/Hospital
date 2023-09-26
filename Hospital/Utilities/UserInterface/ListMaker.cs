using System.Text;
using Hospital.PeopleCategories;

namespace Hospital.Utilities.UserInterface
{
    /// <summary>
    /// Provides functionalities related to displaying lists of entities that implement the <see cref="IHasIntroduceString"/> interface.
    /// </summary>
    internal static class ListMaker
    {
        /// <summary>
        /// Displays a list of entities, presenting their 'IntroduceString' properties.
        /// </summary>
        /// <param name="objects">A list of entities that implement the <see cref="IHasIntroduceString"/> interface.</param>
        public static void DisplayList<TEntity>(List<TEntity> objects) where TEntity : class
        {
            StringBuilder introduceStrings = new();

            foreach (var obj in objects.Cast<IHasIntroduceString>())
            {
                introduceStrings.AppendLine(obj.IntroduceString);
            }

            Ui.ShowMessage(introduceStrings.ToString());
        }
    }
}