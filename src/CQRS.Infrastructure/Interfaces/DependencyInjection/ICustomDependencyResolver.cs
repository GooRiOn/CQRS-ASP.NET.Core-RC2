namespace CQRS.Infrastructure.DependencyInjection.Interfaces.DependencyInjection
{
    public interface ICustomDependencyResolver
    {
        TInterface Resolve<TInterface>();
    }
}