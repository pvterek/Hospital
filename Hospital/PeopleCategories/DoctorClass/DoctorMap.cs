using FluentNHibernate.Mapping;

namespace Hospital.PeopleCategories.DoctorClass
{
    /// <summary>
    /// Provides the mapping configuration for the <see cref="Doctor"/> class.
    /// </summary>
    internal class DoctorMap : ClassMap<Doctor>
    {
        public DoctorMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.Gender);
            Map(x => x.Birthday);
            Map(x => x.IntroduceString);
    
            References(x => x.AssignedWard)
                .Column("WardId")
                .Not.Nullable();

            HasMany(x => x.Patients)
                .Inverse();
        }
    }
}