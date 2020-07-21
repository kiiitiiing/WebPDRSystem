using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class MenstrualHistory
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public int? MenstAge { get; set; }
        public DateTime? MenstDatePeriod { get; set; }
        public int? MenstDurationDays { get; set; }
        public int? MenstIntervalDays { get; set; }
        public int? MenstPads { get; set; }
        public int? MenstStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
