using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class PasswordResets
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
