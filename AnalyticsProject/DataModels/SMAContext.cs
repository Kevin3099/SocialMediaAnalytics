using Microsoft.EntityFrameworkCore;

namespace AnalyticsProject.DataModels
{
    public class SMAContext : DbContext
    {

            // DB stuff goes here
            public DbSet<HomePage> HomePages { get; set; }

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