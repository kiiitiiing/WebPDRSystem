using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class tsekap_mainContext : DbContext
    {
        public tsekap_mainContext()
        {
        }

        public tsekap_mainContext(DbContextOptions<tsekap_mainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abdomen> Abdomen { get; set; }
        public virtual DbSet<Adolescent> Adolescent { get; set; }
        public virtual DbSet<Barangay> Barangay { get; set; }
        public virtual DbSet<BhertPatient> BhertPatient { get; set; }
        public virtual DbSet<Brackets> Brackets { get; set; }
        public virtual DbSet<Bracketservices> Bracketservices { get; set; }
        public virtual DbSet<BronchialAsthma> BronchialAsthma { get; set; }
        public virtual DbSet<Cases> Cases { get; set; }
        public virtual DbSet<ChestAndLungs> ChestAndLungs { get; set; }
        public virtual DbSet<Dewormed> Dewormed { get; set; }
        public virtual DbSet<Disability> Disability { get; set; }
        public virtual DbSet<DisabilityOne> DisabilityOne { get; set; }
        public virtual DbSet<Extremities> Extremities { get; set; }
        public virtual DbSet<FamilyHistory> FamilyHistory { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<GeneralInformation> GeneralInformation { get; set; }
        public virtual DbSet<GyneHistory> GyneHistory { get; set; }
        public virtual DbSet<Heart> Heart { get; set; }
        public virtual DbSet<Heent> Heent { get; set; }
        public virtual DbSet<HospitalizationHistory> HospitalizationHistory { get; set; }
        public virtual DbSet<HospitalizationHistoryOne> HospitalizationHistoryOne { get; set; }
        public virtual DbSet<Injury> Injury { get; set; }
        public virtual DbSet<Integration> Integration { get; set; }
        public virtual DbSet<IntegrationPatient> IntegrationPatient { get; set; }
        public virtual DbSet<MedicalHistory> MedicalHistory { get; set; }
        public virtual DbSet<MenstrualHistory> MenstrualHistory { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<Muncity> Muncity { get; set; }
        public virtual DbSet<OtherProcedure> OtherProcedure { get; set; }
        public virtual DbSet<PasswordResets> PasswordResets { get; set; }
        public virtual DbSet<PastSurgicalHistory> PastSurgicalHistory { get; set; }
        public virtual DbSet<PersonalHistory> PersonalHistory { get; set; }
        public virtual DbSet<PertinentExamination> PertinentExamination { get; set; }
        public virtual DbSet<PhicMembership> PhicMembership { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<ProfileDevice> ProfileDevice { get; set; }
        public virtual DbSet<ProfilePending> ProfilePending { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Purok> Purok { get; set; }
        public virtual DbSet<PurokLogs> PurokLogs { get; set; }
        public virtual DbSet<ReviewSystem> ReviewSystem { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Sitio> Sitio { get; set; }
        public virtual DbSet<SitioLogs> SitioLogs { get; set; }
        public virtual DbSet<Tuberculosis> Tuberculosis { get; set; }
        public virtual DbSet<TuberculosisLabs> TuberculosisLabs { get; set; }
        public virtual DbSet<TuberculosisTick> TuberculosisTick { get; set; }
        public virtual DbSet<UpdateProfileLogs> UpdateProfileLogs { get; set; }
        public virtual DbSet<Userbrgy> Userbrgy { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VaccinationHistory> VaccinationHistory { get; set; }
        public virtual DbSet<VaccinationReceived> VaccinationReceived { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=192.168.10.121;user id=root;password=deb;database=tsekap_main", x => x.ServerVersion("10.3.8-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abdomen>(entity =>
            {
                entity.ToTable("abdomen");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AbdNoFindings)
                    .HasColumnName("abd_no_findings")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AbdOthers)
                    .HasColumnName("abd_others")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AbdOthersSpecify)
                    .HasColumnName("abd_others_specify")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.AbdPalpable)
                    .HasColumnName("abd_palpable")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AbdPalpableSpecify)
                    .HasColumnName("abd_palpable_specify")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.AbdStatus)
                    .HasColumnName("abd_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AbdTenderness)
                    .HasColumnName("abd_tenderness")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Adolescent>(entity =>
            {
                entity.ToTable("adolescent");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AdolCapsule)
                    .HasColumnName("adol_capsule")
                    .HasColumnType("date");

                entity.Property(e => e.AdolStatus)
                    .HasColumnName("adol_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdolSupplementation)
                    .HasColumnName("adol_supplementation")
                    .HasColumnType("date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Barangay>(entity =>
            {
                entity.ToTable("barangay");

                entity.HasIndex(e => e.Description)
                    .HasName("description");

                entity.HasIndex(e => new { e.ProvinceId, e.MuncityId, e.OldTarget })
                    .HasName("province_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.MuncityId)
                    .HasColumnName("muncity_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OldTarget)
                    .HasColumnName("old_target")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Target)
                    .HasColumnName("target")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<BhertPatient>(entity =>
            {
                entity.ToTable("bhert_patient");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Admitted)
                    .HasColumnName("admitted")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.AdmittingDiagnosis)
                    .HasColumnName("admitting_diagnosis")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Cat1)
                    .HasColumnName("cat1")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.CatDate)
                    .HasColumnName("cat_date")
                    .HasColumnType("date");

                entity.Property(e => e.CompletionTime)
                    .HasColumnName("completion_time")
                    .HasColumnType("time");

                entity.Property(e => e.ContactNo)
                    .HasColumnName("contact_no")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.DateAdmission)
                    .HasColumnName("date_admission")
                    .HasColumnType("date");

                entity.Property(e => e.DateOfArrival)
                    .HasColumnName("date_of_arrival")
                    .HasColumnType("date");

                entity.Property(e => e.DateOnset)
                    .HasColumnName("date_onset")
                    .HasColumnType("date");

                entity.Property(e => e.DscContactNumber)
                    .HasColumnName("dsc_contact_number")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.EncodedBy)
                    .HasColumnName("encoded_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EndOfQuarantine)
                    .HasColumnName("end_of_quarantine")
                    .HasColumnType("date");

                entity.Property(e => e.FlightNumber)
                    .HasColumnName("flight_number")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Icd10)
                    .HasColumnName("icd_10")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IntegrationId)
                    .HasColumnName("integration_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.NameCoordinator)
                    .HasColumnName("name_coordinator")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Nationality)
                    .HasColumnName("nationality")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.NumberPersonLiving)
                    .HasColumnName("number_person_living")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.OutcomeDateDied)
                    .HasColumnName("outcome_date_died")
                    .HasColumnType("date");

                entity.Property(e => e.ParentName)
                    .HasColumnName("parent_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PassportNumber)
                    .HasColumnName("passport_number")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PatientCode)
                    .HasColumnName("patient_code")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PlaceQuarantine)
                    .HasColumnName("place_quarantine")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Purok)
                    .HasColumnName("purok")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.SignSymptoms)
                    .HasColumnName("sign_symptoms")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Sitio)
                    .HasColumnName("sitio")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("time");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TravelHistory)
                    .HasColumnName("travel_history")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TypeQuarantine)
                    .HasColumnName("type_quarantine")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.WithColds)
                    .HasColumnName("with_colds")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.WithCough)
                    .HasColumnName("with_cough")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.WithDiarrhea)
                    .HasColumnName("with_diarrhea")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.WithDifficultBreathing)
                    .HasColumnName("with_difficult_breathing")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.WithFever)
                    .HasColumnName("with_fever")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.WithSoreThroat)
                    .HasColumnName("with_sore_throat")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Brackets>(entity =>
            {
                entity.ToTable("brackets");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Bracketservices>(entity =>
            {
                entity.ToTable("bracketservices");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BracketId)
                    .HasColumnName("bracket_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("service_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<BronchialAsthma>(entity =>
            {
                entity.ToTable("bronchial_asthma");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BroConsultation)
                    .HasColumnName("bro_consultation")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.BroMedication)
                    .HasColumnName("bro_medication")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.BroMedicationYes)
                    .HasColumnName("bro_medication_yes")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.BroNoAttackWeek)
                    .HasColumnName("bro_no_attack_week")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BroStatus)
                    .HasColumnName("bro_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Cases>(entity =>
            {
                entity.ToTable("cases");

                entity.HasIndex(e => e.Description)
                    .HasName("description");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<ChestAndLungs>(entity =>
            {
                entity.ToTable("chest_and_lungs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ChestBreast)
                    .HasColumnName("chest_breast")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ChestCrackles)
                    .HasColumnName("chest_crackles")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ChestNoFindings)
                    .HasColumnName("chest_no_findings")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ChestOthers)
                    .HasColumnName("chest_others")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ChestOthersSpecify)
                    .HasColumnName("chest_others_specify")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ChestRetractions)
                    .HasColumnName("chest_retractions")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ChestStatus)
                    .HasColumnName("chest_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ChestWheezes)
                    .HasColumnName("chest_wheezes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Dewormed>(entity =>
            {
                entity.ToTable("dewormed");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Dewormed1)
                    .HasColumnName("dewormed")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.DewormedDate)
                    .HasColumnName("dewormed_date")
                    .HasColumnType("date");

                entity.Property(e => e.DewormedStatus)
                    .HasColumnName("dewormed_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Disability>(entity =>
            {
                entity.ToTable("disability");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.DisNeedAssistive)
                    .HasColumnName("dis_need_assistive")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.DisNeedAssistiveYes)
                    .HasColumnName("dis_need_assistive_yes")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.DisStatus)
                    .HasColumnName("dis_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DisTick)
                    .HasColumnName("dis_tick")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.DisWithAssistive)
                    .HasColumnName("dis_with_assistive")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.DisWithAssistiveYes)
                    .HasColumnName("dis_with_assistive_yes")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<DisabilityOne>(entity =>
            {
                entity.ToTable("disability_one");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.DisGiveDescription)
                    .HasColumnName("dis_give_description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.DisOneStatus)
                    .HasColumnName("dis_one_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Extremities>(entity =>
            {
                entity.ToTable("extremities");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ExtreAbnormal)
                    .HasColumnName("extre_abnormal")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExtreDeformity)
                    .HasColumnName("extre_deformity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExtreDeformityDescribe)
                    .HasColumnName("extre_deformity_describe")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ExtreEdema)
                    .HasColumnName("extre_edema")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExtreEnzymes)
                    .HasColumnName("extre_enzymes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExtreEnzymesSpecify)
                    .HasColumnName("extre_enzymes_specify")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ExtreJoin)
                    .HasColumnName("extre_join")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExtreNs)
                    .HasColumnName("extre_ns")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExtreOthers)
                    .HasColumnName("extre_others")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExtreOthersSpecify)
                    .HasColumnName("extre_others_specify")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ExtrePcr)
                    .HasColumnName("extre_pcr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExtreStatus)
                    .HasColumnName("extre_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<FamilyHistory>(entity =>
            {
                entity.ToTable("family_history");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.FhSpecify)
                    .HasColumnName("fh_specify")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.FhStatus)
                    .HasColumnName("fh_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FhTick)
                    .HasColumnName("fh_tick")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<GeneralInformation>(entity =>
            {
                entity.ToTable("general_information");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BirthPlace)
                    .HasColumnName("birth_place")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ContactNo)
                    .HasColumnName("contact_no")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.DengvaxiaRecipientNo)
                    .HasColumnName("dengvaxia_recipient_no")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Religion)
                    .HasColumnName("religion")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ReligionOthers)
                    .HasColumnName("religion_others")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Respondent)
                    .HasColumnName("respondent")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sitio)
                    .HasColumnName("sitio")
                    .HasColumnType("varchar(121)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StreetName)
                    .HasColumnName("street_name")
                    .HasColumnType("varchar(121)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.YrsCurrentAddress)
                    .HasColumnName("yrs_current_address")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<GyneHistory>(entity =>
            {
                entity.ToTable("gyne_history");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.GyneDescription)
                    .HasColumnName("gyne_description")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.GyneSpecify)
                    .HasColumnName("gyne_specify")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.GyneStatus)
                    .HasColumnName("gyne_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Heart>(entity =>
            {
                entity.ToTable("heart");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.HeartCyanosis)
                    .HasColumnName("heart_cyanosis")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HeartMurmur)
                    .HasColumnName("heart_murmur")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HeartMurmurSpecify)
                    .HasColumnName("heart_murmur_specify")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.HeartNoFindings)
                    .HasColumnName("heart_no_findings")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HeartOthers)
                    .HasColumnName("heart_others")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HeartOthersSpecify)
                    .HasColumnName("heart_others_specify")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.HeartPulse)
                    .HasColumnName("heart_pulse")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HeartStatus)
                    .HasColumnName("heart_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Heent>(entity =>
            {
                entity.ToTable("heent");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.HeentOthers)
                    .HasColumnName("heent_others")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.HeentStatus)
                    .HasColumnName("heent_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HeentTick)
                    .HasColumnName("heent_tick")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<HospitalizationHistory>(entity =>
            {
                entity.ToTable("hospitalization_history");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.HosCost)
                    .HasColumnName("hos_cost")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.HosDate)
                    .HasColumnName("hos_date")
                    .HasColumnType("date");

                entity.Property(e => e.HosPhic)
                    .HasColumnName("hos_phic")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.HosPlace)
                    .HasColumnName("hos_place")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.HosReason)
                    .HasColumnName("hos_reason")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.HosStatus)
                    .HasColumnName("hos_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<HospitalizationHistoryOne>(entity =>
            {
                entity.ToTable("hospitalization_history_one");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.HosHospitalized)
                    .HasColumnName("hos_hospitalized")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.HosOneStatus)
                    .HasColumnName("hos_one_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Injury>(entity =>
            {
                entity.ToTable("injury");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.InjBurns)
                    .HasColumnName("inj_burns")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InjDrowning)
                    .HasColumnName("inj_drowning")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InjFall)
                    .HasColumnName("inj_fall")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InjMedications)
                    .HasColumnName("inj_medications")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.InjStatus)
                    .HasColumnName("inj_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InjVehicular)
                    .HasColumnName("inj_vehicular")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Integration>(entity =>
            {
                entity.ToTable("integration");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.System)
                    .HasColumnName("system")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UserPriv)
                    .HasColumnName("user_priv")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IntegrationPatient>(entity =>
            {
                entity.ToTable("integration_patient");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.IntegrationId)
                    .HasColumnName("integration_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<MedicalHistory>(entity =>
            {
                entity.ToTable("medical_history");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.MhSpecify)
                    .HasColumnName("mh_specify")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.MhStatus)
                    .HasColumnName("mh_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MhTick)
                    .HasColumnName("mh_tick")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<MenstrualHistory>(entity =>
            {
                entity.ToTable("menstrual_history");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.MenstAge)
                    .HasColumnName("menst_age")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MenstDatePeriod)
                    .HasColumnName("menst_date_period")
                    .HasColumnType("date");

                entity.Property(e => e.MenstDurationDays)
                    .HasColumnName("menst_duration_days")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MenstIntervalDays)
                    .HasColumnName("menst_interval_days")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MenstPads)
                    .HasColumnName("menst_pads")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MenstStatus)
                    .HasColumnName("menst_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("migrations");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Muncity>(entity =>
            {
                entity.ToTable("muncity");

                entity.HasIndex(e => e.Description)
                    .HasName("description");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<OtherProcedure>(entity =>
            {
                entity.ToTable("other_procedure");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.FhStatus)
                    .HasColumnName("fh_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OtherIgg)
                    .HasColumnName("other_igg")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OtherIgm)
                    .HasColumnName("other_igm")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OtherTick)
                    .HasColumnName("other_tick")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<PasswordResets>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("password_resets");

                entity.HasIndex(e => e.Email)
                    .HasName("password_resets_email_index");

                entity.HasIndex(e => e.Token)
                    .HasName("password_resets_token_index");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<PastSurgicalHistory>(entity =>
            {
                entity.ToTable("past_surgical_history");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SurDate)
                    .HasColumnName("sur_date")
                    .HasColumnType("date");

                entity.Property(e => e.SurOperation)
                    .HasColumnName("sur_operation")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.SurStatus)
                    .HasColumnName("sur_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<PersonalHistory>(entity =>
            {
                entity.ToTable("personal_history");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.PerAgeQuit)
                    .HasColumnName("per_age_quit")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerAgeStarted)
                    .HasColumnName("per_age_started")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerAlcohol)
                    .HasColumnName("per_alcohol")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerDrugs)
                    .HasColumnName("per_drugs")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerDrugsYes)
                    .HasColumnName("per_drugs_yes")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerDrunk)
                    .HasColumnName("per_drunk")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerFiberFruits)
                    .HasColumnName("per_fiber_fruits")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerFiberVegetable)
                    .HasColumnName("per_fiber_vegetable")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerHighFat)
                    .HasColumnName("per_high_fat")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerPackYears)
                    .HasColumnName("per_pack_years")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerPhysicalActivity)
                    .HasColumnName("per_physical_activity")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerSmoking)
                    .HasColumnName("per_smoking")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerStatus)
                    .HasColumnName("per_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerStickDay)
                    .HasColumnName("per_stick_day")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<PertinentExamination>(entity =>
            {
                entity.ToTable("pertinent_examination");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.PerAmbulatory)
                    .HasColumnName("per_ambulatory")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerBloodType)
                    .HasColumnName("per_blood_type")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerBp)
                    .HasColumnName("per_bp")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerConscious)
                    .HasColumnName("per_conscious")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerHeight)
                    .HasColumnName("per_height")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerHip)
                    .HasColumnName("per_hip")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerHr)
                    .HasColumnName("per_hr")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerOrrientedTime)
                    .HasColumnName("per_orriented_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerOthers)
                    .HasColumnName("per_others")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerOthersSpecify)
                    .HasColumnName("per_others_specify")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerRatio)
                    .HasColumnName("per_ratio")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerRr)
                    .HasColumnName("per_rr")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerSkinGood)
                    .HasColumnName("per_skin_good")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerSkinJaundice)
                    .HasColumnName("per_skin_jaundice")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerSkinLession)
                    .HasColumnName("per_skin_lession")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerSkinLessionSpecify)
                    .HasColumnName("per_skin_lession_specify")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerSkinOthers)
                    .HasColumnName("per_skin_others")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerSkinPailor)
                    .HasColumnName("per_skin_pailor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerSkinRashes)
                    .HasColumnName("per_skin_rashes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerStatus)
                    .HasColumnName("per_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerTemp)
                    .HasColumnName("per_temp")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerWaist)
                    .HasColumnName("per_waist")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PerWeight)
                    .HasColumnName("per_weight")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<PhicMembership>(entity =>
            {
                entity.ToTable("phic_membership");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.PhicBenefits)
                    .HasColumnName("phic_benefits")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PhicBenefitsYes)
                    .HasColumnName("phic_benefits_yes")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PhicEmployed)
                    .HasColumnName("phic_employed")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PhicSponsored)
                    .HasColumnName("phic_sponsored")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PhicSponsoredOthers)
                    .HasColumnName("phic_sponsored_others")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PhicStatus)
                    .HasColumnName("phic_status")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PhicStatus1)
                    .HasColumnName("phic_status1")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PhicType)
                    .HasColumnName("phic_type")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profile");

                entity.HasIndex(e => e.BarangayId)
                    .HasName("barangay_id");

                entity.HasIndex(e => e.FamilyId)
                    .HasName("familyID");

                entity.HasIndex(e => e.MuncityId)
                    .HasName("muncity_id");

                entity.HasIndex(e => e.ProvinceId)
                    .HasName("province_id");

                entity.HasIndex(e => e.Suffix)
                    .HasName("suffix");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("unique_id")
                    .IsUnique();

                entity.HasIndex(e => new { e.Head, e.Fname, e.Lname, e.Sex })
                    .HasName("head");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BarangayId)
                    .HasColumnName("barangay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Dengvaxia)
                    .IsRequired()
                    .HasColumnName("dengvaxia")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Diabetic)
                    .IsRequired()
                    .HasColumnName("diabetic")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Education)
                    .IsRequired()
                    .HasColumnName("education")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FamilyId)
                    .IsRequired()
                    .HasColumnName("familyID")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Head)
                    .IsRequired()
                    .HasColumnName("head")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Hypertension)
                    .IsRequired()
                    .HasColumnName("hypertension")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Income)
                    .HasColumnName("income")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasColumnName("mname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.MuncityId)
                    .HasColumnName("muncity_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NhtsId)
                    .IsRequired()
                    .HasColumnName("nhtsID")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PhicId)
                    .IsRequired()
                    .HasColumnName("phicID")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Pregnant)
                    .HasColumnName("pregnant")
                    .HasColumnType("date");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurokId)
                    .HasColumnName("purok_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasColumnName("pwd")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Relation)
                    .IsRequired()
                    .HasColumnName("relation")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasColumnName("sex")
                    .HasColumnType("char(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.SitioId)
                    .HasColumnName("sitio_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Suffix)
                    .IsRequired()
                    .HasColumnName("suffix")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Toilet)
                    .IsRequired()
                    .HasColumnName("toilet")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasColumnName("unique_id")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Unmet)
                    .HasColumnName("unmet")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Water)
                    .HasColumnName("water")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<ProfileDevice>(entity =>
            {
                entity.ToTable("profile_device");

                entity.HasIndex(e => e.ProfileId)
                    .HasName("profile_device_profile_id_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Device)
                    .IsRequired()
                    .HasColumnName("device")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProfileId)
                    .IsRequired()
                    .HasColumnName("profile_id")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<ProfilePending>(entity =>
            {
                entity.ToTable("profile_pending");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BarangayId)
                    .HasColumnName("barangay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Dengvaxia)
                    .HasColumnName("dengvaxia")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Diabetic)
                    .HasColumnName("diabetic")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Education)
                    .HasColumnName("education")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.FamilyId)
                    .HasColumnName("familyID")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Head)
                    .HasColumnName("head")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Hypertension)
                    .HasColumnName("hypertension")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Income)
                    .HasColumnName("income")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Mname)
                    .HasColumnName("mname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.MuncityId)
                    .HasColumnName("muncity_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NhtsId)
                    .HasColumnName("nhtsID")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PhicId)
                    .HasColumnName("phicID")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Pregnant)
                    .HasColumnName("pregnant")
                    .HasColumnType("date");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurokId)
                    .HasColumnName("purok_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Relation)
                    .HasColumnName("relation")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.SitioId)
                    .HasColumnName("sitio_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Toilet)
                    .HasColumnName("toilet")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("unique_id")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Unmet)
                    .HasColumnName("unmet")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Water)
                    .HasColumnName("water")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("province");

                entity.HasIndex(e => e.Description)
                    .HasName("description");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Purok>(entity =>
            {
                entity.ToTable("purok");

                entity.Property(e => e.PurokId)
                    .HasColumnName("purok_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.PurokBarangayId)
                    .HasColumnName("purok_barangay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurokCreatedBy)
                    .HasColumnName("purok_created_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurokName)
                    .HasColumnName("purok_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PurokStatus)
                    .HasColumnName("purok_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurokTarget)
                    .HasColumnName("purok_target")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<PurokLogs>(entity =>
            {
                entity.ToTable("purok_logs");

                entity.Property(e => e.PurokLogsId)
                    .HasColumnName("purok_logs_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.PurokBarangayId)
                    .HasColumnName("purok_barangay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurokId)
                    .HasColumnName("purok_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurokLogsBy)
                    .HasColumnName("purok_logs_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurokName)
                    .HasColumnName("purok_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PurokStatus)
                    .HasColumnName("purok_status")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PurokTarget)
                    .HasColumnName("purok_target")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<ReviewSystem>(entity =>
            {
                entity.ToTable("review_system");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RevOthers)
                    .HasColumnName("rev_others")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.RevStatus)
                    .HasColumnName("rev_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RevTick)
                    .HasColumnName("rev_tick")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sessions");

                entity.HasIndex(e => e.Id)
                    .HasName("sessions_id_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("id")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.LastActivity)
                    .HasColumnName("last_activity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Payload)
                    .IsRequired()
                    .HasColumnName("payload")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UserAgent)
                    .HasColumnName("user_agent")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Sitio>(entity =>
            {
                entity.ToTable("sitio");

                entity.Property(e => e.SitioId)
                    .HasColumnName("sitio_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.SitioBarangayId)
                    .HasColumnName("sitio_barangay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SitioCreatedBy)
                    .HasColumnName("sitio_created_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SitioName)
                    .HasColumnName("sitio_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.SitioStatus)
                    .HasColumnName("sitio_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SitioTarget)
                    .HasColumnName("sitio_target")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<SitioLogs>(entity =>
            {
                entity.ToTable("sitio_logs");

                entity.Property(e => e.SitioLogsId)
                    .HasColumnName("sitio_logs_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.SitioBarangayId)
                    .HasColumnName("sitio_barangay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SitioId)
                    .HasColumnName("sitio_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SitioLogsBy)
                    .HasColumnName("sitio_logs_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SitioName)
                    .HasColumnName("sitio_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.SitioStatus)
                    .HasColumnName("sitio_status")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.SitioTarget)
                    .HasColumnName("sitio_target")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Tuberculosis>(entity =>
            {
                entity.ToTable("tuberculosis");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbCat1)
                    .HasColumnName("tb_cat1")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbCat2)
                    .HasColumnName("tb_cat2")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbCat3)
                    .HasColumnName("tb_cat3")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbCat4)
                    .HasColumnName("tb_cat4")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbCxr)
                    .HasColumnName("tb_cxr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbDiagnosed)
                    .HasColumnName("tb_diagnosed")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TbDiagnosedYes)
                    .HasColumnName("tb_diagnosed_yes")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TbGenxpert)
                    .HasColumnName("tb_genxpert")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbPpd)
                    .HasColumnName("tb_ppd")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbResultCxr)
                    .HasColumnName("tb_result_cxr")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TbResultEputumExam)
                    .HasColumnName("tb_result_eputum_exam")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TbResultGenxpert)
                    .HasColumnName("tb_result_genxpert")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TbResultPpd)
                    .HasColumnName("tb_result_ppd")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TbSputumExam)
                    .HasColumnName("tb_sputum_exam")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbStatus)
                    .HasColumnName("tb_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<TuberculosisLabs>(entity =>
            {
                entity.ToTable("tuberculosis_labs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbLabDone)
                    .HasColumnName("tb_lab_done")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TbLabResult)
                    .HasColumnName("tb_lab_result")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TbLabStatus)
                    .HasColumnName("tb_lab_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<TuberculosisTick>(entity =>
            {
                entity.ToTable("tuberculosis_tick");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbTick)
                    .HasColumnName("tb_tick")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TbTickSpecify)
                    .HasColumnName("tb_tick_specify")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TbTickStatus)
                    .HasColumnName("tb_tick_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<UpdateProfileLogs>(entity =>
            {
                entity.ToTable("update_profile_logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BarangayId)
                    .HasColumnName("barangay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Diabetic)
                    .HasColumnName("diabetic")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Education)
                    .HasColumnName("education")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.FamilyId)
                    .HasColumnName("familyId")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Head)
                    .HasColumnName("head")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Hypertension)
                    .HasColumnName("hypertension")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Income)
                    .HasColumnName("income")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Mname)
                    .HasColumnName("mname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.MuncityId)
                    .HasColumnName("muncity_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NhtsId)
                    .HasColumnName("nhtsID")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PhicId)
                    .HasColumnName("phicID")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Pregnant)
                    .HasColumnName("pregnant")
                    .HasColumnType("date");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Relation)
                    .HasColumnName("relation")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Toilet)
                    .HasColumnName("toilet")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("unique_id")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Unmet)
                    .HasColumnName("unmet")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Water)
                    .HasColumnName("water")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Userbrgy>(entity =>
            {
                entity.ToTable("userbrgy");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BarangayId)
                    .HasColumnName("barangay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Username)
                    .HasName("users_username_unique")
                    .IsUnique();

                entity.HasIndex(e => new { e.Fname, e.Lname, e.Muncity, e.UserPriv })
                    .HasName("fname");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnName("contact")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ContactNo)
                    .HasColumnName("contact_no")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasColumnName("mname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Muncity)
                    .HasColumnName("muncity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Pin)
                    .HasColumnName("pin")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TypeRdu)
                    .HasColumnName("type_rdu")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UserPriv).HasColumnName("user_priv");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<VaccinationHistory>(entity =>
            {
                entity.ToTable("vaccination_history");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.VaccDate)
                    .HasColumnName("vacc_date")
                    .HasColumnType("date");

                entity.Property(e => e.VaccDengCount)
                    .HasColumnName("vacc_deng_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VaccPlace)
                    .HasColumnName("vacc_place")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.VaccStatus)
                    .HasColumnName("vacc_status")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<VaccinationReceived>(entity =>
            {
                entity.ToTable("vaccination_received");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.VaccRecDiphtheria)
                    .HasColumnName("vacc_rec_diphtheria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VaccRecDoses)
                    .HasColumnName("vacc_rec_doses")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VaccRecHpv)
                    .HasColumnName("vacc_rec_hpv")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VaccRecMmr)
                    .HasColumnName("vacc_rec_mmr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VaccRecMr)
                    .HasColumnName("vacc_rec_mr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VaccRecStatus)
                    .HasColumnName("vacc_rec_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VaccRecTetanus)
                    .HasColumnName("vacc_rec_tetanus")
                    .HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
