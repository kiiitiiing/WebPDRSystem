using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class PastSurgicalHistory
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string SurOperation { get; set; }
        public DateTime? SurDate { get; set; }
        public int? SurStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
