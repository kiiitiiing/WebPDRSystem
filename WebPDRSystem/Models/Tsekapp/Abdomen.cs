using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Abdomen
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public int? AbdNoFindings { get; set; }
        public int? AbdTenderness { get; set; }
        public int? AbdPalpable { get; set; }
        public string AbdPalpableSpecify { get; set; }
        public int? AbdOthers { get; set; }
        public string AbdOthersSpecify { get; set; }
        public int? AbdStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
