namespace Persons.Domain.Commands
{
    using Nancy;
    using Persons.Abstractions;

    public class CreatePersonCommand : ICommand<HttpStatusCode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePersonCommand" /> class.
        /// </summary>
        /// <param name="person">Initialized person instance.</param>
        public CreatePersonCommand(IPerson person)
        {
            Person = person;
        }

        /// <summary>
        /// Gets a person instance.
        /// </summary>
        public IPerson Person { get; }
    }
}