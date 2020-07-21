using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class Patients
    {
        public uint Id { get; set; }
        public string UniqueId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public DateTime Dob { get; set; }
        public string Sex { get; set; }
        public string CivilStatus { get; set; }
        public string PhicId { get; set; }
        public string PhicStatus { get; set; }
        public int Brgy { get; set; }
        public int Muncity { get; set; }
        public int Province { get; set; }
        public string Address { get; set; }
        public int TsekapPatient { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
