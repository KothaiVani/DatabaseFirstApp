using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataFirstApp.Models
{
    public partial class SampleWorkoutsContext : DbContext
    {
        public SampleWorkoutsContext()
        {
        }

        public SampleWorkoutsContext(DbContextOptions<SampleWorkoutsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-NGQAKEI;Database=SampleWorkouts;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Capital)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Currency).HasMaxLength(20);

                entity.Property(e => e.Economy).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });
           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
