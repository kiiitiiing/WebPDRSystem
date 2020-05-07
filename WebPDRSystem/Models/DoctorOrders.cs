using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class DoctorOrders
    {
        [Key]
        public int Id { get; set; }
        public int PdrId { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Orders { get; set; }
        public DateTime DateOrdered { get; set; }
        [Column(TypeName = "text")]
        public string Comments { get; set; }
        public DateTime? TimePosted { get; set; }
        public int? Signature { get; set; }
        public bool Carried { get; set; }
        public bool Administered { get; set; }
        public bool RequestMade { get; set; }
        public bool Endorsed { get; set; }
        public bool Discontinued { get; set; }

        [ForeignKey(nameof(PdrId))]
        [InverseProperty("DoctorOrders")]
        public virtual Pdr Pdr { get; set; }
        [ForeignKey(nameof(Signature))]
        [InverseProperty(nameof(Pdrusers.DoctorOrders))]
        public virtual Pdrusers SignatureNavigation { get; set; }
    }
}
