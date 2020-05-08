using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class QnformModel
    {
        [Required]
        public int Day { get; set; }
        public string PatientCode { get; set; }
        public string Patientname { get; set; }
        [Required]
        public int SignatureOfQn { get; set; }
        [Required]
        public DateTime DateChecked { get; set; }
        [StringLength(255)]
        public string Bp { get; set; }
        [StringLength(255)]
        public string Hr { get; set; }
        [StringLength(255)]
        public string Rr { get; set; }
        [StringLength(255)]
        public string O2sat { get; set; }
        [StringLength(255)]
        public string TypeOfFluid { get; set; }
        [StringLength(255)]
        public string Ivrate { get; set; }
        public DateTime? TimeFluidStarted { get; set; }
        public DateTime? TimeFluidChanged { get; set; }
        [StringLength(255)]
        public string UrineOutput { get; set; }
        [StringLength(255)]
        public string Meds { get; set; }
        [StringLength(255)]
        public string Enumerate { get; set; }
        [Required]
        public int PdrId { get; set; }
        [DataType(DataType.Text)]
        public string OtherDetails { get; set; }
        public string Temperature { get; set; }
        public int PatientId { get; set; }
    }
}
