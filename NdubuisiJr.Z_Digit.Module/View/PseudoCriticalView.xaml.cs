using NdubuisiJr.Z_Digit.Module.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NdubuisiJr.Z_Digit.Module.View
{
    /// <summary>
    /// Interaction logic for PseudoCriticalView.xaml
    /// </summary>
    public partial class PseudoCriticalView : UserControl
    {
        public PseudoCriticalView()
        {
            InitializeComponent();
            DataContext = new PseudoCriticalViewModel();
        }
    }
}
