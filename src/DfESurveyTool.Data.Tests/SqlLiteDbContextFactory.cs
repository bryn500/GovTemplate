using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace DfESurveyTool.Data.Tests
{
    public class SqlLiteDbContextFactory : IDisposable
    {
        private SqliteConnection _connection;

        private DbContextOptions<DfESurveyToolDbContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<DfESurveyToolDbContext>()
                .UseSqlite(_connection).Options;
        }

        public DfESurveyToolDbContext CreateContext()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();

                var options = CreateOptions();
                using (var context = new DfESurveyToolDbContext(options))
                {
                    context.Database.EnsureCreated();
                }
            }

            return new DfESurveyToolDbContext(CreateOptions());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
