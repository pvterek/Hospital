using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManageStaff;
using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.Objects.WardObject;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;
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
        private DeleteWardCommand() : base(UIMessages.DeleteWardMessages.Introduce) { }

        /// <summary>
        /// Executes the procedure to delete a ward. After selecting a ward, it's removed from the database.
        /// </summary>
        public override void Execute()
        {
            using var session = Program.sessionFactory.OpenSession();

            try
            {
                List<Ward> wards = WardDatabaseOperations.GetAllWards(session);

                if (!wards.Any())
                {
                    UI.ShowMessage(UIMessages.DeleteWardMessages.NoWardPrompt);
                }
                else
                {
                    Ward ward = DeleteWard(session);

                    UI.ShowMessage(string.Format(UIMessages.DeleteWardMessages.WardRemovedPrompt, ward.Name));
                }
            }
            catch (Exception ex)
            {
                UIHelper.HandleError(UIMessages.DeleteWardMessages.ErrorWhileRemovingPrompt, ex);
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Deletes a ward, selected from the list of available wards in the database.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>The deleted ward.</returns>
        private Ward DeleteWard(ISession session) 
        {
            Ward ward = UI.ShowInteractiveMenu(DatabaseOperations<Ward>.GetAll(session).ToList());
            WardDatabaseOperations.DeleteWard(ward, session);

            return ward;
        }
    }
}
