using System;
using NdubuisiJr.Z_Digit.Infrastructure;
using NdubuisiJr.Z_Digit.Module.Utils;
using NdubuisiJr.Z_Digit.Module.View;
using Prism.Commands;
using static NdubuisiJr.Z_Digit.Module.Utils.Helper;
using NdubuisiJr.Z_Digit.Infrastructure.Event;

namespace NdubuisiJr.Z_Digit.Module.ViewModel {
    public class VisualizeViewModel:ViewModelBase {
        public VisualizeViewModel() {
            PlotCommand = new DelegateCommand(PlotAction,PlotPredicate);
            ShowChartCommand = new DelegateCommand(ShowChartAction);
            EventAggregator.GetEvent<ViewChangedEvent>().Subscribe(() => PlotCommand.RaiseCanExecuteChanged());
        }

        private bool PlotPredicate() {

            return GetActiveViewModel<IPlotable>() != null ? true : false;
        }

        private void PlotAction() {
            GetActiveViewModel<IPlotable>().PlotResult();
        }
        private void ShowChartAction() {
            var calculator = new Calculators();
            var viewModel = WindowService.Launch<PlotView>().DataContext as PlotViewModel;
            viewModel.Plot(calculator.GetAllCurves());
        }
        public DelegateCommand PlotCommand { get; }
        public DelegateCommand ShowChartCommand { get; set; }
    }
}
