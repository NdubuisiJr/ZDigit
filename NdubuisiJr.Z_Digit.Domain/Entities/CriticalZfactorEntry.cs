using System;

namespace NdubuisiJr.Z_Digit.Domain
{
    public class CriticalZfactorEntry : Entity
    {
        public virtual double Temperature { get; set; }
        public virtual double Pressure { get; set; }
        public virtual double CriticalTemperature { get; set; }
        public virtual double CriticalPressure { get; set; }
        public virtual double  Zfactor { get; set; }
        public virtual DateTime SavedTime { get; set; }
        public override string ToString()
        {
            return $"{Zfactor}-{SavedTime.Day}/{SavedTime.Month}/{SavedTime.Year}";
        }
    }
}
