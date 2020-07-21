using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Heent
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string HeentTick { get; set; }
        public string HeentOthers { get; set; }
        public int? HeentStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
