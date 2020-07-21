using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Sitio
    {
        public uint SitioId { get; set; }
        public int? SitioCreatedBy { get; set; }
        public string SitioName { get; set; }
        public int? SitioBarangayId { get; set; }
        public int? SitioTarget { get; set; }
        public int? SitioStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
