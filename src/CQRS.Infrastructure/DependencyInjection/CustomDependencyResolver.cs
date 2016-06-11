using Autofac;
using CQRS.Infrastructure.Interfaces.DependencyInjection;

namespace CQRS.Infrastructure.DependencyInjection
{
    public class CustomDependencyResolver : ICustomDependencyResolver
    {
        IContainer Container { get; }

        public CustomDependencyResolver(IContainer container)
        {
            Container = container;
        }

        public TInterface Resolve<TInterface>() => Container.Resolve<TInterface>();
    }
}