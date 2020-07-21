using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class TuberculosisTick
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string TbTick { get; set; }
        public string TbTickSpecify { get; set; }
        public int? TbTickStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
