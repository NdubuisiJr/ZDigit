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
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();
            DataContext = new DashBoardViewModel();
            initialTransform = stackDash.RenderTransform;
            AddVerticals();
            
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e) {
            stackDash.Children.Clear();
            if (isHorizontal) {
                AddVerticals();
            }
            else {
                AddHorizontals();
            }
            
        }

        private void AddVerticals() {
            var rotateTransform = new RotateTransform(90);
            var translateTransform = new TranslateTransform(130, -70);
            var transformGroup = new TransformGroup();
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(translateTransform);
            stackDash.RenderTransform = transformGroup;
            for (int i = 0; i < 200; i++) {
                stackDash.Children.Add(new Rectangle() { Width = 40, Height = 3, Fill = Brushes.Blue, Stroke = Brushes.Black });
            }
            button1.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            isHorizontal = false;
        }

        void AddHorizontals() {
            for (int i = 0; i < 13; i++) {
                stackDash.Children.Add(new Rectangle() { Height = 3, Width = 100, Fill = Brushes.Blue, Stroke = Brushes.Black });
            }
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            isHorizontal = true;
            if (initialTransform!=null) {
                stackDash.RenderTransform = initialTransform;
            }
        }
        bool isHorizontal;
        Transform initialTransform;
    }
}
