namespace Persons.Service
{
    using System;
    using System.Data;
    using Dapper;
    using Nancy;
    using Nancy.TinyIoc;
    using Persons.Abstractions;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        /// <inheritdoc cref="DefaultNancyBootstrapper.ConfigureRequestContainer" />
        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            SqlMapper.AddTypeMap(typeof(DateTime), DbType.DateTime);

            container.Register<IPersonRepository, PersonRepository>();
        }
    }
}