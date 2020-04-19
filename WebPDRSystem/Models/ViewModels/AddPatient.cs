using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class AddPatient
    {
        public int CaseNumber { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public int BedNumber { get; set; }
        public string ReferringFacility { get; set; }
        public string QuarantineFacility { get; set; }
        //Patient info
        public string PFirstname { get; set; }
        public string PMiddlename { get; set; }
        public string PLastname { get; set; }
        public DateTime PDateOfBirth { get; set; }
        public bool PGender { get; set; }
        public string PContactNumber { get; set; }
        public string PPicture { get; set; }
        public int PBarangay { get; set; }
        public int PMuncity { get; set; }
        public int PProvince { get; set; }
        public string PAddress { get; set; }
        public string POccupation { get; set; }
        public string PNationality { get; set; }
        public string PReligion { get; set; }
        //Guardian
        public string GFirstname { get; set; }
        public string GMiddlename { get; set; }
        public string GLastname { get; set; }
        public string GContactNumber { get; set; }
        public int GProvince { get; set; }
        public int GMuncity { get; set; }
        public int GBarangay { get; set; }
        public string GAddress { get; set; }    
        //Other
        public DateTime DateTesting { get; set; }
        public string Results { get; set; }
        public string CloseContacts { get; set; }
        public string History { get; set; }
        public string TravelHistory { get; set; }
        public DateTime DateOnsetSymptoms { get; set; }
        public string AdmissionTemperature { get; set; }
        public string PreExistingConditions { get; set; }
        public string Maintenance { get; set; }
        public string FoodRestrictionsAllergy { get; set; }
        public string SymptomsOfPatient { get; set; }
        public int InterviewedBy { get; set; }
    }
}
