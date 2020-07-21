using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Extremities
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public int? ExtreAbnormal { get; set; }
        public int? ExtreEdema { get; set; }
        public int? ExtreJoin { get; set; }
        public int? ExtreDeformity { get; set; }
        public string ExtreDeformityDescribe { get; set; }
        public int? ExtreOthers { get; set; }
        public string ExtreOthersSpecify { get; set; }
        public int? ExtreStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ExtreEnzymes { get; set; }
        public string ExtreEnzymesSpecify { get; set; }
        public int? ExtreNs { get; set; }
        public int? ExtrePcr { get; set; }
    }
}
