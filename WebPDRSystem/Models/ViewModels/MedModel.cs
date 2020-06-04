using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class MedModel
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public DateTime TimeTaken { get; set; }
        [Required]
        public string MedName { get; set; }
        public string Comments { get; set; }
        [Required]
        public int NurseId { get; set; }
        public bool Discontinued { get; set; }
    }
}
