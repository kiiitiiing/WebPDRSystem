using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class TeamSchedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Schedule { get; set; }
    }
}
