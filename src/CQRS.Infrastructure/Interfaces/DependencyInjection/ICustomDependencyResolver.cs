namespace CQRS.Infrastructure.Interfaces.DependencyInjection
{
    public interface ICustomDependencyResolver
    {
        TInterface Resolve<TInterface>();
    }
}