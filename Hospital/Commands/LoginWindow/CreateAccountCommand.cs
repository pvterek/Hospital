﻿using Hospital.PeopleCategories.Factory.Interfaces;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.LoginWindow
{
    public class CreateAccountCommand : CompositeCommand
    {
        private readonly IObjectsFactory _objectsFactory;
        private readonly IValidateObjects _validateObjects;
        private readonly IDTOFactory _dtoFactory;
        private readonly IMenuHandler _menuHandler;
        private readonly IListManage _listManage;
        private readonly IListsStorage _listsStorage;

        public CreateAccountCommand(
            IObjectsFactory objectsFactory,
            IValidateObjects validateObjects,
            IDTOFactory dtoFactory,
            IMenuHandler menuHandler,
            IListManage listManage,
            IListsStorage listsStorage)
            : base(UiMessages.CreateAccountCommandMessages.Introduce)
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
            var userDTO = _dtoFactory.GatherUserData();
            if (!_validateObjects.ValidateUserObject(userDTO))
            {
                return;
            }

            var user = _objectsFactory.CreateUser(userDTO);
            _listManage.Add(user, _listsStorage.Users);

            _menuHandler.ShowMessage(string.Format(UiMessages.CreateAccountCommandMessages.CreatedAccountPrompt, user.Login));
        }
    }
}