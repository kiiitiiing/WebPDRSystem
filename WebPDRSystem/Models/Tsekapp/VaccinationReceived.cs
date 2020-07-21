using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class VaccinationReceived
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public int? VaccRecMr { get; set; }
        public int? VaccRecDiphtheria { get; set; }
        public int? VaccRecMmr { get; set; }
        public int? VaccRecHpv { get; set; }
        public int? VaccRecTetanus { get; set; }
        public int? VaccRecDoses { get; set; }
        public int? VaccRecStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
