using Microsoft.EntityFrameworkCore;

namespace AnalyticsProject.DataModels
{
    public class SMAContext : DbContext
    {

        // The DBContext describes the context for the database, each Database object needs to be set here.
        // Needed for the database to recognise the object and start including it in migrations.
        public DbSet<HomePage> HomePages { get; set; }
          public DbSet<Event> Events { get; set; }
          public DbSet<SummaryInformation> SummaryInformations { get; set; }
          public DbSet<Users> Users { get; set; }
          public DbSet<FacebookDb> FacebookDbs { get; set; }
          public DbSet<LinkedInDb> LinkedInDbs { get; set; }

          public DbSet<TwitterMLDb> TwitterMLDbs { get; set; }
        
        // Setting Default Options for Database context
        public SMAContext(DbContextOptions<SMAContext> options)
                : base(options)
            {
            }

        // Calls the migrations to create the database and uses the ModelBuilder Library to build it.
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
    }