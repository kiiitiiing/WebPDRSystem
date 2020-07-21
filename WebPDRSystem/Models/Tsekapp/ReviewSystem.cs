using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class ReviewSystem
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string RevTick { get; set; }
        public string RevOthers { get; set; }
        public int? RevStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
