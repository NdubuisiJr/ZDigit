using System.Collections.Generic;
using NdubuisiJr.Z_Digit.Domain;
using NdubuisiJr.Z_Digit.Data.IO.TextInputRules;

namespace NdubuisiJr.Z_Digit.Data.IO.Reader
{
    public class TextFileReader : ITextFileReader {
        public TextFileReader() {

            _rules = new List<IReadLineRule> {
                new EmptyLineRule(this),
                new TemperatureReadLineRule(this),
                new ZFactorPressureRule(this)
            };

             Charts = new List<ZFactorChart>();
             chart = new ZFactorChart();
        }

        public void ReadLine(string line) {
            _rules.Find(x => x.IsMatched(line)).GetChartValue(line);
        }

        private List<ZFactorChart> _charts;
        public  List<ZFactorChart> Charts {
            get {
                 return _charts;
            }
            set {
                _charts = value;
            }
        }

        public  ZFactorChart chart { get; set; }

        private readonly List<IReadLineRule> _rules;
    }
}
