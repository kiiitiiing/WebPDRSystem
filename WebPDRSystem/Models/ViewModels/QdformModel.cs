using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class QdformModel
    {
        public string PatientName { get; set; }
        [Required]
        public string Pdrcode { get; set; }
        [Required]
        public int HealthCareBuddy { get; set; }
        public bool Fever { get; set; }
        public DateTime DateChecked { get; set; }
        [StringLength(50)]
        public string Temperature { get; set; }
        public bool Cough { get; set; }
        public bool Colds { get; set; }
        public bool Breathing { get; set; }
        public bool BodyMuscleJointPain { get; set; }
        public bool Headache { get; set; }
        public bool ChestPain { get; set; }
        public bool Confusion { get; set; }
        public bool BluishLips { get; set; }
        public bool BluishFingers { get; set; }
        public int? Maintenance { get; set; }
        public bool MedsTaken { get; set; }
        public bool MentalDistress { get; set; }
        public bool SoreThroat { get; set; }
        public bool Diarrhea { get; set; }
        public string OtherDetails { get; set; }
        [Required]
        public int SignatureOfQd { get; set; }
        [Required]
        public int PdrId { get; set; }
    }
}
