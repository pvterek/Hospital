using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManagePatients;
using Hospital.Utilities;
using Microsoft.VisualBasic.FileIO;

namespace Hospital.Commands.ManageWards
{
    /// <summary>
    /// Represents a command to manage wards.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class ManageWardsCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="ManageWardsCommand"/> class.
        /// </summary>
        private static ManageWardsCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="ManageWardsCommand"/> class.
        /// </summary>
        internal static ManageWardsCommand Instance => _instance ??= new ManageWardsCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageWardsCommand"/> class with a specific introduction message and a list of sub-commands.
        /// </summary>
        private ManageWardsCommand() : base(UIMessages.ManageWardsMessages.Introduce, new List<CompositeCommand>())
        {
            Commands.Add(AddWardCommand.Instance);
            Commands.Add(DeleteWardCommand.Instance);
            Commands.Add(DisplayWardCommand.Instance);
            Commands.Add(BackCommand.Instance);
        }

        /// <summary>
        /// Executes the command to manage wards, allowing the user to select from various management options.
        /// </summary>
        public override void Execute()
        {
            CompositeCommand command = UserInterface.ShowInteractiveMenu(Commands);
            BackCommand.Queue(command);
        }
    }
}
