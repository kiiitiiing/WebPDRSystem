using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class GyneHistory
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string GyneDescription { get; set; }
        public string GyneSpecify { get; set; }
        public int? GyneStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
