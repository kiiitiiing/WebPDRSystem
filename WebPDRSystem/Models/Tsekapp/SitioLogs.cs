using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class SitioLogs
    {
        public uint SitioLogsId { get; set; }
        public int? SitioId { get; set; }
        public int? SitioLogsBy { get; set; }
        public string SitioName { get; set; }
        public int? SitioBarangayId { get; set; }
        public int? SitioTarget { get; set; }
        public string SitioStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
