using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class Migrations
    {
        public uint Id { get; set; }
        public string Migration { get; set; }
        public int Batch { get; set; }
    }
}
