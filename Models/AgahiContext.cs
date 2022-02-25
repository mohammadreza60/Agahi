using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Agahi.Models
{
    public partial class AgahiContext : DbContext
    {
        public AgahiContext()
        {
        }

        public AgahiContext(DbContextOptions<AgahiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ad> Ads { get; set; }
        public virtual DbSet<AdGroup> AdGroups { get; set; }
        public virtual DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQL2017;Database=Agahi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Persian_100_CI_AS");

            modelBuilder.Entity<Ad>(entity =>
            {
                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(dateadd(month,(1),getdate()))");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Ads)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Ads_Cities");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Ads)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Ads_AdGroups");
            });

            modelBuilder.Entity<AdGroup>(entity =>
            {
                entity.Property(e => e.Keywords)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_AdGroups_AdGroups");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Cities_Cities");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
