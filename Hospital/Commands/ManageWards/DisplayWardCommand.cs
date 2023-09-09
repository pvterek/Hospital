using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManageStaff;
using Hospital.Commands.Navigation;
using Hospital.Objects;
using Hospital.Objects.WardObject;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;

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
        /// Executes the command to display the list of wards stored in the database.
        /// </summary>
        public override void Execute()
        {
            using var session = Program.sessionFactory.OpenSession();

            try
            {
                List<Ward> wards = WardDatabaseOperations.GetAllWards(session);
            
                if (!wards.Any())
                {
                    UI.ShowMessage(UIMessages.DisplayWardMessages.NoWardPrompt);
                }
                else
                {
                    DisplayWard(wards);
                }
            }
            catch (Exception ex)
            {
                UIHelper.HandleError(UIMessages.DisplayWardMessages.ErrorDisplayWardPrompt, ex);
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Displays a list of wards with their introduction messages.
        /// </summary>
        /// <param name="wards">The list of wards to display.</param>
        private void DisplayWard(List<Ward> wards) 
        {
            var introduceMessages = wards.Select(ward => ward.IntroduceString).ToList();

            ListMaker.DisplayList(introduceMessages);
        }
    }
}
