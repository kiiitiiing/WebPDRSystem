using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Disability
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string DisTick { get; set; }
        public string DisWithAssistive { get; set; }
        public string DisWithAssistiveYes { get; set; }
        public string DisNeedAssistive { get; set; }
        public string DisNeedAssistiveYes { get; set; }
        public int? DisStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
