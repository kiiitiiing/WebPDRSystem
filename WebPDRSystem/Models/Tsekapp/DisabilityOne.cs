using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class DisabilityOne
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string DisGiveDescription { get; set; }
        public int? DisOneStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
