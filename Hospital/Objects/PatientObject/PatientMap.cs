using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Hospital.Objects.PatientObject
{
    /// <summary>
    /// Provides the mapping configuration for the <see cref="Patient"/> class.
    /// </summary>
    internal class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.Gender);
            Map(x => x.Birthday);
            Map(x => x.Pesel).Not.Nullable().Unique();
            Map(x => x.IntroduceString);
            Map(x => x.HealthStatus).CustomType<Health>().Nullable();

            References(x => x.AssignedWard);

            References(x => x.AssignedDoctor);
        }
    }
}