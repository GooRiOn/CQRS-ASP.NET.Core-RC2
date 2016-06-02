using Autofac;
using CQRS.Infrastructure.Interfaces.ReadSide;
using CQRS.ReadSide.Repositories;

namespace CQRS.ReadSide.DependencyInjection
{
    public class Registration : Module
    {
        public static void Register(ContainerBuilder conatinerBuilder)
        {
            conatinerBuilder.RegisterGeneric(typeof(InMemoryGenericRepo<>)).As(typeof(IInMemoryGenericRepo<>));
        }
    }
}
