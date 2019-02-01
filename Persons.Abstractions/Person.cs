namespace Persons.Abstractions
{
    using System;

    public class Person : IPerson
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person" /> class.
        /// </summary>
        /// <param name="name">Person's name.</param>
        /// <param name="birthDate">Person's birth date.</param>
        public Person(string name, DateTime birthDate)
            : this()
        {
            Name = name;
            BirthDate = birthDate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person" /> class.
        /// </summary>
        protected Person()
        {
            Guid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets an unique ID.
        /// </summary>
        public Guid Guid { get; }

        /// <inheritdoc cref="IPerson.Name" />
        public string Name { get; set; }

        /// <inheritdoc cref="IPerson.BirthDate" />
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets Person's age.
        /// </summary>
        public int? Age
        {
            get
            {
                var age = DateTime.Now.Year - BirthDate.Year;
                if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
                {
                    age = age - 1;
                }

                if (age > 120 || string.IsNullOrEmpty(Name))
                {
                    return null;
                }

                return age;
            }
        }
    }
}