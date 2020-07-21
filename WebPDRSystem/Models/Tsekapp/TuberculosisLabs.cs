using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class TuberculosisLabs
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string TbLabDone { get; set; }
        public string TbLabResult { get; set; }
        public int? TbLabStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
