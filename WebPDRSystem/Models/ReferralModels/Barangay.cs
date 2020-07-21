using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class Barangay
    {
        public uint Id { get; set; }
        public int ProvinceId { get; set; }
        public int MuncityId { get; set; }
        public string Description { get; set; }
        public int OldTarget { get; set; }
        public int Target { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
