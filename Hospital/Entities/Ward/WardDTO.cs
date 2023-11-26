﻿using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.PersonClass;

namespace Hospital.PeopleCategories.WardClass
{
    public class WardDTO
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public IList<Patient> AssignedPatients { get; set; }
        public IList<Person> AssignedEmployees { get; set; }
    }
}