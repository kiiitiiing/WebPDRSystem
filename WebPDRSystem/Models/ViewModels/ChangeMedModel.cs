using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class ChangeMedModel
    {
        [Required]
        public int PatientId { get; set; }
        public string MedName { get; set; }
        [Required]
        public string NewName { get; set; }
    }
}
