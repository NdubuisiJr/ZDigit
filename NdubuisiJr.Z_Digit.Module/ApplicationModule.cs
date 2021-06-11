using Microsoft.Practices.ServiceLocation;
using NdubuisiJr.Z_Digit.Module.View;
using Prism.Modularity;
using Prism.Regions;
using static NdubuisiJr.Z_Digit.Infrastructure.RegionNames;
namespace NdubuisiJr.Z_Digit.Module
{
    public class ApplicationModule : IModule
    {
        public void Initialize()
        {
            RegionManager.RegisterViewWithRegion(DashBoardRegion, typeof(DashBoard));
            RegionManager.RegisterViewWithRegion(DataRegion, typeof(Home));
            RegionManager.RegisterViewWithRegion(VisualizeRegion, typeof(Visualize));
            
        }

        IRegionManager RegionManager { get { return ServiceLocator.Current.GetInstance<IRegionManager>(); } }
    }
}
