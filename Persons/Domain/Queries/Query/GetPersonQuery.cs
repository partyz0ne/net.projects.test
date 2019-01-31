namespace Persons.Domain.Queries
{
    using System;
    using Persons.Abstractions;

    public class GetPersonQuery : IQuery<IPerson>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPersonQuery" /> class.
        /// </summary>
        /// <param name="guid"></param>
        public GetPersonQuery(Guid guid)
        {
            Guid = guid;
        }

        /// <summary>
        /// Gets an unique ID.
        /// </summary>
        public Guid Guid { get; }
    }
}