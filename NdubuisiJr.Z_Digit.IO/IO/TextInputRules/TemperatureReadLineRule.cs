using NdubuisiJr.Z_Digit.Data.IO.Reader;

namespace NdubuisiJr.Z_Digit.Data.IO.TextInputRules
{
    public class TemperatureReadLineRule : IReadLineRule {

        public TemperatureReadLineRule(ITextFileReader readFile) {
            _readFile = readFile;
        }

        public void GetChartValue(string line) {
            _readFile.chart.PseudoReducedTemperature = double.Parse(line);
        }

        public bool IsMatched(string line) {
            return line.IndexOf(",") == -1;
        }

        private ITextFileReader _readFile;
    }
}
