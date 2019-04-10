namespace Persons.Domain.Queries
{
    using System.Collections.Generic;
    using Persons.Abstractions;

    public class GetPersonsQueryHandler : IQueryHandler<GetPersonsQuery, IList<IPerson>>
    {
        private readonly IPersonRepository _repo;
        private readonly GetPersonsQuery _query;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPersonsQueryHandler" /> class.
        /// </summary>
        /// <param name="repo">Database repository.</param>
        /// <param name="query">Query instance.</param>
        public GetPersonsQueryHandler(IPersonRepository repo, GetPersonsQuery query)
        {
            _repo = repo;
            _query = query;
        }

        public IList<IPerson> Get()
        {
            return _repo.Select();
        }
    }
}