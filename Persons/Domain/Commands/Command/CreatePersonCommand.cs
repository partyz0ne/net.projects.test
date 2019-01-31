namespace Persons.Domain.Commands
{
    using Persons.Abstractions;

    public class CreatePersonCommand : ICommand<Nancy.Response>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePersonCommand" /> class.
        /// </summary>
        /// <param name="person"></param>
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