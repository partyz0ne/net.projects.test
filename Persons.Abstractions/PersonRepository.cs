namespace Persons.Abstractions
{
    using System;
    using System.Data.SQLite;
    using Dapper;

    public class PersonRepository : IPersonRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository" /> class.
        /// </summary>
        public PersonRepository()
        {
            try
            {
                var conn = CreateDbConnection();
                var res = conn.Execute("CREATE TABLE persons(Guid blob primary key not null, Name varchar(100) not null, BirthDate datetime not null)");
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Gets a connection to InMemory DB.
        /// </summary>
        private static SQLiteConnection CreateDbConnection()
        {
            var connection = new SQLiteConnection("Data Source=:memory:;cache=shared");
            connection.Open();
            return connection;
        } 

        public IPerson Find(Guid id)
        {
            PersonDTO res = null;
            try
            {
                using (var conn = CreateDbConnection())
                {
                    res = conn.QueryFirstOrDefault<PersonDTO>($"SELECT Name, BirthDate FROM persons WHERE Guid = '{id}';");
                }
            }
            catch (Exception ex)
            {
            }

            return res;
        }

        public void Insert(IPerson item)
        {
            try
            {
                using (var conn = CreateDbConnection())
                {
                    if (conn.Execute($"INSERT INTO persons(Name, BirthDate) VALUES('{item.Name}', '{item.BirthDate}')") > 0)
                    {
                        var lastInsertRowId = conn.ExecuteScalar<int>("SELECT last_insert_rowid FROM persons");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}