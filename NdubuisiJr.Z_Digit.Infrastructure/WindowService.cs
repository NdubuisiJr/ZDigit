using Microsoft.Practices.ServiceLocation;
using NdubuisiJr.Z_Digit.Infrastructure.Event;
using Prism.Events;
using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NdubuisiJr.Z_Digit.Infrastructure.Service
{
    public class WindowService :  IWindowService
    {

        public T Launch<T>() where T : ContentControl
        {
            var viewName = typeof(T).Name;

            var window = RegionManager.Regions[RegionNames.ContentRegion].GetView(viewName);
            if (window==null)
            {
                window = Activator.CreateInstance(typeof(T));
                ClearRegion();
                RegionManager.Regions[RegionNames.ContentRegion].Add(window, viewName)
                             .Regions[RegionNames.ContentRegion].Activate(window);
            }
            _activeWindow = (T)window;
            EventAggregator.GetEvent<ViewChangedEvent>().Publish();
            return (T)window;
        }

        public T LaunchDialog<T>() where T : Window {
            var window = Activator.CreateInstance(typeof(T));
            var win = (T)window;
            _activeDialog = win;
            win.ShowDialog();
            return win;
        }

        public void CloseDialog() {
            var isVisible = _activeDialog?.IsVisible;
            if (isVisible==true) {
                _activeDialog.Close();
            }
        }

        private void ClearRegion()
        {
            RegionManager.Regions[RegionNames.ContentRegion].RemoveAll();
        }

        public ContentControl GetActiveWindow()
        {
            return _activeWindow;
        }

        public void MessageBox(string message,string caption) {
            System.Windows.MessageBox.Show(message, caption, MessageBoxButton.OK);
        }

        ContentControl _activeWindow;
        Window _activeDialog;

        IRegionManager RegionManager { get { return ServiceLocator.Current.GetInstance<IRegionManager>(); } }

        IEventAggregator EventAggregator { get { return ServiceLocator.Current.GetInstance<IEventAggregator>(); } }
    }
}
