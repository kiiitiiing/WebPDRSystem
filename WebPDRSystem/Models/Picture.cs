using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class Picture
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string PhotoString { get; set; }
        [Required]
        [StringLength(255)]
        public string PhotoFilePath { get; set; }
    }
}
