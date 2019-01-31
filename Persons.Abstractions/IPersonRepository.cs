namespace Persons.Abstractions
{
    using System;

    public interface IPersonRepository
    {
        IPerson Find(Guid id);

        void Insert(IPerson item);
    }
}