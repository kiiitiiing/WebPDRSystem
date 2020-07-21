using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class FamilyHistory
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string FhTick { get; set; }
        public string FhSpecify { get; set; }
        public int? FhStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
