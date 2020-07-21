using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class IntegrationPatient
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public int? IntegrationId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
