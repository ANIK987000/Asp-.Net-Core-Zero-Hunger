using Microsoft.EntityFrameworkCore;
using Zero_Hunger_Management.Models;

namespace Zero_Hunger_Management.Data
{
    public class ZeroHungerDBContext:DbContext
    {
        //public ZeroHungerDBContext()
        //{
        //}

        public ZeroHungerDBContext(DbContextOptions<ZeroHungerDBContext> options)
       : base(options)
        {
        }

        public DbSet<NGO> NGOS { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
        public DbSet<AssignEmployee> AssignEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships using Fluent API

            modelBuilder.Entity<AssignEmployee>()
                .HasOne(a => a.Employees)
                .WithMany(e => e.AssignEmployees)
                .HasForeignKey(a => a.EID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

            modelBuilder.Entity<AssignEmployee>()
                .HasOne(a => a.Restaurants)
                .WithMany(r => r.AssignEmployees)
                .HasForeignKey(a => a.RID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

            modelBuilder.Entity<AssignEmployee>()
                .HasOne(a => a.CollectRequests)
                .WithMany(c => c.AssignEmployees)
                .HasForeignKey(a => a.CRID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

            modelBuilder.Entity<CollectRequest>()
                .HasOne(c => c.Restaurants)
                .WithMany(r => r.CollectRequests)
                .HasForeignKey(c => c.RID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
        }
    }
}
