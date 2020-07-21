using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class HospitalizationHistoryOne
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string HosHospitalized { get; set; }
        public int? HosOneStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
