using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class ProfileDevice
    {
        public uint Id { get; set; }
        public string ProfileId { get; set; }
        public string Device { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
