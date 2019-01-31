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
        /// <param name="repo"></param>
        public CreatePersonModule(IPersonRepository repo) 
            : base("/api/v1")
        {
            _repo = repo;

            Post["/persons"] = parameters =>
            {
                var person = this.Bind<Person>();
                person.Guid = new Guid();

                var command = new CreatePersonCommand(person);
                var handler = PersonCommandHandlerFactory.Build(_repo, command);
                return handler.Execute();
            };
        }
    }
}