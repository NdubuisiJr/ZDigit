using Microsoft.Practices.ServiceLocation;
using NdubuisiJr.Z_Digit.SettingsModule.Views;
using Prism.Modularity;
using Prism.Regions;
using static NdubuisiJr.Z_Digit.Infrastructure.RegionNames;

namespace NdubuisiJr.Z_Digit.SettingsModule {
    public class SettingsModule : IModule {
        public void Initialize() {
            RegionManager.RegisterViewWithRegion(SettingRegion, typeof(SettingsButton));
        }
        IRegionManager RegionManager { get { return ServiceLocator.Current.GetInstance<IRegionManager>(); } }
    }
}
