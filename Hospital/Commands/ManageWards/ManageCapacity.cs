﻿using Hospital.Commands.ManagePatients;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;

namespace Hospital.Commands.ManageWards
{
    internal class ManageCapacity : IManageCapacity
    {
        private readonly IListManage _listManage;
        private readonly IListsStorage _listsStorage;

        public ManageCapacity(IListManage listManage, IListsStorage listStorage)
        {
            _listManage = listManage;
            _listsStorage = listStorage;
        }

        public void UpdateWardCapacity(Ward ward, Patient patient, OperationType.Operation operation)
        {
            switch (operation)
            {
                case OperationType.Operation.AddPatient:
                    ward.AssignedPatients.Add(patient);
                    break;
                case OperationType.Operation.RemovePatient:
                    ward.AssignedPatients.Remove(patient);
                    break;
            }

            ward.IntroduceString = string.Format(UiMessages.WardObjectMessages.Introduce, ward.Name, ward.PatientsNumber, ward.Capacity);
            _listManage.Update(ward, _listsStorage.Wards);
        }
    }
}