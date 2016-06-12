using Autofac;
using CQRS.Infrastructure.Interfaces.ReadSide;
using CQRS.ReadSide.Repositories;
using CQRS.ReadSide.Repositories.Interfaces;

namespace CQRS.ReadSide.DependencyInjection
{
    public class Registration : Module
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ReadContext>().AsSelf();

            containerBuilder.RegisterType<ItemRepository>().As<IItemRepository>();
        }
    }
}
