using FluentNHibernate.Mapping;
using NdubuisiJr.Z_Digit.Domain;

namespace NdubuisiJr.Z_Digit.Data.Maps
{
    public class CriticalZFactorEntryMap : ClassMap<CriticalZfactorEntry>
    {
        public CriticalZFactorEntryMap()
        {
            Table(nameof(CriticalZfactorEntry));
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Temperature);
            Map(x => x.Pressure);
            Map(x => x.CriticalTemperature);
            Map(x => x.CriticalPressure);
            Map(x => x.Zfactor);
            Map(x => x.SavedTime);
        }
    }
}
