﻿using Microsoft.Practices.Unity;
using Prism.Unity;
using BasicRegionNavigation.Views;
using System.Windows;
using Prism.Modularity;
using WpfPrismApp.PersonModule;

namespace BasicRegionNavigation
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog) ModuleCatalog;
            catalog.AddModule(typeof(PersonModule));
        }
    }
}
