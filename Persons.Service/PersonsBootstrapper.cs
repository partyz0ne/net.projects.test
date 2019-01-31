namespace Persons.Service
{
    using Nancy;
    using Nancy.TinyIoc;
    using Persons.Abstractions;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        /// <inheritdoc cref="DefaultNancyBootstrapper.ConfigureRequestContainer" />
        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            container.Register<IPersonRepository, PersonRepository>();
        }
    }
}