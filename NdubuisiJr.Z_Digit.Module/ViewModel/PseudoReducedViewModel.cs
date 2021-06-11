using Microsoft.Practices.ServiceLocation;
using NdubuisiJr.Z_Digit.Domain;
using NdubuisiJr.Z_Digit.Infrastructure;
using NdubuisiJr.Z_Digit.Infrastructure.Event;
using NdubuisiJr.Z_Digit.Infrastructure.Save;
using NdubuisiJr.Z_Digit.Infrastructure.Service;
using NdubuisiJr.Z_Digit.Resources.CustomControls;
using Prism.Commands;
using System;
using System.Collections.Generic;
using NdubuisiJr.Z_Digit.Module.Utils;
using NdubuisiJr.Z_Digit.Module.View;

namespace NdubuisiJr.Z_Digit.Module.ViewModel
{
    public class PseudoReducedViewModel : ViewModelBase,ISaver,INewable,IPlotable
    {
        public PseudoReducedViewModel()
        {
            ClearContent();
            _calculator = new Calculators();
            ReadCommand = new DelegateCommand(ReadAction);
            _workingChart=new WorkingChart();
            EventAggregator.GetEvent<SelectedEntryChangedEvent>().Subscribe(ChangeEntry);
        }

        private void ChangeEntry(Entity entry)
        {
            var oldEntry = entry as ReducedZfactorEntry;
            if(oldEntry==null) {
                return;
            }
            var newEntry = new ReducedZfactorEntry {
                ReducedTemperature = oldEntry.ReducedTemperature,
                ReducedPressure = oldEntry.ReducedPressure,
                Zfactor = oldEntry.Zfactor
            };

            ReducedEntry = newEntry;
            _workingChart.ZfactorChart = _calculator.GetCurveFromTemperature(newEntry.ReducedTemperature);
            
        }

        public void Save()
        {
            ReducedEntry.SavedTime = DateTime.Now;
            ReducedZFactorService.Save(ReducedEntry);
            ClearContent();
        }

        public void ClearContent()
        {
            ReducedEntry = new ReducedZfactorEntry();
        }

        public IEnumerable<Entity> LoadComboBox()
        {
            return ReducedZFactorService.GetEntries();
        }

        public void PlotResult() {
            ReadAction();
            var zfactorChart = _workingChart.ZfactorChart;
            if (zfactorChart==null)
            {
                return;
            }
            var plotView = WindowService.Launch<PlotView>();
            var viewModel = plotView.DataContext as PlotViewModel;
            viewModel.Plot(_workingChart, _calculator.GetAllCurves());
        }

        private void ReadAction() {
            try {
                var temp = ReducedEntry.ReducedTemperature;
                var pres = ReducedEntry.ReducedPressure;
                _workingChart = _calculator.ZfactorReduced(temp, pres);
                ReducedEntry.Zfactor = _workingChart.Zfactor;
                ReducedEntry = ReducedEntry;
            }
            catch (Exception ex) {
                AlertBox.ShowMessage(ex.Message);
            }
        }

        private ReducedZfactorEntry _reducedEntry;
        public ReducedZfactorEntry ReducedEntry {
            get { return _reducedEntry; }
            set {
                _reducedEntry = value;
                RaisePropertyChanged();
            }
        }     
        public DelegateCommand ReadCommand { get; set; }
        ReducedZFactorService ReducedZFactorService {
            get {
                return ServiceLocator.Current.GetInstance<ReducedZFactorService>();
            }
        }
        WorkingChart _workingChart;
        Calculators _calculator;
    }
}
