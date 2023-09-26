using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.Commands.ManageWards
{
    /// <summary>
    /// Represents a command to display the list of wards.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class DisplayWardCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="DisplayWardCommand"/> class.
        /// </summary>
        private static DisplayWardCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="DisplayWardCommand"/> class.
        /// </summary>
        internal static DisplayWardCommand Instance => _instance ??= new DisplayWardCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayWardCommand"/> class with a specific introduction message.
        /// </summary>
        private DisplayWardCommand() : base(UiMessages.DisplayWardMessages.Introduce) { }

        /// <summary>
        /// Executes the command to fetch and display the list of wards stored in the database. If no wards are found,
        /// a relevant message is displayed to the user.
        /// </summary>
        public override void Execute()
        {
            using var session = CreateSession.SessionFactory.OpenSession();

            var wards = (List<Ward>)DatabaseOperations<Ward>.GetAll(session);
            if (!wards.Any())
            {
                Ui.ShowMessage(UiMessages.DisplayWardMessages.NoWardPrompt);
            }
            else
            {
                ListMaker.DisplayList(wards);
            }

            NavigationCommand.Instance.Execute();
        }

    }
}