using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class PhicMembership
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string PhicStatus { get; set; }
        public string PhicType { get; set; }
        public string PhicSponsored { get; set; }
        public string PhicSponsoredOthers { get; set; }
        public string PhicEmployed { get; set; }
        public string PhicBenefits { get; set; }
        public string PhicBenefitsYes { get; set; }
        public int? PhicStatus1 { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
