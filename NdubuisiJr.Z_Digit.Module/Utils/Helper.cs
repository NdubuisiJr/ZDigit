using Microsoft.Practices.ServiceLocation;
using NdubuisiJr.Z_Digit.Infrastructure.Service;
using System.Collections.Generic;
using System.Windows.Media;

namespace NdubuisiJr.Z_Digit.Module.Utils {
    public class Helper {
        public static T GetActiveViewModel<T>() where T : class {
            return WindowService.GetActiveWindow()?.DataContext as T;
        }
        internal static IEnumerable<Brush> GetColours() {
            return new List<Brush>() { Brushes.Black, Brushes.Blue,Brushes.BlueViolet,Brushes.Brown,Brushes.BurlyWood,Brushes.CadetBlue,
                Brushes.Chartreuse,Brushes.DarkGray,Brushes.DarkOrange,Brushes.Gold,Brushes.DeepSkyBlue,Brushes.IndianRed,Brushes.Orange,Brushes.Green,
                Brushes.Pink,Brushes.Red,Brushes.Yellow,Brushes.PeachPuff,Brushes.Yellow,Brushes.Khaki,Brushes.Salmon,Brushes.MintCream
            };
        }
        static IWindowService WindowService { get { return ServiceLocator.Current.GetInstance<IWindowService>(); } }
    }
}
