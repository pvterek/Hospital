using Hospital.Commands.LoginWindow;
using Hospital.Commands.ManageUsers;
using Hospital.Database.Interfaces;
using Hospital.PeopleCategories.UserClass;
using Hospital.Utilities.Interfaces;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;
using Moq;
using NHibernate;

namespace Hospital.Test.ManageUsers
{
    public class DeleteUserCommandTest
    {
        private Mock<IMenuHandler> mockMenuHandler;
        private Mock<IListManage> mockListManage;
        private Mock<IListsStorage> mockListsStorage;
        private LoginCommand loginCommand;
        private Mock<IDatabaseOperations> mockDatabaseOperations;

        private DeleteUserCommand deleteUserCommand;

        private void SetUpMocks()
        {
            mockMenuHandler = new Mock<IMenuHandler>();
            mockListManage = new Mock<IListManage>();
            mockListsStorage = new Mock<IListsStorage>();
            loginCommand = new LoginCommand(
                new Mock<IAuthenticationService>().Object,
                mockMenuHandler.Object,
                new Mock<IInputHandler>().Object);
            mockDatabaseOperations = new Mock<IDatabaseOperations>();

            deleteUserCommand = new DeleteUserCommand(
                mockMenuHandler.Object,
                mockListManage.Object,
                mockListsStorage.Object,
                loginCommand);
        }

        [Fact]
        public void Execute_WhenUsersListEmpty_ShouldReturnEarly()
        {
            SetUpMocks();

            mockListsStorage.Setup(x => x.Users)
                .Returns([]);

            deleteUserCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(UiMessages.DeleteUserMessages.NoUserPrompt), Times.Once());
            mockMenuHandler.Verify(x => x.SelectObject(mockListsStorage.Object.Users, UiMessages.DeleteUserMessages.SelectUserPrompt), Times.Never());
        }

        [Fact]
        public void Execute_WhenUserToDeleteIsTheSameAsCurrentlyLoggedIn_ShouldReturnEarly()
        {
            SetUpMocks();

            var mockUser = new Mock<User>();
            var usersList = new List<User>() { mockUser.Object };

            mockListsStorage.Setup(x => x.Users)
                .Returns(usersList);
            mockMenuHandler.Setup(x => x.SelectObject(mockListsStorage.Object.Users, UiMessages.DeleteUserMessages.SelectUserPrompt))
                .Returns(mockUser.Object);
            loginCommand.CurrentlyLoggedIn = mockUser.Object;

            deleteUserCommand.Execute();

            mockListManage.Verify(x => x.Remove(It.IsAny<User>(), It.IsAny<List<User>>()), Times.Never());
            Assert.Contains(mockUser.Object, usersList);
        }

        [Fact]
        public void Execute_WhenUsersListNotEmpty_ShouldRemoveUser()
        {
            SetUpMocks();

            var mockUser = new Mock<User>();
            var usersList = new List<User>() { mockUser.Object };

            mockListsStorage.Setup(x => x.Users)
                .Returns(usersList);
            mockMenuHandler.Setup(x => x.SelectObject(mockListsStorage.Object.Users, UiMessages.DeleteUserMessages.SelectUserPrompt))
                .Returns(mockUser.Object);

            mockDatabaseOperations.Setup(x => x.Delete(It.IsAny<User>(), It.IsAny<ISession>()))
                .Returns(true);
            mockListManage.Setup(x => x.Remove(It.IsAny<User>(), It.IsAny<List<User>>()))
                .Callback((User item, List<User> list) =>
                {
                    if (mockDatabaseOperations.Object.Delete(item, new Mock<ISession>().Object))
                    {
                        list.Remove(item);
                    }
                });

            deleteUserCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(string.Format(UiMessages.DeleteUserMessages.OperationSuccessPrompt, mockUser.Object.Login)));
            Assert.DoesNotContain(mockUser.Object, usersList);
        }
    }
}