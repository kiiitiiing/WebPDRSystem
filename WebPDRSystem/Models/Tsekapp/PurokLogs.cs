using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class PurokLogs
    {
        public uint PurokLogsId { get; set; }
        public int? PurokId { get; set; }
        public int? PurokLogsBy { get; set; }
        public string PurokName { get; set; }
        public int? PurokBarangayId { get; set; }
        public int? PurokTarget { get; set; }
        public string PurokStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
