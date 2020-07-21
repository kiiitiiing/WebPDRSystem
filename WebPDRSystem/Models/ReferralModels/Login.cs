using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.ReferralModels
{
    public partial class Login
    {
        public uint Id { get; set; }
        public int UserId { get; set; }
        public DateTime Login1 { get; set; }
        public DateTime Logout { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
