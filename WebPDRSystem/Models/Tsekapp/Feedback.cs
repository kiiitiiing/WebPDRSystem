using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Feedback
    {
        public uint Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
