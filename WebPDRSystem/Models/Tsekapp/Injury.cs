using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Injury
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public int? InjVehicular { get; set; }
        public int? InjBurns { get; set; }
        public int? InjDrowning { get; set; }
        public int? InjFall { get; set; }
        public string InjMedications { get; set; }
        public int? InjStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
