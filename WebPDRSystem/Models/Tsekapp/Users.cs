using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class Users
    {
        public uint Id { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public int Muncity { get; set; }
        public int Province { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public bool UserPriv { get; set; }
        public string RememberToken { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string TypeRdu { get; set; }
        public string Pin { get; set; }
    }
}
