using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class HospitalizationHistory
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string HosReason { get; set; }
        public DateTime? HosDate { get; set; }
        public string HosPlace { get; set; }
        public string HosPhic { get; set; }
        public string HosCost { get; set; }
        public int? HosStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
