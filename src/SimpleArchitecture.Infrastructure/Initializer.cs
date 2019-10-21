using CommonServiceLocator;
using SimpleArchitecture.Abstractions;
using SimpleArchitecture.Abstractions.Repository;
using SimpleArchitecture.Abstractions.Service;
using SimpleArchitecture.Repository;
using SimpleArchitecture.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Lifetime;

namespace SimpleArchitecture.Infrastructure
{
    public class Initializer
    {

        public void Initialize()
        {
            this.RegisterContainer();
            this.RegisterLogger();
            this.RegisterRepository();
            this.RegisterService();
        }

        private void RegisterContainer()
        {
            var uc = new UnityContainer();
            uc.RegisterInstance<IUnityContainer>(uc);
            ServiceLocator.SetLocatorProvider(() => new Unity.ServiceLocation.UnityServiceLocator(uc));
        }

        private void RegisterLogger()
        {
            NLog.LogManager.Configuration = NLogConfiguration.Config();
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterType(typeof(IAppLogger<>), typeof(LoggerAdapter<>), new ContainerControlledLifetimeManager());
        }

        private void RegisterRepository()
        {
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterType<ISampleRepo, SampleRepo>();
        }

        private void RegisterService()
        {
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterType<ISampleService, SampleService>();
        }
    }
}
