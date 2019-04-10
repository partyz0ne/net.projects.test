namespace Persons.Abstractions
{
    using System;
    using System.Collections.Generic;

    public interface IPersonRepository
    {
        IPerson Find(Guid id);

        void Insert(IPerson item);

        IList<IPerson> Select();
    }
}