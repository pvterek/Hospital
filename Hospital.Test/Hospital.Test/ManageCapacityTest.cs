using Hospital.Commands.ManagePatients;
using Hospital.Commands.ManageWards;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.ListManagment;
using Moq;

namespace Hospital.Test
{
    public class ManageCapacityTest
    {
        private Mock<IListManage> mockListManage;
        private Mock<IListsStorage> mockListsStorage;

        private ManageCapacity manageCapacity;

        public void SetUpMocks()
        {
            mockListManage = new Mock<IListManage>();
            mockListsStorage = new Mock<IListsStorage>();

            manageCapacity = new ManageCapacity(
                mockListManage.Object,
                mockListsStorage.Object);
        }

        [Fact]
        public void UpdateWardCapacity_WhenAddingPatient_ShouldAddPatientAndUpdateWard()
        {
            SetUpMocks();

            var mockWard = new Mock<Ward>().SetupAllProperties();
            var mockPatient = new Mock<Patient>();
            mockWard.Setup(x => x.AssignedPatients)
                .Returns([]);

            mockListsStorage.Setup(x => x.Wards)
                .Returns([mockWard.Object]);

            manageCapacity.UpdateWardCapacity(mockWard.Object, mockPatient.Object, OperationType.Operation.AddPatient);

            Assert.Contains(mockPatient.Object, mockWard.Object.AssignedPatients);
            Assert.True(mockWard.Object.PatientsNumber == 1);
        }

        [Fact]
        public void UpdateWardCapacity_WhenRemovingPatient_ShouldRemovePatientAndUpdateWard()
        {
            SetUpMocks();

            var mockWard = new Mock<Ward>().SetupAllProperties();
            var mockPatient = new Mock<Patient>();
            mockWard.Object.PatientsNumber = 1;
            mockWard.Setup(x => x.AssignedPatients)
                .Returns([mockPatient.Object]);

            manageCapacity.UpdateWardCapacity(mockWard.Object, mockPatient.Object, OperationType.Operation.RemovePatient);

            Assert.DoesNotContain(mockPatient.Object, mockWard.Object.AssignedPatients);
            Assert.True(mockWard.Object.PatientsNumber == 0);
        }
    }
}