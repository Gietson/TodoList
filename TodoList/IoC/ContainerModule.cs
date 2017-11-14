using Autofac;
using Microsoft.Extensions.Configuration;
using TodoList.IoC.Modules;
using TodoList.Mappers;
using TodoList.Repositories;
using TodoList.Services;

namespace TodoList.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();

            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<MongoModule>();
            builder.RegisterModule<ServiceModule>();

            builder.RegisterModule(new SettingsModule(_configuration));
        }
    }
}
