using Microsoft.Practices.ServiceLocation;
using NdubuisiJr.Z_Digit.Domain;
using NdubuisiJr.Z_Digit.Infrastructure;
using NdubuisiJr.Z_Digit.Infrastructure.Event;
using NdubuisiJr.Z_Digit.Infrastructure.Save;
using NdubuisiJr.Z_Digit.Infrastructure.Service;
using NdubuisiJr.Z_Digit.Module.Utils;
using NdubuisiJr.Z_Digit.Module.View;
using NdubuisiJr.Z_Digit.Resources.CustomControls;
using Prism.Commands;
using System;
using System.Collections.Generic;

namespace NdubuisiJr.Z_Digit.Module.ViewModel
{
    public class PseudoCriticalViewModel: ViewModelBase,ISaver,INewable,IPlotable
    {
        public PseudoCriticalViewModel()
        {
            ReadCommand = new DelegateCommand(ReadAction);
            ClearContent();
            _calculator = new Calculators();
            _workingchart = new WorkingChart();
            EventAggregator.GetEvent<SelectedEntryChangedEvent>().Subscribe(ChangeEntry);
        }

        private void ChangeEntry(Entity entry)
        {
            var oldEntry = entry as CriticalZfactorEntry;
            if(oldEntry==null) {
                return;
            }
            var newEntry = new CriticalZfactorEntry {
                Temperature = oldEntry.Temperature,
                Pressure = oldEntry.Pressure,
                CriticalPressure = oldEntry.CriticalPressure,
                CriticalTemperature = oldEntry.CriticalTemperature,
                Zfactor = oldEntry.Zfactor
            };

            CriticalEntry = newEntry;
            var temp = newEntry.Temperature / newEntry.CriticalTemperature;
            _workingchart.ZfactorChart = _calculator.GetCurveFromTemperature(temp);

        }

        public void Save()
        {
            CriticalEntry.SavedTime = DateTime.Now;
            CriticalZfactorService.Save(CriticalEntry);
            ClearContent();
        }

        public void PlotResult() {
            ReadAction();
            var zfactorChart = _workingchart.ZfactorChart;
            if (zfactorChart == null)
            {
                return;
            }
            var plotView = WindowService.Launch<PlotView>();
            var viewModel = plotView.DataContext as PlotViewModel;
            viewModel.Plot(_workingchart,_calculator.GetAllCurves());
        }

        public void ClearContent()
        {
            CriticalEntry = new CriticalZfactorEntry();
        }

        public IEnumerable<Entity> LoadComboBox()
        {
            return CriticalZfactorService.GetEntries();
        }

        private void ReadAction() {
            try {
                var temp = CriticalEntry.Temperature / CriticalEntry.CriticalTemperature;
                var pre = CriticalEntry.Pressure / CriticalEntry.CriticalPressure;
                _workingchart = _calculator.ZfactorCritical(temp, pre);
                CriticalEntry.Zfactor = _workingchart.Zfactor;
                CriticalEntry = CriticalEntry;
            }
            catch (Exception ex) {
                AlertBox.ShowMessage(ex.Message);
            }
        }

        private CriticalZfactorEntry _criticalEntry;
        public CriticalZfactorEntry CriticalEntry
        {
            get { return _criticalEntry; }
            set {
                _criticalEntry = value;
                RaisePropertyChanged();
            }
        }
        public DelegateCommand ReadCommand { get; set; }
        CriticalZfactorService CriticalZfactorService {
            get {
                return ServiceLocator.Current.GetInstance<CriticalZfactorService>();
            }
        }
        WorkingChart _workingchart;
        Calculators _calculator;
    }
}
