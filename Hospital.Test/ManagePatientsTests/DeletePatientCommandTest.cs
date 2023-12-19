using Hospital.Commands.ManagePatients.ManagePatient;
using Hospital.Commands.ManageWards;
using Hospital.Database.Interfaces;
using Hospital.PeopleCategories.PatientClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;
using Moq;
using NHibernate;

namespace Hospital.Test.ManagePatientsTests
{
    public class DeletePatientCommandTest
    {
        private Mock<IMenuHandler> mockMenuHandler;
        private Mock<IListManage> mockListManage;
        private Mock<IListsStorage> mockListsStorage;
        private Mock<IManageCapacity> mockManageCapacity;
        private Mock<IDatabaseOperations> mockDatabaseOperations;

        private DeletePatientCommand deletePatientCommand;

        private void SetUpMocks()
        {
            mockMenuHandler = new Mock<IMenuHandler>();
            mockListManage = new Mock<IListManage>();
            mockListsStorage = new Mock<IListsStorage>();
            mockManageCapacity = new Mock<IManageCapacity>();
            mockDatabaseOperations = new Mock<IDatabaseOperations>();

            deletePatientCommand = new DeletePatientCommand(
                mockMenuHandler.Object,
                mockListManage.Object,
                mockListsStorage.Object,
                mockManageCapacity.Object);
        }

        [Fact]
        public void Execute_WhenPatientsListEmpty_ShouldReturnEarly()
        {
            SetUpMocks();

            mockListsStorage.Setup(x => x.Patients)
                .Returns([]);

            deletePatientCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(UiMessages.DisplayPatientsMessages.NoPatientsPrompt), Times.Once());
            mockMenuHandler.Verify(x => x.SelectObject(It.IsAny<List<Patient>>(), UiMessages.DeletePatientMessages.DeletePrompt), Times.Never());
        }

        [Fact]
        public void Execute_WhenPatientsListNotEmpty_ShouldRemovePatient()
        {
            SetUpMocks();

            var mockPatient = new Mock<Patient>();
            var patientsList = new List<Patient>() { mockPatient.Object };

            mockListsStorage.Setup(x => x.Patients)
                .Returns(patientsList);
            mockMenuHandler.Setup(x => x.SelectObject(mockListsStorage.Object.Patients, UiMessages.DeletePatientMessages.DeletePrompt))
                .Returns(mockPatient.Object);

            mockDatabaseOperations.Setup(x => x.Delete(It.IsAny<Patient>(), It.IsAny<ISession>()))
                .Returns(true);
            mockListManage.Setup(x => x.Remove(It.IsAny<Patient>(), It.IsAny<List<Patient>>()))
                .Callback((Patient item, List<Patient> list) =>
                {
                    if (mockDatabaseOperations.Object.Delete(item, new Mock<ISession>().Object))
                    {
                        list.Remove(item);
                    }
                });

            deletePatientCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(string.Format(UiMessages.DeletePatientMessages.OperationSuccessPrompt, mockPatient.Object.Name, mockPatient.Object.Surname)), Times.Once());
            Assert.DoesNotContain(mockPatient.Object, patientsList);
        }
    }
}