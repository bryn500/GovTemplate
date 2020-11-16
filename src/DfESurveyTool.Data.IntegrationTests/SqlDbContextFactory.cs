using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;

namespace DfESurveyTool.Data.Tests
{
    public class SqlDbContextFactory : IDisposable
    {
        private readonly string _servername = "(localdb)\\mssqllocaldb";
        private readonly string _databaseName;
        private readonly string _connectionString;
        private SqlConnection _connection;

        public SqlDbContextFactory()
        {
            _databaseName = $"DfESurveyTool-Integrations-Test{DateTime.Now:MM/dd/yyyy-HH:mm:ss}";
            _connectionString = $"Server={_servername};Database={_databaseName};Trusted_Connection=True;MultipleActiveResultSets=true;Pooling=false;";
        }

        private DbContextOptions<DfESurveyToolDbContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<DfESurveyToolDbContext>()
                .UseSqlServer(_connectionString).Options;
        }

        public DfESurveyToolDbContext CreateContext()
        {
            _connection = new SqlConnection(_connectionString);

            return new DfESurveyToolDbContext(CreateOptions());
        }

        public void DeleteTestDatabases()
        {
            ServerConnection connection = new ServerConnection(new SqlConnection($"Data Source={_servername};Initial Catalog=master;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"));

            var server = new Server(connection);

            List<string> databasesToDelete = new List<string>();

            foreach (Database db in server.Databases)
            {
                if (db.Name.Contains("DfESurveyTool-Integrations-Test"))
                {
                    databasesToDelete.Add(db.Name);
                }
            }

            databasesToDelete.ForEach(x =>
            {
                Database db = new Database(server, x);
                db.Refresh();
                db.Drop();
            });
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
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
