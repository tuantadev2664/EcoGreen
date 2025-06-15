using Application.Entities.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfrasStructure.EntityFramework.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Certificate> Certificates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User has many Registrations
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Activity)
                .WithMany()
                .HasForeignKey(r => r.ActivityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Certificate>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Certificate>()
                .HasOne(c => c.Activity)
                .WithMany()
                .HasForeignKey(c => c.ActivityId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Certificate>()
                .HasOne(c => c.CompanyUser)
                .WithMany()
                .HasForeignKey(c => c.IssuedByCompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Activity>()
                .HasOne(a => a.CompanyUser)
                .WithMany()
                .HasForeignKey(a => a.CreatedByCompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
