using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class MedicalHistory
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string MhTick { get; set; }
        public string MhSpecify { get; set; }
        public int? MhStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
