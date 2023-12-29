using Hospital.Commands.ManageWards;
using Hospital.Entities.Employee;
using Hospital.PeopleCategories.PatientClass;
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
            //Arrange
            SetUpMocks();

            mockListsStorage.Setup(x => x.Wards)
                            .Returns([]);

            //Act
            displayWardCommand.Execute();

            //Assert
            mockMenuHandler.Verify(x => x.ShowMessage(UiMessages.DisplayWardMessages.NoWardPrompt), Times.Once());
            mockMenuHandler.Verify(x => x.DisplayList(It.IsAny<List<Ward>>()), Times.Never());
        }

        [Fact]
        public void Execute_WhenWardsListNotEmpty_ShouldDisplayPatientsList()
        {
            //Arrange
            SetUpMocks();

            var ward = new Ward(
                "ward",
                10,
                new List<Patient>(),
                new List<Employee>());
            var expectedString = string.Format(
                UiMessages.DisplayWardMessages.DisplayInformationsPrompt,
                ward.Name,
                ward.PatientsNumber,
                ward.Capacity,
                ward.PatientsNumber / ward.Capacity,
                ward.AssignedEmployees.Count);

            mockListsStorage.Setup(x => x.Wards)
                            .Returns([It.IsAny<Ward>()]);

            mockMenuHandler.Setup(x => x.SelectObject(It.IsAny<List<Ward>>(), It.IsAny<string>()))
                           .Returns(ward);

            //Act
            displayWardCommand.Execute();

            //Assert
            mockMenuHandler.Verify(x => x.ShowMessage(UiMessages.DisplayWardMessages.NoWardPrompt), Times.Never());
            mockMenuHandler.Verify(x => x.ShowMessage(expectedString), Times.Once());
        }
    }
}