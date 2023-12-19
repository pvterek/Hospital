using Hospital.Commands.ManageWards;
using Hospital.Database.Interfaces;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;
using Moq;
using NHibernate;

namespace Hospital.Test.ManageWardsTests
{
    public class DeleteWardCommandTest
    {
        private Mock<IMenuHandler> mockMenuHandler;
        private Mock<IListManage> mockListManage;
        private Mock<IListsStorage> mockListsStorage;
        private Mock<IDatabaseOperations> mockDatabaseOperations;

        private DeleteWardCommand deleteWardCommand;

        private void SetUpMocks()
        {
            mockMenuHandler = new Mock<IMenuHandler>();
            mockListManage = new Mock<IListManage>();
            mockListsStorage = new Mock<IListsStorage>();
            mockDatabaseOperations = new Mock<IDatabaseOperations>();

            deleteWardCommand = new DeleteWardCommand(
                mockMenuHandler.Object,
                mockListManage.Object,
                mockListsStorage.Object);
        }

        [Fact]
        public void Execute_WhenWardsListEmpty_ShouldReturnEarly()
        {
            SetUpMocks();

            mockListsStorage.Setup(x => x.Wards)
                .Returns([]);

            deleteWardCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(UiMessages.DeleteWardMessages.NoWardPrompt), Times.Once());
            mockMenuHandler.Verify(x => x.SelectObject(mockListsStorage.Object.Wards, UiMessages.DeleteWardMessages.SelectWardPrompt), Times.Never());
        }

        [Fact]
        public void Execute_WhenAssignedPatientOrEmployeeToWard_ShouldReturnEarly()
        {
            SetUpMocks();

            var mockWard = new Mock<Ward>();
            var mockPatient = new Mock<Patient>();
            var assignedPatientsList = new List<Patient>() { mockPatient.Object };
            mockWard.Setup(x => x.AssignedPatients)
                .Returns(assignedPatientsList);

            mockListsStorage.Setup(x => x.Wards)
                .Returns([mockWard.Object]);

            mockMenuHandler.Setup(x => x.SelectObject(mockListsStorage.Object.Wards, UiMessages.DeleteWardMessages.SelectWardPrompt))
                .Returns(mockWard.Object);

            deleteWardCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(UiMessages.DeleteWardMessages.WardNonEmptyPrompt), Times.Once());
            mockListManage.Verify(x => x.Remove(mockWard.Object, mockListsStorage.Object.Wards), Times.Never());
        }

        [Fact]
        public void Execute_WhenNotAssignedPatientOrEmployeeToWard_ShouldRemoveWard()
        {
            SetUpMocks();

            var mockWard = new Mock<Ward>();
            var wardsList = new List<Ward>() { mockWard.Object };

            mockWard.Setup(x => x.AssignedPatients)
                .Returns([]);
            mockWard.Setup(x => x.AssignedEmployees)
                .Returns([]);

            mockListsStorage.Setup(x => x.Wards)
                .Returns(wardsList);
            mockMenuHandler.Setup(x => x.SelectObject(mockListsStorage.Object.Wards, UiMessages.DeleteWardMessages.SelectWardPrompt))
                .Returns(mockWard.Object);

            mockDatabaseOperations.Setup(x => x.Delete(It.IsAny<Ward>(), It.IsAny<ISession>()))
                .Returns(true);
            mockListManage.Setup(x => x.Remove(It.IsAny<Ward>(), It.IsAny<List<Ward>>()))
                .Callback((Ward item, List<Ward> list) =>
                {
                    if (mockDatabaseOperations.Object.Delete(item, new Mock<ISession>().Object))
                    {
                        list.Remove(item);
                    }
                });

            deleteWardCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(string.Format(UiMessages.DeleteWardMessages.OperationSuccessPrompt, mockWard.Object.Name)), Times.Once());
            Assert.DoesNotContain(mockWard.Object, wardsList);
        }
    }
}