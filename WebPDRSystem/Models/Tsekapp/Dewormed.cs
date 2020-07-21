using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Dewormed
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string Dewormed1 { get; set; }
        public DateTime? DewormedDate { get; set; }
        public int? DewormedStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
