using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Tuberculosis
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string TbDiagnosed { get; set; }
        public string TbDiagnosedYes { get; set; }
        public int? TbCat1 { get; set; }
        public int? TbCat2 { get; set; }
        public int? TbCat3 { get; set; }
        public int? TbCat4 { get; set; }
        public int? TbStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? TbPpd { get; set; }
        public string TbResultPpd { get; set; }
        public int? TbSputumExam { get; set; }
        public string TbResultEputumExam { get; set; }
        public int? TbCxr { get; set; }
        public string TbResultCxr { get; set; }
        public int? TbGenxpert { get; set; }
        public string TbResultGenxpert { get; set; }
    }
}
