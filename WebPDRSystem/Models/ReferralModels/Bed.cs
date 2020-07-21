using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class Bed
    {
        public uint Id { get; set; }
        public int FacilityId { get; set; }
        public int EncodedBy { get; set; }
        public string Name { get; set; }
        public string Temporary { get; set; }
        public int AllowableNo { get; set; }
        public int ActualNo { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
