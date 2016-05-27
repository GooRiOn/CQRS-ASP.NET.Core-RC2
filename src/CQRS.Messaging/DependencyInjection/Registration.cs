using Autofac;

namespace CQRS.Messaging.DependencyInjection
{
    public class Registration : Module
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            Domain.DependencyInjection.Registration.Register(containerBuilder);
        } 
    }
}