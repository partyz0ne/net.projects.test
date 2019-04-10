namespace Persons.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;
    using System.Linq;
    using Dapper;
    using Serilog;

    public class PersonRepository : IPersonRepository
    {
        /// <summary>
        /// Database file name.
        /// </summary>
        private const string DbFileName = "persons.db";

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository" /> class.
        /// </summary>
        public PersonRepository()
        {
            if (File.Exists(DbPath))
            {
                return;
            }

            try
            {
                using (var conn = CreateDbConnection())
                {
                    var res = conn.Execute("CREATE TABLE persons(Guid varchar(50) primary key not null, Name varchar(100) not null, BirthDate datetime not null)");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Repo initializing error.");
            }
        }

        /// <summary>
        /// Full path to database file.
        /// </summary>
        private static string DbPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);

        /// <inheritdoc cref="IPersonRepository.Find"/>
        public IPerson Find(Guid id)
        {
            PersonDTO res = null;
            try
            {
                using (var conn = CreateDbConnection())
                {
                    const string Sql = "SELECT Name, BirthDate FROM persons WHERE Guid = @Guid";
                    res = conn.QuerySingleOrDefault<PersonDTO>(Sql, new { Guid = id.ToString() });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Find item error.");
            }

            return res;
        }

        /// <inheritdoc cref="IPersonRepository.Insert"/>
        public void Insert(IPerson item)
        {
            try
            {
                using (var conn = CreateDbConnection())
                {
                    if (item is Person person)
                    {
                        const string Sql = "INSERT INTO persons(Guid, Name, BirthDate) VALUES(@Guid, @Name, @BirthDate)";
                        conn.Execute(Sql, new { Guid = person.Guid.ToString(), Name = person.Name, BirthDate = person.BirthDate });
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Insert item error.");
                throw;
            }
        }

        /// <inheritdoc cref="IPersonRepository.Select" />
        public IList<IPerson> Select()
        {
            var res = new List<IPerson>();
            try
            {
                using (var conn = CreateDbConnection())
                {
                    const string Sql = "SELECT Name, BirthDate FROM persons";
                    res = conn.Query<PersonDTO>(Sql).Cast<IPerson>().ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Select items error.");
            }

            return res;
        }

        /// <summary>
        /// Gets a connection to InMemory DB.
        /// </summary>
        /// <returns>Opened database connection.</returns>
        private static SQLiteConnection CreateDbConnection()
        {
            var connection = new SQLiteConnection($"Data Source={DbPath}");
            connection.Open();
            return connection;
        }
    }
}