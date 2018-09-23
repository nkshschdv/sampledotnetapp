using System;
using System.Data.Entity;
using System.Linq;
using Technossus.Reincarnation.Data.Configurations;
using Technossus.Reincarnation.Models;

namespace Technossus.Reincarnation.Data
{
    public class ReincarnationContext : DbContext
    {
        public ReincarnationContext(): base("ReincarnationContext") { }
        public DbSet<File> Files { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FileConfiguration());
        }
        public override int SaveChanges()
        {
            DateTime time = DateTime.Now;
            var entries = ChangeTracker.Entries().ToList();

            foreach (var entry in entries.Where(e => e.State == EntityState.Added))
            {
                entry.Property("CreatedDate").CurrentValue = time;
                entry.Property("CreatedById").CurrentValue = "";
                entry.Property("UpdatedDate").CurrentValue = time;
                entry.Property("UpdatedById").CurrentValue = "";
            }

            foreach (var entry in entries.Where(e => e.State == EntityState.Modified))
            {
                entry.Property("UpdatedDate").CurrentValue = time;
                entry.Property("UpdatedById").CurrentValue = "";
            }

            return base.SaveChanges();
        }
    }
}
