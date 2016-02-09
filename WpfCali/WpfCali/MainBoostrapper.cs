using Caliburn.Micro;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfCali.ViewModels;

namespace WpfCali
{
    public class MainBootstrapper : BootstrapperBase
    {
        private UnityContainer container;

        public MainBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new UnityContainer();
            container.RegisterInstance<IWindowManager>(new WindowManager());
            container.RegisterInstance<IEventAggregator>(new EventAggregator());

        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return container.Resolve(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.ResolveAll(service);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
