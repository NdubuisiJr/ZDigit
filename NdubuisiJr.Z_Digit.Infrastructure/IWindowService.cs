using System.Windows;
using System.Windows.Controls;

namespace NdubuisiJr.Z_Digit.Infrastructure.Service {
    public interface IWindowService
    {
        T Launch<T>() where T : ContentControl;

        T LaunchDialog<T>() where T : Window;

        void MessageBox(string message, string caption);

        void CloseDialog();

        ContentControl GetActiveWindow();
    }
}
