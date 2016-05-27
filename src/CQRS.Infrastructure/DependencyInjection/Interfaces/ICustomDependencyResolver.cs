namespace CQRS.Infrastructure.DependencyInjection.Interfaces
{
    public interface ICustomDependencyResolver
    {
        TInterface Resolve<TInterface>();
    }
}