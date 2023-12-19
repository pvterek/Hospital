using Hospital.Commands.ManageWards;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;
using Moq;

namespace Hospital.Test.ManageWardsTests
{
    public class DisplayWardCommandTest
    {
        private Mock<IMenuHandler> mockMenuHandler;
        private Mock<IListsStorage> mockListsStorage;

        private DisplayWardCommand displayWardCommand;

        private void SetUpMocks()
        {
            mockMenuHandler = new Mock<IMenuHandler>();
            mockListsStorage = new Mock<IListsStorage>();

            displayWardCommand = new DisplayWardCommand(
                mockMenuHandler.Object,
                mockListsStorage.Object);
        }

        [Fact]
        public void Exectue_WhenWardsListEmpty_ShouldReturnEarly()
        {
            SetUpMocks();

            mockListsStorage.Setup(x => x.Wards)
                .Returns([]);

            displayWardCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(UiMessages.DisplayWardMessages.NoWardPrompt), Times.Once());
            mockMenuHandler.Verify(x => x.DisplayList(It.IsAny<List<Ward>>()), Times.Never());
        }

        [Fact]
        public void Execute_WhenWardsListNotEmpty_ShouldDisplayPatientsList()
        {
            SetUpMocks();

            mockListsStorage.Setup(x => x.Wards)
                .Returns([It.IsAny<Ward>()]);

            displayWardCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(UiMessages.DisplayWardMessages.NoWardPrompt), Times.Never());
            mockMenuHandler.Verify(x => x.DisplayList(It.IsAny<List<Ward>>()), Times.Once());
        }
    }
}