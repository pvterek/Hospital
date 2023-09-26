using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;
using NHibernate;

namespace Hospital.Commands.ManageWards
{
    /// <summary>
    /// Represents a command to delete an existing ward.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class DeleteWardCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="DeleteWardCommand"/> class.
        /// </summary>
        private static DeleteWardCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="DeleteWardCommand"/> class.
        /// </summary>
        internal static DeleteWardCommand Instance => _instance ??= new DeleteWardCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWardCommand"/> class with a specific introduction message.
        /// </summary>
        private DeleteWardCommand() : base(UiMessages.DeleteWardMessages.Introduce) { }

        /// <summary>
        /// Executes the procedure to delete a ward. After selecting a ward, it's removed from the database.
        /// </summary>
        public override void Execute()
        {
            using var session = CreateSession.SessionFactory.OpenSession();

            var wards = (List<Ward>)DatabaseOperations<Ward>.GetAll(session);
            if (!wards.Any())
            {
                Ui.ShowMessage(UiMessages.DeleteWardMessages.NoWardPrompt);
            }
            else
            {
                var ward = UiHelper.SelectObject(wards, UiMessages.DeleteWardMessages.SelectWardPrompt);

                if (IsEmpty(ward))
                {
                    DeleteWard(ward, session);
                    
                    Ui.ShowMessage(string.Format(UiMessages.DeleteWardMessages.WardRemovedPrompt, ward.Name));   
                }
                
                Ui.ShowMessage(UiMessages.DeleteWardMessages.WardNonEmptyPrompt);
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Deletes the provided ward from the database.
        /// </summary>
        /// <param name="ward">The ward to be deleted.</param>
        /// <param name="session">The database session to use for the operation.</param>
        private void DeleteWard(Ward ward, ISession session)
        {
            DatabaseOperations<Ward>.Delete(ward, session);
        }

        /// <summary>
        /// Checks if the provided ward is empty, i.e., it has no assigned patients and no assigned employees.
        /// </summary>
        /// <param name="ward">The ward to be checked.</param>
        /// <returns>True if the ward is empty, otherwise false.</returns>
        private bool IsEmpty(Ward ward)
        {
            return !ward.AssignedPatients.Any() || !ward.AssignedEmployees.Any();
        }
    }
}