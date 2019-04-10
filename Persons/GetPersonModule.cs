namespace Persons
{
    using System;
    using System.Linq;
    using Nancy;
    using Persons.Abstractions;
    using Persons.Domain.Queries;
    using Serilog;

    public class GetPersonModule : NancyModule
    {
        private readonly IPersonRepository _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPersonModule" /> class.
        /// </summary>
        /// <param name="repo">Database repository</param>
        public GetPersonModule(IPersonRepository repo) 
            : base("/api/v1")
        {
            _repo = repo;

            Get["/persons"] = parameters =>
            {
                try
                {
                    var query = new GetPersonsQuery();
                    var handler = PersonQueryHandlerFactory.Build(_repo, query);
                    var persons = handler.Get();
                    if (persons == null || !persons.Any())
                    {
                        return HttpStatusCode.NotFound;
                    }

                    return Response.AsJson(persons);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error of {0} execution.", nameof(GetPersonModule));
                }

                return HttpStatusCode.NotFound;
            };

            Get["/persons/{person_id}"] = parameters =>
            {
                try
                {
                    var query = new GetPersonQuery(new Guid(parameters["person_id"]));
                    var handler = PersonQueryHandlerFactory.Build(_repo, query);
                    var person = handler.Get();
                    if (person == null)
                    {
                        return HttpStatusCode.NotFound;
                    }

                    return Response.AsJson(person);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error of {0} execution.", nameof(GetPersonModule));
                }

                return HttpStatusCode.NotFound;
            };
        }
    }
}