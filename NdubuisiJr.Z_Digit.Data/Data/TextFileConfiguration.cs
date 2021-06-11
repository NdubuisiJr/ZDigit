using System.Collections.Generic;
using NdubuisiJr.Z_Digit.Domain;
using System.IO;
using System.Linq;
using NdubuisiJr.Z_Digit.Infrastructure;
using System.Diagnostics;

namespace NdubuisiJr.Z_Digit.Data.Data {
    public class TextFileConfiguration : IDataService {
        public TextFileConfiguration(string path) {
            Data = Read(path);
        }
        private IEnumerable<ZFactorChart> Read(string filePath) {
            var zfCharts = new List<ZFactorChart>();
            var zfChart = new ZFactorChart();
            var rawFile = File.ReadAllLines(filePath);
            var lines = rawFile.Skip(1);
            foreach (var line in lines) {
                if (string.IsNullOrWhiteSpace(line)) {
                    zfCharts.Add(zfChart);
                    zfChart = new ZFactorChart();
                }
                else if (line.IndexOf(",") == -1) {
                    zfChart.PseudoReducedTemperature = double.Parse(line);
                    _pressureChecker = true;
                }
                else if (_pressureChecker) {
                    var rawPressure = line.Split(',').ToList();
                    rawPressure.ForEach(x => {
                        zfChart.PseudoReducedPressures.Add(double.Parse(x));
                    });
                    _pressureChecker = false;
                }
                else {
                    var rawZFactor = line.Split(',').ToList();
                    rawZFactor.ForEach(x => {
                        zfChart.ZFactors.Add(double.Parse(x));
                    });
                }
            }
            
            return zfCharts;
        }

        public IEnumerable<ZFactorChart> GetData() {
            return Data;
        }

        bool _pressureChecker=false;
        public IEnumerable<ZFactorChart> Data { get; }
    }
}
