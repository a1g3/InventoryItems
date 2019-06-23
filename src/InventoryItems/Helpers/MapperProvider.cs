using Autofac;
using AutoMapper;
using System.Reflection;

namespace InventoryItems.Helpers
{
    public class MapperProvider : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var config = CreateConfiguration();
            builder.RegisterInstance(config).As<MapperConfiguration>().SingleInstance();
            builder.RegisterInstance(new Mapper(config)).As<IMapper>().SingleInstance();
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly(), Assembly.Load("InventoryItems.Domain"), Assembly.Load("InventoryItems.Data"));
            });
            config.AssertConfigurationIsValid();

            return config;
        }
    }
}
