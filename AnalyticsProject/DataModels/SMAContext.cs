using Microsoft.EntityFrameworkCore;

namespace AnalyticsProject.DataModels
{
    public class SMAContext : DbContext
    {

            // DB stuff goes here
          public DbSet<HomePage> HomePages { get; set; }
          public DbSet<Event> Events { get; set; }
          public DbSet<SummaryInformation> SummaryInformations { get; set; }
          public DbSet<Users> Users { get; set; }
          public DbSet<FacebookDb> FacebookDbs { get; set; }
          public DbSet<LinkedInDb> LinkedInDbs { get; set; }


        public SMAContext(DbContextOptions<SMAContext> options)
                : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
    }