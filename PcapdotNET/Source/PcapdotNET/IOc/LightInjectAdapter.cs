using System;
using System.Linq.Expressions;
using LightInject;

namespace PcapdotNET.IOc
{
    public class LightInjectAdapder : IContainer
    {
        private readonly ServiceContainer _container = new ServiceContainer();

        public void Register<TService, TImplementation>(LifeTime lifeTime = LifeTime.PerContainer) where TImplementation : TService
        {
            if(lifeTime == LifeTime.PerContainer)
                _container.Register<TService, TImplementation>(new PerContainerLifetime());
            if(lifeTime == LifeTime.PerRequest)
                _container.Register<TService, TImplementation>(new PerRequestLifeTime());
            if (lifeTime == LifeTime.PerScope)
                _container.Register<TService, TImplementation>(new PerScopeLifetime()); 
        }

        public void Register<TService>(LifeTime lifeTime = LifeTime.PerContainer)
        {
            if (lifeTime == LifeTime.PerContainer)
                _container.Register<TService>(new PerContainerLifetime());
            if (lifeTime == LifeTime.PerRequest)
                _container.Register<TService>(new PerRequestLifeTime());
            if (lifeTime == LifeTime.PerScope)
                _container.Register<TService>(new PerScopeLifetime());
        }


        public void RegisterInstance<T>(T instance)
        {
            _container.RegisterInstance(instance);
        }

        public void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            _container.Register(serviceFactory => factory);
        }

        public TService Resolve<TService>()
        {
            return _container.GetInstance<TService>();
        }

        public bool IsRegistered<TService>()
        {
            return _container.CanGetInstance(typeof(TService), string.Empty);
        }
    }
}
