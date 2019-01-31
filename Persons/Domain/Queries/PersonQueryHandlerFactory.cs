namespace Persons.Domain.Queries
{
    using Persons.Abstractions;

    public static class PersonQueryHandlerFactory
    {
        public static IQueryHandler<GetPersonQuery, IPerson> Build(IPersonRepository repo, GetPersonQuery query)
        {
            return new GetPersonQueryHandler(repo, query);
        }
    }
}