using Autofac;
using CQRS.Infrastructure.Interfaces.EventStore;

namespace CQRS.DataAccess.DependencyInjection
{
    public class Registration : Module
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<WriteContext>().AsSelf();

            containerBuilder.RegisterType<EventStore>().As<IEventStore>();
        }
    }
}