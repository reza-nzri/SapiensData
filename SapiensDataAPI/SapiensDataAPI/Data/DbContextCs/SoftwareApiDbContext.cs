using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftwareManagementAPI.Models;

namespace SoftwareManagementAPI.Data.DbContextCs
{
    public class SoftwareApiDbContext : IdentityDbContext<ApplicationUserModel>
    {
        public SoftwareApiDbContext(DbContextOptions<SoftwareApiDbContext> options) : base(options)
        {
        }

        public DbSet<SoftwareModel> Softwares { get; set; }
        public virtual DbSet<RefreshTokenModel> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SoftwareModel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Software");

                entity.ToTable("Software");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(1000);

                entity.Property(e => e.Release)
                    .HasColumnType("datetime")
                    .IsRequired(false);
            });

            modelBuilder.Entity<RefreshTokenModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Token)
                    .HasMaxLength(1000)
                    .IsRequired();

                entity.Property(e => e.JwtId)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpiredAt)
                    .HasColumnType("datetime");

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}