using Hospital.Utilities.UserInterface;
using Hospital.Utilities.ListManagment;
using Hospital.PeopleCategories.Factory.Interfaces;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManageWards
{
    internal class AddWardCommand : CompositeCommand
    {
        private readonly IObjectsFactory _objectsFactory;
        private readonly IValidateObjects _validateObjects;
        private readonly IDTOFactory _dtoFactory;
        private readonly IMenuHandler _menuHandler;
        private readonly IListManage _listManage;
        private readonly IListsStorage _listsStorage;

        public AddWardCommand(
            IObjectsFactory objectsFactory,
            IValidateObjects validateObjects,
            IDTOFactory dtoFactory,
            IMenuHandler menuHandler,
            IListManage listManage,
            IListsStorage listsStorage) 
            : base(UiMessages.AddWardMessages.Introduce)
        {
            _objectsFactory = objectsFactory;
            _validateObjects = validateObjects;
            _dtoFactory = dtoFactory;
            _menuHandler = menuHandler;
            _listManage = listManage;
            _listsStorage = listsStorage;
        }

        public override void Execute()
        {
            var wardDTO = _dtoFactory.GatherWardData();
            if (!_validateObjects.ValidateWardObject(wardDTO))
            {
                return;
            }

            var ward = _objectsFactory.CreateWard(wardDTO);
            _listManage.Add(ward, _listsStorage.Wards);

            _menuHandler.ShowMessage(string.Format(UiMessages.AddWardMessages.WardCreatedPrompt, ward.Name));
        }
    }
}