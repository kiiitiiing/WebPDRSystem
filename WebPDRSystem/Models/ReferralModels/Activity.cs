using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class Activity
    {
        public uint Id { get; set; }
        public string Code { get; set; }
        public int PatientId { get; set; }
        public DateTime DateReferred { get; set; }
        public DateTime DateSeen { get; set; }
        public int ReferredFrom { get; set; }
        public int ReferredTo { get; set; }
        public int DepartmentId { get; set; }
        public int ReferringMd { get; set; }
        public int ActionMd { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
