using Hospital.Commands.ManagePatients;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.WardClass;

namespace Hospital.Commands.ManageWards
{
    public interface IManageCapacity
    {
        void UpdateWardCapacity(Ward ward, Patient patient, OperationType.Operation operation);
    }
}