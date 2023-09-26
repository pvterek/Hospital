using FluentNHibernate.Mapping;

namespace Hospital.PeopleCategories.NurseClass
{
    /// <summary>
    /// Provides the mapping configuration for the <see cref="Nurse"/> class.
    /// </summary>
    internal class NurseMap : ClassMap<Nurse>
    {
        public NurseMap()
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
        }
    }
}