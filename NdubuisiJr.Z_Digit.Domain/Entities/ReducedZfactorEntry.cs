using System;

namespace NdubuisiJr.Z_Digit.Domain
{
    public class ReducedZfactorEntry : Entity
    {
        public virtual double ReducedTemperature { get; set; }
        public virtual double ReducedPressure { get; set; }
        public virtual double Zfactor { get; set; }
        public virtual DateTime SavedTime { get; set; }
        public override string ToString()
        {
            return $"{Zfactor}-{SavedTime.Day}/{SavedTime.Month}/{SavedTime.Year}";
        }
    }
}
