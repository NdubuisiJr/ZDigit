using System.Collections.Generic;

namespace NdubuisiJr.Z_Digit.Domain
{
    public class ZFactorChart
    {
        public ZFactorChart()
        {
            ZFactors = new List<double>();
            PseudoReducedPressures = new List<double>();
        }
        public double PseudoReducedTemperature { get; set; }

        public List<double> PseudoReducedPressures { get; set; }

        public List<double> ZFactors { get; set; }
    }
}
