using Hospital.Commands.LoginWindow;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManageUsers
{
    public class DeleteUserCommand : Command
    {
        private readonly IMenuHandler _menuHandler;
        private readonly IListManage _listManage;
        private readonly IListsStorage _listsStorage;
        private readonly LoginCommand _loginCommand;

        public DeleteUserCommand(
            IMenuHandler menuHandler,
            IListManage listManage,
            IListsStorage listsStorage,
            LoginCommand loginCommand)
            : base(UiMessages.DeleteUserMessages.Introduce)
        {
            _menuHandler = menuHandler;
            _listManage = listManage;
            _listsStorage = listsStorage;
            _loginCommand = loginCommand;
        }

        public override void Execute()
        {
            if (!_listsStorage.Users.Any())
            {
                _menuHandler.ShowMessage(UiMessages.DeleteUserMessages.NoUserPrompt);
                return;
            }

            var selectedUser = _menuHandler.SelectObject(
                _listsStorage.Users, UiMessages.DeleteUserMessages.SelectUserPrompt);

            if (_loginCommand.CurrentlyLoggedIn == selectedUser)
            {
                _menuHandler.ShowMessage(UiMessages.DeleteUserMessages.CurrentAccountErrorPrompt);
                return;
            }

            _listManage.SoftDelete(selectedUser, _listsStorage.Users);

            _menuHandler.ShowMessage(string.Format(UiMessages.DeleteUserMessages.OperationSuccessPrompt,
                selectedUser.Login));
        }
    }
}