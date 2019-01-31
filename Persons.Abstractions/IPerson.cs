namespace Persons.Abstractions
{
    using System;

    public interface IPerson
    {
        /// <summary>
        /// Gets or sets Person's name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets Person's date of birth.
        /// </summary>
        DateTime BirthDate { get; set; }
    }
}