using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyHomeTechnicalTest.Models
{
    public partial class MyHomeContext : DbContext
    {
        public MyHomeContext()
        {
        }

        public MyHomeContext(DbContextOptions<MyHomeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Property> Properties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //This should be moved to the appsettings
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=myhome1.database.windows.net;Initial Catalog=MyHome;User ID=MyHomeAdmin;Password=MyHomePass1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photos_ToTable");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Bath)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BedsString)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BerRating)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupLogoUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
