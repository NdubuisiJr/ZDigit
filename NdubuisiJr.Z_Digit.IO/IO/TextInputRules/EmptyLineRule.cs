using System.Collections.Generic;
using NdubuisiJr.Z_Digit.Domain;
using NdubuisiJr.Z_Digit.Data.IO.Reader;

namespace NdubuisiJr.Z_Digit.Data.IO.TextInputRules {
    public class EmptyLineRule : IReadLineRule {

        public EmptyLineRule(ITextFileReader readFile) {
            _readFile = readFile;
        }

        public void GetChartValue(string line) {
            _readFile.Charts.Add(_readFile.chart);
            _readFile.chart = new ZFactorChart();
        }

        public bool IsMatched(string line) {
            return string.IsNullOrWhiteSpace(line);
        }

        private ITextFileReader _readFile;
    }
}
