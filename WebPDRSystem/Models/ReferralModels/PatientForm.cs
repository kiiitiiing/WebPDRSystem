using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class PatientForm
    {
        public uint Id { get; set; }
        public string UniqueId { get; set; }
        public string Code { get; set; }
        public int ReferringFacility { get; set; }
        public int ReferredTo { get; set; }
        public int DepartmentId { get; set; }
        public DateTime TimeReferred { get; set; }
        public DateTime TimeTransferred { get; set; }
        public int PatientId { get; set; }
        public string CaseSummary { get; set; }
        public string RecoSummary { get; set; }
        public string Diagnosis { get; set; }
        public string Reason { get; set; }
        public int ReferringMd { get; set; }
        public int ReferredMd { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
