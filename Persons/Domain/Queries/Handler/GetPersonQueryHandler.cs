namespace Persons.Domain.Queries
{
    using Persons.Abstractions;

    public class GetPersonQueryHandler : IQueryHandler<GetPersonQuery, IPerson>
    {
        private readonly IPersonRepository _repo;
        private readonly GetPersonQuery _query;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPersonQueryHandler" /> class.
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="query"></param>
        public GetPersonQueryHandler(IPersonRepository repo, GetPersonQuery query)
        {
            _repo = repo;
            _query = query;
        }

        public IPerson Get()
        {
            return _repo.Find(_query.Guid);
        }
    }
}