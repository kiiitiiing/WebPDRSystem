using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class Facility
    {
        public uint Id { get; set; }
        public string FacilityCode { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string Address { get; set; }
        public int Brgy { get; set; }
        public int Muncity { get; set; }
        public int Province { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string Picture { get; set; }
        public string ChiefHospital { get; set; }
        public string Level { get; set; }
        public string HospitalType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
