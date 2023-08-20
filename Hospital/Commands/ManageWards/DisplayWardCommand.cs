using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManageStaff;
using Hospital.Utilities;

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
        private DisplayWardCommand() : base(UIMessages.DisplayWardMessages.Introduce) { }

        /// <summary>
        /// Executes the command to display the list of wards stored in the system.
        /// </summary>
        public override void Execute()
        {
            ListMaker.DisplayList(Storage.wards);
        }
    }
}
