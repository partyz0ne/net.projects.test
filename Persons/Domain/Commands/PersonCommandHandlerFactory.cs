namespace Persons.Domain.Commands
{
    using Nancy;
    using Persons.Abstractions;

    public static class PersonCommandHandlerFactory
    {
        public static ICommandHandler<CreatePersonCommand, HttpStatusCode> Build(IPersonRepository repo, CreatePersonCommand command)
        {
            return new CreatePersonCommandHandler(repo, command);
        }
    }
}