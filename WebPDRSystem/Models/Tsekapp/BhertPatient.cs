using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class BhertPatient
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public int? EncodedBy { get; set; }
        public DateTime? DateOfArrival { get; set; }
        public DateTime? EndOfQuarantine { get; set; }
        public string PatientCode { get; set; }
        public string Nationality { get; set; }
        public string Purok { get; set; }
        public string Sitio { get; set; }
        public string ContactNo { get; set; }
        public string TravelHistory { get; set; }
        public string PassportNumber { get; set; }
        public string FlightNumber { get; set; }
        public string TypeQuarantine { get; set; }
        public string PlaceQuarantine { get; set; }
        public string SignSymptoms { get; set; }
        public string Remarks { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? CompletionTime { get; set; }
        public string Email { get; set; }
        public string Icd10 { get; set; }
        public string Admitted { get; set; }
        public DateTime? DateAdmission { get; set; }
        public DateTime? DateOnset { get; set; }
        public string NameCoordinator { get; set; }
        public string DscContactNumber { get; set; }
        public string Cat1 { get; set; }
        public DateTime? CatDate { get; set; }
        public string AdmittingDiagnosis { get; set; }
        public string WithFever { get; set; }
        public string WithColds { get; set; }
        public string WithCough { get; set; }
        public string WithSoreThroat { get; set; }
        public string WithDiarrhea { get; set; }
        public string WithDifficultBreathing { get; set; }
        public string ParentName { get; set; }
        public string NumberPersonLiving { get; set; }
        public DateTime? OutcomeDateDied { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? IntegrationId { get; set; }
    }
}
