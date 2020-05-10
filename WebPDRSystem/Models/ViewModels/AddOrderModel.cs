using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class AddOrderModel
    {
        public string CaseNumber { get; set; }
        [Required]
        public int PdrId { get; set; }
        [Required]
        public string Order { get; set; }
        [Required]
        public DateTime DateOrdered { get; set; }
        public DateTime TimePosted { get; set; }
        public string Comments { get; set; }
    }
}
