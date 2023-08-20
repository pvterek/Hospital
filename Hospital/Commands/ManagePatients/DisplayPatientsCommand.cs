using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PatientObject;
using Hospital.Utilities;

namespace Hospital.Commands.ManagePatients
{
    /// <summary>
    /// Represents a command to display patients.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class DisplayPatientsCommand : CompositeCommand
    {
        private static DisplayPatientsCommand? _instance;

        /// <summary>
        /// Singleton instance of the <see cref="DisplayPatientsCommand"/> class.
        /// </summary>
        internal static DisplayPatientsCommand Instance => _instance ??= new DisplayPatientsCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayPatientsCommand"/> class.
        /// </summary>
        private DisplayPatientsCommand() : base(UIMessages.DisplayPatientsMessages.Introduce) { }

        /// <summary>
        /// Executes the display patients command.
        /// If there are no patients, displays a no patients prompt.
        /// Otherwise, it will display the list of patients.
        /// </summary>
        public override void Execute()
        {
            if (Storage.patients.Count == 0)
            {
                UserInterface.ShowMessage(UIMessages.DisplayPatientsMessages.NoPatientsPrompt);
            }
            else
            {
                ListMaker.DisplayList(Storage.patients);
            }
        }
    }
}
