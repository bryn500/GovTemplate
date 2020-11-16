using DfESurveyTool.Data.Enums;
using DfESurveyTool.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DfESurveyTool.Data
{
    public class DfESurveyToolDbContext : DbContext
    {
        public DfESurveyToolDbContext(DbContextOptions<DfESurveyToolDbContext> options) 
            : base(options)
        {
        }

        public DbSet<MyModel> MyModel { get; set; }
        public DbSet<MyModelStatus> MyModelStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyModel>(e =>
            {
                e.Property(e => e.MyModelStatusId)
                 .HasConversion<int>();

                // Indexes
                e.HasIndex(f => f.Name).IsUnique();
                e.HasIndex(f => f.MyModelStatusId);
            });

            modelBuilder.Entity<MyModelStatus>(e =>
            {
                e.HasIndex(f => f.Name).IsUnique();
                e.HasData(Enum.GetValues(typeof(MyModelStatusId))
                        .Cast<MyModelStatusId>()
                        .Select(e => new MyModelStatus(e)));
            });
        }
    }
}
