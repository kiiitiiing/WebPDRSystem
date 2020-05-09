using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class MedOverviewModel
    {
        public int? Day { get; set; }
        [Required]
        [StringLength(255)]
        public string MedName { get; set; }
        [StringLength(50)]
        public string Comments { get; set; }
        public bool Discontinued { get; set; }
        public string Nurse { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
