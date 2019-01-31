namespace Persons
{
    using System;
    using Nancy;
    using Persons.Abstractions;
    using Persons.Domain.Queries;

    public class GetPersonModule : NancyModule
    {
        private readonly IPersonRepository _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPersonModule" /> class.
        /// </summary>
        /// <param name="repo"></param>
        public GetPersonModule(IPersonRepository repo) 
            : base("/api/v1")
        {
            _repo = repo;

            Get["/persons/{person_id}"] = parameters =>
            {
                var query = new GetPersonQuery(new Guid(parameters["person_id"]));
                var handler = PersonQueryHandlerFactory.Build(_repo, query);
                var person = handler.Get();

                return Response.AsJson(person);
            };
        }
    }
}