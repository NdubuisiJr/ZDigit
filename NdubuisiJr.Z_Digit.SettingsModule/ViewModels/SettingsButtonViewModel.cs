using NdubuisiJr.Z_Digit.Infrastructure;
using NdubuisiJr.Z_Digit.SettingsModule.Views;

namespace NdubuisiJr.Z_Digit.SettingsModule.ViewModels {
    public class SettingsButtonViewModel : ViewModelBase {

        internal void SettingsAction() {
            var chartDialog = WindowService.LaunchDialog<ChartDialog>();
        }
    }
}
