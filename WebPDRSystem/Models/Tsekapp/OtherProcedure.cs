using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class OtherProcedure
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string OtherTick { get; set; }
        public int? OtherIgg { get; set; }
        public int? OtherIgm { get; set; }
        public int? FhStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
