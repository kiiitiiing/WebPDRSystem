using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class BronchialAsthma
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string BroConsultation { get; set; }
        public int? BroNoAttackWeek { get; set; }
        public string BroMedication { get; set; }
        public string BroMedicationYes { get; set; }
        public int? BroStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
