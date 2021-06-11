using FluentNHibernate.Mapping;
using NdubuisiJr.Z_Digit.Domain;

namespace NdubuisiJr.Z_Digit.Data.Maps
{
    public class ReducedZfactorEntryMap : ClassMap<ReducedZfactorEntry>
    {
        public ReducedZfactorEntryMap()
        {
            Table(nameof(ReducedZfactorEntry));
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.ReducedTemperature);
            Map(x => x.ReducedPressure);
            Map(x => x.Zfactor);
            Map(x => x.SavedTime);
        }
    }
}
