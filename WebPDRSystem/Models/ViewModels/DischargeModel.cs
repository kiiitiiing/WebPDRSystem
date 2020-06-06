using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class DischargeModel
    {
        public int PdrId { get; set; }
        public bool Discharge { get; set; }
        public string Name { get; set; }
        [Required]
        public DateTime DischargeDate { get; set; }
    }
}
