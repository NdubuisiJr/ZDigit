using Microsoft.Practices.ServiceLocation;
using NdubuisiJr.Z_Digit.Infrastructure.Service;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace NdubuisiJr.Z_Digit.Infrastructure {
    public class ViewModelBase : BindableBase
    {
        public IRegionManager RegionManager { get { return ServiceLocator.Current.GetInstance<IRegionManager>(); } }

        public IEventAggregator EventAggregator { get { return ServiceLocator.Current.GetInstance<IEventAggregator>(); } }

        public IWindowService WindowService { get { return ServiceLocator.Current.GetInstance<IWindowService>(); } }
    }
}
