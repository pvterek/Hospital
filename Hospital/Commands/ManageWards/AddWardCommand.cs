using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManagePatients;
using Hospital.Commands.ManageStaff;
using Hospital.Commands.Navigation;
using Hospital.Objects.WardObject;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;
using NHibernate;
using static System.Collections.Specialized.BitVector32;

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
        private AddWardCommand() : base(UIMessages.AddWardMessages.Introduce) { }

        /// <summary>
        /// Executes the procedure to add a new ward. The ward details are created using a factory method and then added to the database.
        /// </summary>
        public override void Execute()
        {
            using var session = Program.sessionFactory.OpenSession();

            try
            {
                Ward ward = AddWard(session);
            
                UI.ShowMessage(string.Format(UIMessages.AddWardMessages.WardCreatedPrompt, ward.Name));
            }
            catch (Exception ex) 
            {
                UIHelper.HandleError(UIMessages.AddWardMessages.ErrorWhileCreatingPrompt, ex);
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Adds a new ward to the database and returns the created ward.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>The newly created ward.</returns>
        private Ward AddWard(ISession session)
        {
            Ward ward = WardFactory.CreateWard();
            WardDatabaseOperations.AddWard(ward, session);

            return ward;
        }
    }
}
