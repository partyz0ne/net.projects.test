namespace Persons.Domain.Queries
{
    using System.Collections.Generic;
    using Persons.Abstractions;

    public static class PersonQueryHandlerFactory
    {
        /// <summary>
        /// Build a query handler for getting a person from repo.
        /// </summary>
        /// <param name="repo">Target repo.</param>
        /// <param name="query">Source query.</param>
        /// <returns>Built query handler.</returns>
        public static IQueryHandler<GetPersonQuery, IPerson> Build(IPersonRepository repo, GetPersonQuery query)
        {
            return new GetPersonQueryHandler(repo, query);
        }

        /// <summary>
        /// Build a query handler for getting a list of persons from repo.
        /// </summary>
        /// <param name="repo">Target repo.</param>
        /// <param name="query">Source query.</param>
        /// <returns>Built query handler.</returns>
        public static IQueryHandler<GetPersonsQuery, IList<IPerson>> Build(IPersonRepository repo, GetPersonsQuery query)
        {
            return new GetPersonsQueryHandler(repo, query);
        }
    }
}