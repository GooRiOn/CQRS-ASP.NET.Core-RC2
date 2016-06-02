using Autofac;

namespace CQRS.DependencyInjection
{
    public class Registration : Module
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            Messaging.DependencyInjection.Registration.Register(containerBuilder);
            ReadSide.DependencyInjection.Registration.Register(containerBuilder);
        }
    }
}