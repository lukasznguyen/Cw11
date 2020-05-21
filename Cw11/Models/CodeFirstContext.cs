using Cw11.StartingData;
using Microsoft.EntityFrameworkCore;

namespace Cw11.Models
{
    public class CodeFirstContext : DbContext
    {

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }

        public CodeFirstContext(DbContextOptions<CodeFirstContext>options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired();
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(p => p.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Patient");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(p => p.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Doctor");

            });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasOne(m => m.Medicament)
                    .WithMany(pm => pm.PrescriptionMedicaments)
                    .HasForeignKey(pm => pm.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PrescriptionMedicament_Medicament");
                entity.HasKey(e => e.IdMedicament).HasName("PrescriptionMedicament_PK1");

                entity.HasOne(p => p.Prescription)
                    .WithMany(pm => pm.PrescriptionMedicament)
                    .HasForeignKey(pm => pm.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PrescriptionMedicament_Prescription");
                entity.HasKey(e => e.IdPrescription).HasName("PrescriptionMedicament_PK2");


                entity.Property(e => e.Dose);
                entity.Property(e => e.Details).HasMaxLength(100).IsRequired();
                entity.ToTable("Prescription_Medicament");
            });

            modelBuilder.ApplyConfiguration(new StartingDataDoctor());
            modelBuilder.ApplyConfiguration(new StartingDataMedicament());
            modelBuilder.ApplyConfiguration(new StartingDataPatient());
            modelBuilder.ApplyConfiguration(new StartingDataPrescription());
            modelBuilder.ApplyConfiguration(new StartingDataPrescriptionMedicament());
        }

    }
}
