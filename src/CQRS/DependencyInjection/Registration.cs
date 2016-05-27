using Autofac;

namespace CQRS.DependencyInjection
{
    public class Registration : Module
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            CQRS.Messaging.DependencyInjection.Registration.Register(containerBuilder);
        }
    }
}