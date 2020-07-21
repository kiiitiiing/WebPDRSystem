using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class Feedback
    {
        public uint Id { get; set; }
        public string Code { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
