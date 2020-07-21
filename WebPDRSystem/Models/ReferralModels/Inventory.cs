using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class Inventory
    {
        public uint Id { get; set; }
        public int FacilityId { get; set; }
        public int EncodedBy { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Occupied { get; set; }
        public int Available { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
