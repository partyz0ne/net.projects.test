namespace Persons.Domain.Commands
{
    using System;
    using Nancy;
    using Persons.Abstractions;
    using Serilog;

    public class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand, HttpStatusCode>
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

            Log.Information("Received CreatePerson command.");
        }

        public HttpStatusCode Execute()
        {
            HttpStatusCode response;

            try
            {
                _repo.Insert(_command.Person);
                response = HttpStatusCode.Created;
            }
            catch (Exception)
            {
                response = HttpStatusCode.BadRequest;
            }

            return response;
        }
    }
}