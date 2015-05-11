using System;
using System.Linq.Expressions;
using LightInject;

namespace Presenter.Common
{
    public interface IContainer
    {
        void Register<TService, TImplementation>(LifeTime lifeTime = LifeTime.PerContainer) where TImplementation : TService;

        void Register<TService>(LifeTime lifeTime = LifeTime.PerContainer);
        void RegisterInstance<T>(T instance);
        TService Resolve<TService>();
        bool IsRegistered<TService>();
        void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory);
    }
}
