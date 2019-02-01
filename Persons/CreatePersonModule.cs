namespace Persons
{
    using System;
    using Nancy;
    using Nancy.ModelBinding;
    using Persons.Abstractions;
    using Persons.Domain.Commands;

    public class CreatePersonModule : NancyModule
    {
        private readonly IPersonRepository _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePersonModule" /> class.
        /// </summary>
        /// <param name="repo">Database repository</param>
        public CreatePersonModule(IPersonRepository repo) 
            : base("/api/v1")
        {
            _repo = repo;

            Post["/persons"] = parameters =>
            {
                var person = this.Bind<Person>();
                if (person == null || string.IsNullOrEmpty(person.Name) || person.BirthDate == DateTime.MinValue)
                {
                    return HttpStatusCode.BadRequest;
                }

                var command = new CreatePersonCommand(person);
                var handler = PersonCommandHandlerFactory.Build(_repo, command);
                var statusCode = handler.Execute();
                if (statusCode == HttpStatusCode.Created)
                {
                    return new Response().WithHeader("Location", $"{ModulePath}/persons/{person.Guid}").WithStatusCode(HttpStatusCode.Created);
                }

                return statusCode;
            };
        }
    }
}