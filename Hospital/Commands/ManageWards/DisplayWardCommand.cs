using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManageWards
{
    public class DisplayWardCommand : Command
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

            var selectedWard = _menuHandler.SelectObject(_listsStorage.Wards, UiMessages.DisplayWardMessages.SelectWardPrompt);

            DisplayWardInformation(selectedWard);
        }

        private void DisplayWardInformation(Ward ward)
        {
            string wardInformation = string.Format(
                UiMessages.DisplayWardMessages.DisplayInformationsPrompt,
                ward.Name,
                ward.PatientsNumber,
                ward.Capacity,
                ward.PatientsNumber / ward.Capacity,
                ward.AssignedEmployees.Count
            );

            _menuHandler.ShowMessage(wardInformation);
        }
    }
}