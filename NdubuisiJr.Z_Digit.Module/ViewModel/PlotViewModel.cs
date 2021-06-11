using NdubuisiJr.Z_Digit.Domain;
using System.Collections.Generic;
using ChartLibrary;
using System.Windows.Media;
using NdubuisiJr.Z_Digit.Module.Utils;
using System.Linq;

namespace NdubuisiJr.Z_Digit.Module.ViewModel {
    public class PlotViewModel {
        internal PlotViewModel(ChartCanvas chartCanvas) {
            _chartCanvas = chartCanvas;
        }

        internal Chart Plot(IEnumerable<ZFactorChart> charts) {
            var series = new List<LineChart>();
            var colorCount = 0;
            var colors = Helper.GetColours();
            foreach (var chart in charts) {
                var curve = new LineChart(chart.PseudoReducedPressures, chart.ZFactors);
                curve.ChartColour = colors.ElementAt(colorCount++);
                curve.Title = chart.PseudoReducedTemperature.ToString();
                series.Add(curve);
            }
            var Chart = new Chart(_chartCanvas, series);
            Chart.CanShowLegend = true; 
            Chart.PlotChart();
            Chart.Ymin = 0.2;
            Chart.Ymax = 1.9;
            Chart.XLabel = "Pseudo Reduced Pressure";
            Chart.YLabel = "Z-Factor";
            Chart.Title = "Standing And Katz Compressibility Factor Chart";
            return Chart;
        }

        internal void Plot(WorkingChart workingChart, IEnumerable<ZFactorChart> zFactorCharts) {
            var chart = Plot(zFactorCharts);
            var line = new LineChart(workingChart.ZfactorChart.PseudoReducedPressures, workingChart.ZfactorChart.ZFactors);
            chart.ShowInterSection(line, workingChart.Pressure, workingChart.Zfactor,$"{workingChart.Zfactor}");
        }

        private ChartCanvas _chartCanvas;
    }
}
