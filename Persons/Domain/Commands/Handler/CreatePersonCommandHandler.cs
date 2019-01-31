namespace Persons.Domain.Commands
{
    using Persons.Abstractions;

    public class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand, Nancy.Response>
    {
        private readonly IPersonRepository _repo;
        private readonly CreatePersonCommand _command;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePersonCommandHandler" /> class.
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="command"></param>
        public CreatePersonCommandHandler(IPersonRepository repo, CreatePersonCommand command)
        {
            _repo = repo;
            _command = command;
        }

        public Nancy.Response Execute()
        {
            _repo.Insert(_command.Person);

            var response = Nancy.Responses.HtmlResponse.NoBody;

            return response;
        }
    }
}