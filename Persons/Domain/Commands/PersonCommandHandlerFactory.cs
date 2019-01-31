namespace Persons.Domain.Commands
{
    using Persons.Abstractions;

    public static class PersonCommandHandlerFactory
    {
        public static ICommandHandler<CreatePersonCommand, Nancy.Response> Build(IPersonRepository repo, CreatePersonCommand command)
        {
            return new CreatePersonCommandHandler(repo, command);
        }
    }
}