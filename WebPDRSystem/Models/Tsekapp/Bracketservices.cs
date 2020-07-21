using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Bracketservices
    {
        public uint Id { get; set; }
        public int BracketId { get; set; }
        public int ServiceId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
