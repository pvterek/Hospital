using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;
using NHibernate;

namespace Hospital.Commands.ManageWards
{
    /// <summary>
    /// Represents a command to add a new ward.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class AddWardCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="AddWardCommand"/> class.
        /// </summary>
        private static AddWardCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="AddWardCommand"/> class.
        /// </summary>
        internal static AddWardCommand Instance => _instance ??= new AddWardCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="AddWardCommand"/> class with a specific introduction message.
        /// </summary>
        private AddWardCommand() : base(UiMessages.AddWardMessages.Introduce) { }

        /// <summary>
        /// Executes the procedure to add a new ward. The ward details are created using a factory method and then added to the database.
        /// </summary>
        public override void Execute()
        {
            using var session = CreateSession.SessionFactory.OpenSession();

            var ward = AddWard(session);
            
            Ui.ShowMessage(string.Format(UiMessages.AddWardMessages.WardCreatedPrompt, ward.Name));

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Adds a new ward to the database and returns the created ward.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>The newly created ward.</returns>
        private Ward AddWard(ISession session)
        {
            var ward = WardFactory.CreateWard(session);
            DatabaseOperations<Ward>.Add(ward, session);

            return ward;
        }
    }
}