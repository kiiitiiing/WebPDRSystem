using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Heart
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public int? HeartNoFindings { get; set; }
        public int? HeartPulse { get; set; }
        public int? HeartCyanosis { get; set; }
        public int? HeartMurmur { get; set; }
        public string HeartMurmurSpecify { get; set; }
        public int? HeartOthers { get; set; }
        public string HeartOthersSpecify { get; set; }
        public int? HeartStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
