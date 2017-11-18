using System;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using WpfPrismApp.PersonModule.Services;
using WpfPrismApp.PersonModule.Views;

namespace WpfPrismApp.PersonModule
{
    public class PersonModule : IModule
    {
        public PersonModule(RegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterTypeForNavigation<PersonListView>();
            container.RegisterType<IPersonService, PersonService>();
            regionManager.RequestNavigate("ContentRegion", new Uri("PersonListView", UriKind.Relative));
        }

        private IRegionManager regionManager;
        private IUnityContainer container;
    }
}