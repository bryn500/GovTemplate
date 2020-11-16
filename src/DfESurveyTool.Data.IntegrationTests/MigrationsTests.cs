using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DfESurveyTool.Data.Tests
{
    [TestClass]
    public class MigrationsTests
    {
        private static SqlDbContextFactory dbFactory;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            dbFactory = new SqlDbContextFactory();
        }

        [TestMethod]
        public void Migrations_Work()
        {
            using (var context = dbFactory.CreateContext())
            {
                context.Database.EnsureDeleted(); // ensure db is deleted on starting
                context.Database.Migrate(); // run migrations
                context.GetService<IMigrator>().Migrate("0"); // 0 this will rollback all migrations, you can pass in the specific migration name here to go up or down to that migration
                context.Database.Migrate(); // back again
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            dbFactory.Dispose();
            dbFactory.DeleteTestDatabases();
        }
    }
}
