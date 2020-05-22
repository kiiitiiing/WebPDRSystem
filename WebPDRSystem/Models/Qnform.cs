using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    [Table("QNForm")]
    public partial class Qnform
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string PatientCode { get; set; }
        [Column("SignatureOfQN")]
        public int SignatureOfQn { get; set; }
        public DateTime DateChecked { get; set; }
        public int Day { get; set; }
        [Column("BP")]
        [StringLength(255)]
        public string Bp { get; set; }
        [Column("HR")]
        [StringLength(255)]
        public string Hr { get; set; }
        [Column("RR")]
        [StringLength(255)]
        public string Rr { get; set; }
        [Column("O2Sat")]
        [StringLength(255)]
        public string O2sat { get; set; }
        [StringLength(50)]
        public string Temperature { get; set; }
        [StringLength(255)]
        public string TypeOfFluid { get; set; }
        [Column("IVRate")]
        [StringLength(255)]
        public string Ivrate { get; set; }
        public DateTime? TimeFluidStarted { get; set; }
        public DateTime? TimeFluidChanged { get; set; }
        [StringLength(255)]
        public string UrineOutput { get; set; }
        [Column("HGT")]
        [StringLength(255)]
        public string Hgt { get; set; }
        public int PdrId { get; set; }
        [StringLength(255)]
        public string Intake { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(PdrId))]
        [InverseProperty("Qnform")]
        public virtual Pdr Pdr { get; set; }
        [ForeignKey(nameof(SignatureOfQn))]
        [InverseProperty(nameof(Pdrusers.Qnform))]
        public virtual Pdrusers SignatureOfQnNavigation { get; set; }
    }
}
