using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Appointment_Schedular.Models;

public partial class AppointmentSchedularContext : DbContext
{
    public AppointmentSchedularContext()
    {
    }

    public AppointmentSchedularContext(DbContextOptions<AppointmentSchedularContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppointmentSchedular> AppointmentSchedulars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=AppointmentSchedular;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppointmentSchedular>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Table__8ECDFCC23E2FCA73");

            entity.ToTable("AppointmentSchedular");

            entity.Property(e => e.AppointmentId).ValueGeneratedNever();
            entity.Property(e => e.Address).HasColumnType("ntext");
            entity.Property(e => e.FeesCharged)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Fees Charged");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.NoOfHours).HasColumnName("No of hours");
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsFixedLength();
            entity.Property(e => e.RemarkOfAppointment)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("Remark of Appointment");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
