using Microsoft.EntityFrameworkCore;
using MVCProject.Entities;
using System.Reflection;

namespace MVCProject.Contexts
{
    public class GymDbContext:DbContext
    {


        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {

        }
        //override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=GymDb;Trusted_Connection=True;TrustServerCertificate=True");
        //}


        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        #region DBSets
        public DbSet<Member> Members { get; set; } 
        public DbSet<Trainer> Trainers { get; set; } 
        public DbSet<Session> Sessions { get; set; } 
        public DbSet<Membership> Memberships { get; set; } 
        public DbSet<Plan> Plans { get; set; } 





        #endregion
    }
}
