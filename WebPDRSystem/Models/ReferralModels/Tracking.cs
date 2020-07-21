using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class Tracking
    {
        public uint Id { get; set; }
        public string Code { get; set; }
        public int PatientId { get; set; }
        public DateTime DateReferred { get; set; }
        public DateTime DateTransferred { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateArrived { get; set; }
        public DateTime DateSeen { get; set; }
        public string ModeTransportation { get; set; }
        public int ReferredFrom { get; set; }
        public int ReferredTo { get; set; }
        public int DepartmentId { get; set; }
        public int ReferringMd { get; set; }
        public int ActionMd { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Walkin { get; set; }
        public int FormId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
