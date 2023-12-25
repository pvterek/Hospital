using Hospital.Commands.ManagePatients;
using Hospital.Commands.ManageWards;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
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

            var mockPatient = new Mock<Patient>();
            var mockWard = new Mock<Ward>().SetupAllProperties();
            mockWard.Setup(x => x.AssignedPatients)
                    .Returns([]);
            mockWard.Setup(x => x.Capacity)
                    .Returns(2);

            var excpetedPatientsNumber = 1;
            var expectedIntroduceString = string.Format(UiMessages.WardObjectMessages.Introduce,
                mockWard.Object.Name, excpetedPatientsNumber, mockWard.Object.Capacity);

            mockListsStorage.Setup(x => x.Wards)
                .Returns([mockWard.Object]);

            manageCapacity.UpdateWardCapacity(mockWard.Object, mockPatient.Object, Operation.CreatePatient);

            Assert.Contains(mockPatient.Object, mockWard.Object.AssignedPatients);
            Assert.True(mockWard.Object.PatientsNumber == excpetedPatientsNumber);
            Assert.True(mockWard.Object.IntroduceString == expectedIntroduceString);
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

            var excpetedPatientsNumber = 0;
            var expectedIntroduceString = string.Format(UiMessages.WardObjectMessages.Introduce,
                mockWard.Object.Name, excpetedPatientsNumber, mockWard.Object.Capacity);

            manageCapacity.UpdateWardCapacity(mockWard.Object, mockPatient.Object, Operation.DeletePatient);

            Assert.DoesNotContain(mockPatient.Object, mockWard.Object.AssignedPatients);
            Assert.True(mockWard.Object.PatientsNumber == excpetedPatientsNumber);
            Assert.True(mockWard.Object.IntroduceString == expectedIntroduceString);
        }
    }
}