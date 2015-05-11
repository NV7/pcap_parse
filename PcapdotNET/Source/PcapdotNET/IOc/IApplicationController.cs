using Presenter.Common;

namespace WorkersManagement.IoC
{
    public interface IApplicationController
    {
        IApplicationController RegisterView<TView, TImplementation>(LifeTime lifeTime = LifeTime.PerContainer)
            where TImplementation : class, TView
            where TView : IView;

        IApplicationController RegisterInstance<TArgument>(TArgument instance);

        IApplicationController RegisterInstance<TArgument>(TArgument instance, LifeTime lifeTime = LifeTime.PerContainer);

        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        IApplicationController RegisterService<TService, TImplementation>(LifeTime lifeTime = LifeTime.PerContainer)
            where TImplementation : class, TService;

        void Run<TPresenter>()
            where TPresenter : class, IPresenter;

        void Run<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenter<TArgumnent>;

        TService Resolve<TService>();
    }
}
