using System.Collections.Generic;
using NdubuisiJr.Z_Digit.Domain;
using NdubuisiJr.Z_Digit.Data.IO.Reader;

namespace NdubuisiJr.Z_Digit.Data.IO.TextInputRules
{
    public class ZFactorPressureRule : IReadLineRule {
        public ZFactorPressureRule(ITextFileReader readFile) {
            _readFile = readFile;
        }

        public void GetChartValue(string line) {
            var values = line.Split(',');
            _readFile.chart.PseudoReducedPressures.Add(double.Parse(values[0]));
            _readFile.chart.ZFactors.Add(double.Parse(values[1]));
        }

        public bool IsMatched(string line) {
            return line.IndexOf(",") != -1;
        }

        private ITextFileReader _readFile;
    }
}
