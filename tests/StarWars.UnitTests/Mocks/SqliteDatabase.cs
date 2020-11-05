using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StarWars.Persistence;
using System;

namespace StarWars.UnitTests.Mocks
{
    public abstract class SqliteDatabase : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly DataContext DbContext;

        protected SqliteDatabase()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlite(_connection)
                    .Options;
            DbContext = new DataContext(options);
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}