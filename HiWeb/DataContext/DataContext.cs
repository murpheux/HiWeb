using HiWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.SqlServer;
using System.Linq;
using System.Web;

namespace HiWeb.DataContext
{
    public class RepositoryContext : DbContext
    {
        private DbContext _context;
        public DbSet<Student> Students { get; set; }

        public RepositoryContext()
        { }

        //public RepositoryContext(DbContextOptions contextOptions)
        //{
        //    //Database.EnsureCreated();
        //}

        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    //var connectionString = "Server=(localdb)\\mssqllocaldb;Database=DataDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        //    var connectionString = Startup.ConfigurationStatic["Data:DefaultConnection:ConnectionString"];

        //    builder.UseSqlServer(connectionString);
        //    base.OnConfiguring(builder);
        //}

        //public DataContext(DbContextOptions<DataContext> options)
        //    : base(options)
        //{ }

        public RepositoryContext(DbContext context)
        {
            _context = context;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;");
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Blog>()
        //        .Property(b => b._Tags).HasColumnName("Tags");

        //    modelBuilder.Entity<Blog>()
        //        .Property(b => b._Owner).HasColumnName("Owner");
        //}

    }
}