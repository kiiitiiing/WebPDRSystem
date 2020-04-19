using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPDRSystem.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barangay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: true),
                    MuncityId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    OldTarget = table.Column<int>(nullable: false),
                    Target = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barangay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guardian",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Middlename = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Lastname = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    ContactNumber = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Barangay = table.Column<int>(nullable: true),
                    Muncity = table.Column<int>(nullable: false),
                    Province = table.Column<int>(nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardian", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muncity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muncity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PhotoString = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    PhotoFilePath = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QNForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QNForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SymptomsContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CloseContacts = table.Column<string>(nullable: true),
                    SymptomsOfPatient = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomsContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Schedule = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Middlename = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    ContactNumber = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Barangay = table.Column<int>(nullable: false),
                    Muncity = table.Column<int>(nullable: false),
                    Province = table.Column<int>(nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Occupation = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Nationality = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Religion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Picture = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Barangay",
                        column: x => x.Barangay,
                        principalTable: "Barangay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Muncity",
                        column: x => x.Muncity,
                        principalTable: "Muncity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Province",
                        column: x => x.Province,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicalParametersQN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateChecked = table.Column<DateTime>(nullable: false),
                    BP = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    HR = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    RR = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    O2Sat = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    TimeFluidStarter = table.Column<DateTime>(nullable: false),
                    TimeFluidChanged = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    UrineOutput = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    SignatureOfQN = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Meds = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Enumerate = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    DailyMonitoringFormQN_ModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalParametersQN", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicalParametersQN_QNFormTable_DailyMonitoringFormQN_ModelId",
                        column: x => x.DailyMonitoringFormQN_ModelId,
                        principalTable: "QNForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PDRUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Firstname = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Middlename = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Lastname = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Picture = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Team = table.Column<int>(nullable: false),
                    Role = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PDRUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PDRUsers_TeamSchedule",
                        column: x => x.Team,
                        principalTable: "TeamSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PDR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfAdmission = table.Column<DateTime>(nullable: false),
                    ReferringFacility = table.Column<string>(nullable: true),
                    QuarantineFacility = table.Column<string>(nullable: true),
                    CaseNumber = table.Column<int>(nullable: false),
                    BedNumber = table.Column<int>(nullable: false),
                    Patient = table.Column<int>(nullable: false),
                    Guardian = table.Column<int>(nullable: false),
                    DateTesting = table.Column<DateTime>(nullable: false),
                    Results = table.Column<string>(nullable: true),
                    History = table.Column<string>(nullable: true),
                    TravelHistory = table.Column<string>(nullable: true),
                    DateOnsetSymptoms = table.Column<DateTime>(nullable: false),
                    PreExistingConditions = table.Column<string>(nullable: true),
                    Maintenance = table.Column<string>(nullable: true),
                    FoodRestrictionsAllergy = table.Column<string>(nullable: true),
                    AdmissionTemperature = table.Column<string>(nullable: true),
                    InterviewedBy = table.Column<string>(nullable: true),
                    SymptomsContactsId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PDR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PDRTable_Guardian",
                        column: x => x.Guardian,
                        principalTable: "Guardian",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PDR_Patient",
                        column: x => x.Patient,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PDR_SymptomsContacts",
                        column: x => x.SymptomsContactsId,
                        principalTable: "SymptomsContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QDForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient = table.Column<int>(nullable: false),
                    HealthCareBuddy = table.Column<int>(nullable: false),
                    SignatureOfQD = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QDForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QDFormTable_PDRUsers",
                        column: x => x.HealthCareBuddy,
                        principalTable: "PDRUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Discharge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PDRId = table.Column<int>(nullable: false),
                    DateDischarged = table.Column<DateTime>(nullable: false),
                    HealthCareBuddy = table.Column<int>(nullable: false),
                    DischargedBy = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    DischargedApprovedBy = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    QuarantineDirectorOrOfficer = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    GuardOnDuty = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DischargeTable_PDRUsers",
                        column: x => x.HealthCareBuddy,
                        principalTable: "PDRUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DischargeTable_PDRTable",
                        column: x => x.PDRId,
                        principalTable: "PDR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Referral",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfReferral = table.Column<DateTime>(nullable: false),
                    ReferringQuarantineFacility = table.Column<string>(nullable: true),
                    ReferredTo = table.Column<string>(nullable: true),
                    PDRId = table.Column<int>(nullable: false),
                    PertinentFindings = table.Column<string>(nullable: true),
                    Diagnosis = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    ReferredBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferralTable_PDRTable",
                        column: x => x.PDRId,
                        principalTable: "PDR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicalParametersQD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateChecked = table.Column<DateTime>(nullable: true),
                    NoSymptom = table.Column<bool>(nullable: false),
                    Fever = table.Column<bool>(nullable: false),
                    Temperature = table.Column<bool>(nullable: true),
                    Cough = table.Column<bool>(nullable: false),
                    Colds = table.Column<bool>(nullable: false),
                    Breathing = table.Column<bool>(nullable: false),
                    BodyMuscleJointPain = table.Column<bool>(nullable: false),
                    Headache = table.Column<bool>(nullable: false),
                    ChestPain = table.Column<bool>(nullable: false),
                    Confusion = table.Column<bool>(nullable: false),
                    BluishLipsOrFingers = table.Column<bool>(nullable: false),
                    Maintenance = table.Column<bool>(nullable: false),
                    MedsTaken = table.Column<bool>(nullable: false),
                    MentalDistress = table.Column<bool>(nullable: false),
                    DailyMonitoringFormQD_ModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalParametersQD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicalParametersQD_QDFormTable_DailyMonitoringFormQD_ModelId",
                        column: x => x.DailyMonitoringFormQD_ModelId,
                        principalTable: "QDForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalParametersQD_DailyMonitoringFormQD_ModelId",
                table: "ClinicalParametersQD",
                column: "DailyMonitoringFormQD_ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalParametersQN_DailyMonitoringFormQN_ModelId",
                table: "ClinicalParametersQN",
                column: "DailyMonitoringFormQN_ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Discharge_HealthCareBuddy",
                table: "Discharge",
                column: "HealthCareBuddy");

            migrationBuilder.CreateIndex(
                name: "IX_Discharge_PDRId",
                table: "Discharge",
                column: "PDRId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Barangay",
                table: "Patient",
                column: "Barangay");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Muncity",
                table: "Patient",
                column: "Muncity");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Province",
                table: "Patient",
                column: "Province");

            migrationBuilder.CreateIndex(
                name: "IX_PDR_Guardian",
                table: "PDR",
                column: "Guardian");

            migrationBuilder.CreateIndex(
                name: "IX_PDR_Patient",
                table: "PDR",
                column: "Patient");

            migrationBuilder.CreateIndex(
                name: "IX_PDR_SymptomsContactsId",
                table: "PDR",
                column: "SymptomsContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_PDRUsers_Team",
                table: "PDRUsers",
                column: "Team");

            migrationBuilder.CreateIndex(
                name: "IX_QDForm_HealthCareBuddy",
                table: "QDForm",
                column: "HealthCareBuddy");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_PDRId",
                table: "Referral",
                column: "PDRId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicalParametersQD");

            migrationBuilder.DropTable(
                name: "ClinicalParametersQN");

            migrationBuilder.DropTable(
                name: "Discharge");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Referral");

            migrationBuilder.DropTable(
                name: "QDForm");

            migrationBuilder.DropTable(
                name: "QNForm");

            migrationBuilder.DropTable(
                name: "PDR");

            migrationBuilder.DropTable(
                name: "PDRUsers");

            migrationBuilder.DropTable(
                name: "Guardian");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "SymptomsContacts");

            migrationBuilder.DropTable(
                name: "TeamSchedule");

            migrationBuilder.DropTable(
                name: "Barangay");

            migrationBuilder.DropTable(
                name: "Muncity");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
