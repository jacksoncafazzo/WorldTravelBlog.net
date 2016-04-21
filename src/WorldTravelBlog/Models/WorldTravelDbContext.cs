using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTravelBlog.Models
{
    public class WorldTravelDbContext : DbContext
    {
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<ExperienceLocation> ExperienceLocations { get; set; }
        public DbSet<ExperiencePerson> ExperiencePeople { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Experience>()
                .HasMany(o => o.ExperienceLocations);
            builder.Entity<Experience>()
                .HasMany(o => o.ExperiencePeople)
                .WithOne(ep => ep.Experience)
                .HasForeignKey(ep => ep.ExperienceId);
                
        }
    }
}