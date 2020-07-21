using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class ProfilePending
    {
        public uint Id { get; set; }
        public string UniqueId { get; set; }
        public string FamilyId { get; set; }
        public string PhicId { get; set; }
        public string NhtsId { get; set; }
        public string Head { get; set; }
        public string Relation { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Suffix { get; set; }
        public DateTime? Dob { get; set; }
        public string Sex { get; set; }
        public int? SitioId { get; set; }
        public int? PurokId { get; set; }
        public int? BarangayId { get; set; }
        public int? MuncityId { get; set; }
        public int? ProvinceId { get; set; }
        public int? Income { get; set; }
        public int? Unmet { get; set; }
        public int? Water { get; set; }
        public string Toilet { get; set; }
        public string Education { get; set; }
        public string Hypertension { get; set; }
        public string Diabetic { get; set; }
        public string Pwd { get; set; }
        public DateTime? Pregnant { get; set; }
        public string Dengvaxia { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
