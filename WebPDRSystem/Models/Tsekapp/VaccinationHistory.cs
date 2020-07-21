using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class VaccinationHistory
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public int? VaccDengCount { get; set; }
        public DateTime? VaccDate { get; set; }
        public string VaccPlace { get; set; }
        public int? VaccStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
