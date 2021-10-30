using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt)
            : base(opt)
        {
        }

        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Restaurant>()
                .HasMany(r => r.UserRoles)
                .WithOne(r => r.Restaurant!)
                .HasForeignKey(r => r.RestaurantId);

            modelBuilder
                .Entity<UserRole>()
                .HasOne(r => r.Restaurant)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(r => r.RestaurantId);
        }
    }
}
