using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class ChestAndLungs
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public int? ChestNoFindings { get; set; }
        public int? ChestRetractions { get; set; }
        public int? ChestCrackles { get; set; }
        public int? ChestWheezes { get; set; }
        public int? ChestBreast { get; set; }
        public int? ChestOthers { get; set; }
        public string ChestOthersSpecify { get; set; }
        public int? ChestStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
