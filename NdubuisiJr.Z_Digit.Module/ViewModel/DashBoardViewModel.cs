using NdubuisiJr.Z_Digit.Infrastructure;
using NdubuisiJr.Z_Digit.Module.View;
using Prism.Commands;
using NdubuisiJr.Z_Digit.Module.Utils;

namespace NdubuisiJr.Z_Digit.Module.ViewModel {
    public class DashBoardViewModel : ViewModelBase
    {
        public DashBoardViewModel()
        {
            CriticalCommand = new DelegateCommand(CriticalAction);
            ReducedCommand = new DelegateCommand(ReducedAction);
        }

        private void CriticalAction()
        {
            WindowService.Launch<PseudoCriticalView>();
        }

        private void ReducedAction()
        {
            WindowService.Launch<PseudoReducedView>();
        }
        public DelegateCommand CriticalCommand { get; set; }
        public DelegateCommand ReducedCommand { get; set; }
    }
}
