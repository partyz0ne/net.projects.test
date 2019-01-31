namespace Persons.Abstractions
{
    using System;

    public class PersonDTO : IPerson
    {
        /// <inheritdoc cref="IPerson.Name"/>
        public string Name { get; set; }

        /// <inheritdoc cref="IPerson.BirthDate"/>
        public DateTime BirthDate { get; set; }
    }
}