using Prism.Unity;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using System;
using NdubuisiJr.Z_Digit.Infrastructure.Service;
using NdubuisiJr.Z_Digit.Data.Data;
using NdubuisiJr.Z_Digit.Infrastructure;

namespace Z_Digit {
    public class Bootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
           return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow.Show();
        }
        protected override IModuleCatalog CreateModuleCatalog()
        {
            base.CreateModuleCatalog();

            return new DirectoryModuleCatalog()
            {
                ModulePath = AppDomain.CurrentDomain.BaseDirectory+"Modules"
            };
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "ZfactorData.txt";
            Container.RegisterInstance<IDataService>(new TextFileConfiguration(filePath), new ContainerControlledLifetimeManager());
            Container.RegisterInstance<IWindowService>(new WindowService(), new ContainerControlledLifetimeManager());
            Container.RegisterInstance(new CriticalZfactorService(), new ContainerControlledLifetimeManager());
            Container.RegisterInstance(new ReducedZFactorService(), new ContainerControlledLifetimeManager());
        }
    }
}
