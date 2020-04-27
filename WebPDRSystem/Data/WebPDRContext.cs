using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebPDRSystem.Models;

namespace WebPDRSystem.Data
{
    public partial class WebPDRContext : DbContext
    {
        public WebPDRContext()
        {
        }

        public WebPDRContext(DbContextOptions<WebPDRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barangay> Barangay { get; set; }
        public virtual DbSet<ClinicalParametersQd> ClinicalParametersQd { get; set; }
        public virtual DbSet<ClinicalParametersQn> ClinicalParametersQn { get; set; }
        public virtual DbSet<Discharge> Discharge { get; set; }
        public virtual DbSet<Guardian> Guardian { get; set; }
        public virtual DbSet<Medications> Medications { get; set; }
        public virtual DbSet<Muncity> Muncity { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Pdr> Pdr { get; set; }
        public virtual DbSet<Pdrusers> Pdrusers { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Qdform> Qdform { get; set; }
        public virtual DbSet<Qnform> Qnform { get; set; }
        public virtual DbSet<Referral> Referral { get; set; }
        public virtual DbSet<SymptomsContacts> SymptomsContacts { get; set; }
        public virtual DbSet<TeamSchedule> TeamSchedule { get; set; }
        public virtual DbSet<UserTeams> UserTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ROCKY\\SQLEXPRESS;Initial Catalog=PDRSDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barangay>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<ClinicalParametersQd>(entity =>
            {
                entity.HasIndex(e => e.DailyMonitoringFormQdModelId);

                entity.Property(e => e.OtherDetails).IsUnicode(false);

                entity.Property(e => e.Temperature).IsUnicode(false);
            });

            modelBuilder.Entity<ClinicalParametersQn>(entity =>
            {
                entity.HasIndex(e => e.DailyMonitoringFormQnModelId);

                entity.Property(e => e.Bp).IsUnicode(false);

                entity.Property(e => e.Enumerate).IsUnicode(false);

                entity.Property(e => e.Hr).IsUnicode(false);

                entity.Property(e => e.Meds).IsUnicode(false);

                entity.Property(e => e.O2sat).IsUnicode(false);

                entity.Property(e => e.OtherDetails).IsUnicode(false);

                entity.Property(e => e.Rr).IsUnicode(false);

                entity.Property(e => e.UrineOutput).IsUnicode(false);
            });

            modelBuilder.Entity<Discharge>(entity =>
            {
                entity.HasIndex(e => e.HealthCareBuddy);

                entity.HasIndex(e => e.Pdrid);

                entity.Property(e => e.DischargedApprovedBy).IsUnicode(false);

                entity.Property(e => e.DischargedBy).IsUnicode(false);

                entity.Property(e => e.GuardOnDuty).IsUnicode(false);

                entity.Property(e => e.QuarantineDirectorOrOfficer).IsUnicode(false);

                entity.HasOne(d => d.HealthCareBuddyNavigation)
                    .WithMany(p => p.Discharge)
                    .HasForeignKey(d => d.HealthCareBuddy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DischargeTable_PDRUsers");

                entity.HasOne(d => d.Pdr)
                    .WithMany(p => p.Discharge)
                    .HasForeignKey(d => d.Pdrid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DischargeTable_PDRTable");
            });

            modelBuilder.Entity<Guardian>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.ContactNumber).IsUnicode(false);

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Middlename).IsUnicode(false);
            });

            modelBuilder.Entity<Medications>(entity =>
            {
                entity.Property(e => e.MedName).IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Medications)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medications_Patient");
            });

            modelBuilder.Entity<Muncity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.Barangay);

                entity.HasIndex(e => e.Muncity);

                entity.HasIndex(e => e.Province);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.ContactNumber).IsUnicode(false);

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Middlename).IsUnicode(false);

                entity.Property(e => e.Nationality).IsUnicode(false);

                entity.Property(e => e.Occupation).IsUnicode(false);

                entity.Property(e => e.Picture).IsUnicode(false);

                entity.Property(e => e.Religion).IsUnicode(false);

                entity.HasOne(d => d.BarangayNavigation)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.Barangay)
                    .HasConstraintName("FK_Patient_Barangay");

                entity.HasOne(d => d.MuncityNavigation)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.Muncity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Muncity");

                entity.HasOne(d => d.ProvinceNavigation)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.Province)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Province");
            });

            modelBuilder.Entity<Pdr>(entity =>
            {
                entity.HasIndex(e => e.Guardian);

                entity.HasIndex(e => e.Patient);

                entity.HasIndex(e => e.SymptomsContactsId);

                entity.Property(e => e.CaseNumber).IsUnicode(false);

                entity.Property(e => e.Pdrcode).IsUnicode(false);

                entity.HasOne(d => d.GuardianNavigation)
                    .WithMany(p => p.Pdr)
                    .HasForeignKey(d => d.Guardian)
                    .HasConstraintName("FK_PDRTable_Guardian");

                entity.HasOne(d => d.InterviewedByNavigation)
                    .WithMany(p => p.Pdr)
                    .HasForeignKey(d => d.InterviewedBy)
                    .HasConstraintName("FK_PDR_PDRUsers");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Pdr)
                    .HasForeignKey(d => d.Patient)
                    .HasConstraintName("FK_PDR_Patient");

                entity.HasOne(d => d.SymptomsContacts)
                    .WithMany(p => p.Pdr)
                    .HasForeignKey(d => d.SymptomsContactsId)
                    .HasConstraintName("FK_PDR_SymptomsContacts");
            });

            modelBuilder.Entity<Pdrusers>(entity =>
            {
                entity.HasIndex(e => e.Team);

                entity.Property(e => e.Designation).IsUnicode(false);

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Middlename).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Picture).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);

                entity.Property(e => e.Schedule).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.TeamNavigation)
                    .WithMany(p => p.Pdrusers)
                    .HasForeignKey(d => d.Team)
                    .HasConstraintName("FK_PDRUsers_UserTeams");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PhotoFilePath).IsUnicode(false);

                entity.Property(e => e.PhotoString).IsUnicode(false);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Qdform>(entity =>
            {
                entity.HasIndex(e => e.HealthCareBuddy);

                entity.Property(e => e.Pdrcode).IsUnicode(false);

                entity.Property(e => e.Temperature).IsUnicode(false);

                entity.HasOne(d => d.HealthCareBuddyNavigation)
                    .WithMany(p => p.QdformHealthCareBuddyNavigation)
                    .HasForeignKey(d => d.HealthCareBuddy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QDFormTable_PDRUsers");

                entity.HasOne(d => d.Pdr)
                    .WithMany(p => p.Qdform)
                    .HasForeignKey(d => d.PdrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QDForm_PDR");

                entity.HasOne(d => d.SignatureOfQdNavigation)
                    .WithMany(p => p.QdformSignatureOfQdNavigation)
                    .HasForeignKey(d => d.SignatureOfQd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QDForm_PDRUsers");
            });

            modelBuilder.Entity<Qnform>(entity =>
            {
                entity.Property(e => e.Bp).IsUnicode(false);

                entity.Property(e => e.Enumerate).IsUnicode(false);

                entity.Property(e => e.Hr).IsUnicode(false);

                entity.Property(e => e.Ivrate).IsUnicode(false);

                entity.Property(e => e.Meds).IsUnicode(false);

                entity.Property(e => e.O2sat).IsUnicode(false);

                entity.Property(e => e.PatientCode).IsUnicode(false);

                entity.Property(e => e.Rr).IsUnicode(false);

                entity.Property(e => e.TypeOfFluid).IsUnicode(false);

                entity.Property(e => e.UrineOutput).IsUnicode(false);

                entity.HasOne(d => d.Pdr)
                    .WithMany(p => p.Qnform)
                    .HasForeignKey(d => d.PdrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QNForm_PDR");

                entity.HasOne(d => d.SignatureOfQnNavigation)
                    .WithMany(p => p.Qnform)
                    .HasForeignKey(d => d.SignatureOfQn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QNForm_PDRUsers");
            });

            modelBuilder.Entity<Referral>(entity =>
            {
                entity.HasIndex(e => e.Pdrid);

                entity.HasOne(d => d.Pdr)
                    .WithMany(p => p.Referral)
                    .HasForeignKey(d => d.Pdrid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReferralTable_PDRTable");
            });

            modelBuilder.Entity<TeamSchedule>(entity =>
            {
                entity.Property(e => e.Schedule).IsUnicode(false);
            });

            modelBuilder.Entity<UserTeams>(entity =>
            {
                entity.Property(e => e.Team).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
