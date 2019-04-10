namespace Persons.Domain.Queries
{
    using System.Collections.Generic;
    using Persons.Abstractions;

    public class GetPersonsQuery : IQuery<IList<IPerson>>
    {
    }
}