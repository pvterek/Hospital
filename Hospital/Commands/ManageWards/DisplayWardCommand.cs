using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManageWards
{
    internal class DisplayWardCommand : CompositeCommand
    {
        private readonly IMenuHandler _menuHandler;
        private readonly IListsStorage _listsStorage;

        public DisplayWardCommand(
            IMenuHandler menuHandler,
            IListsStorage listsStorage) 
            : base(UiMessages.DisplayWardMessages.Introduce) 
        {
            _menuHandler = menuHandler;
            _listsStorage = listsStorage;
        }

        public override void Execute()
        {
            if (!_listsStorage.Wards.Any())
            {
                _menuHandler.ShowMessage(UiMessages.DisplayWardMessages.NoWardPrompt);
                return;
            }

            _menuHandler.DisplayList(_listsStorage.Wards);
        }
    }
}