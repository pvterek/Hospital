using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManageStaff;
using Hospital.Objects.PatientObject;
using Hospital.Objects.WardObject;
using Hospital.Utilities;

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
        /// Executes the procedure to delete a ward. After selecting a ward, it's removed from the storage.
        /// </summary>
        public override void Execute()
        {
            Ward ward = (Ward)UserInterface.ShowInteractiveMenu(Storage.wards);

            if (Storage.wards.Remove(ward))
            {
                UserInterface.ShowMessage(string.Format(UIMessages.DeleteWardMessages.WardRemoved, ward.Name));
            }
            else
            {
                UserInterface.ShowMessage(UIMessages.DeleteWardMessages.ErrorWhileRemoving);
            }
        }
    }
}
