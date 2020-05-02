using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class AddUser
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Username { get; set; }
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(255)]
        public string Firstname { get; set; }
        [StringLength(255)]
        public string Middlename { get; set; }
        [Required]
        [StringLength(255)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(255)]
        public string Role { get; set; }
        [StringLength(100)]
        public string Facility { get; set; }
        public string PhotoString { get; set; }
        public string PhotoFilePath { get; set; }
    }
}
