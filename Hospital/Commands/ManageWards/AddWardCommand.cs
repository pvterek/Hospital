using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManageStaff;
using Hospital.Objects.WardObject;
using Hospital.Utilities;

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
        /// Executes the procedure to add a new ward. The ward details are created using a factory method and then added to the storage.
        /// </summary>
        public override void Execute()
        {
            Console.Clear();
            Ward ward = WardFactory.CreateWard();
            Storage.wards.Add(ward);

            UserInterface.ShowMessage(string.Format(UIMessages.AddWardMessages.WardCreated, ward.Name));
        }
    }
}
