using NdubuisiJr.Z_Digit.Infrastructure;
using Prism.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace NdubuisiJr.Z_Digit.SettingsModule.ViewModels {
    class ChartDialogViewModel : ViewModelBase {
        public ChartDialogViewModel() {
            Charts = new List<string> { "zDigit.txt", "zDigit.csv", "zDigit1.txt", "zDigit2.txt" };
            ActivateCommand = new DelegateCommand(ActivateAction, ActivatePredicate);
            CancelCommand = new DelegateCommand(CancelAction);
        }

        private void CancelAction() {
            WindowService.CloseDialog();
            _isCancelPressed = true;
        }

        private void ActivateAction() {
            TrackProgress();
        }

        private bool ActivatePredicate() {
            return !string.IsNullOrWhiteSpace(SelectedChart);
        }

        private void UpdateChart() {
        }

        private void TrackProgress() {
            var work = new BackgroundWorker();
            work.ProgressChanged += Work_ProgressChanged;
            work.DoWork += Work_DoWork;
            work.RunWorkerCompleted += Work_RunWorkerCompleted;
            work.WorkerReportsProgress = true;
            work.RunWorkerAsync();
        }

        private void Work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (_isCancelPressed) {
                _isCancelPressed = false;
                return;
            }
            UpdateChart();
            WindowService.CloseDialog();
            WindowService.MessageBox("Chart Activated", "Alert");
        }

        private void Work_DoWork(object sender, DoWorkEventArgs e) {
            var work = sender as BackgroundWorker;
            for (int i = 0; i < 12; i++) {
                Thread.Sleep(1000);
                work.ReportProgress(i * 10, $"Activation is {i * 10}% Complete");
            }
        }

        private void Work_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            ProgressValue = e.ProgressPercentage;
            ProgressMessage = e.UserState as string;
        }

        public IEnumerable<string> Charts { get; set; }

        private string _selectedChart;
        public string SelectedChart {
            get { return _selectedChart; }
            set {
                SetProperty(ref _selectedChart, value);
                ActivateCommand.RaiseCanExecuteChanged();
            }
        }

        public string _progressMessage;
        public string ProgressMessage {
            get { return _progressMessage; }
            set { SetProperty(ref _progressMessage, value); }
        }

        private double _progressValue;
        public double ProgressValue {
            get { return _progressValue; }
            set { SetProperty(ref _progressValue, value); }
        }
        private bool _isCancelPressed;
        public DelegateCommand ActivateCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
    }
}
