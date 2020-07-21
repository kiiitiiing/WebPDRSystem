using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class ModeTransportation
    {
        public uint Id { get; set; }
        public string Transportation { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
