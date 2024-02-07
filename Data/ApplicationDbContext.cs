using HMOManagerAPI.Authentication;
using HMOManagerAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace HMOManagerAPI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Site> Sites { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Room>()
                .HasOne(r => r.Site)
                .WithMany(s => s.Rooms)
                .HasForeignKey(r => r.SiteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Tenant>()
                .HasOne(t => t.Room)
                .WithMany(r => r.Tenants)
                .HasForeignKey(t => t.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
            
        }


    }
}
