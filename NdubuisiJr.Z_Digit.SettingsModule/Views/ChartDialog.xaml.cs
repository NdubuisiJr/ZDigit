using NdubuisiJr.Z_Digit.SettingsModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NdubuisiJr.Z_Digit.SettingsModule.Views {
    /// <summary>
    /// Interaction logic for ChartDialog.xaml
    /// </summary>
    public partial class ChartDialog : Window {
        public ChartDialog() {
            InitializeComponent();
            DataContext = new ChartDialogViewModel();
            Owner = Application.Current.MainWindow;
        }

        ChartDialogViewModel Vm { get { return DataContext as ChartDialogViewModel; } }
    }
}
