using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Adolescent
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public DateTime? AdolSupplementation { get; set; }
        public DateTime? AdolCapsule { get; set; }
        public int? AdolStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
