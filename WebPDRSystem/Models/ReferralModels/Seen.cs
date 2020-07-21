using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class Seen
    {
        public uint Id { get; set; }
        public int TrackingId { get; set; }
        public int FacilityId { get; set; }
        public int UserMd { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
