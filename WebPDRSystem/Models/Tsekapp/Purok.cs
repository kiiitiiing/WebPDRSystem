using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Purok
    {
        public uint PurokId { get; set; }
        public int? PurokCreatedBy { get; set; }
        public string PurokName { get; set; }
        public int? PurokBarangayId { get; set; }
        public int? PurokTarget { get; set; }
        public int? PurokStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
