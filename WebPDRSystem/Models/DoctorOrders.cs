using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class DoctorOrders
    {
        /*public DoctorOrders()5
        {
            ListDocOrders = new HashSet<ListDocOrders>();
        }*/

        [Key]
        public int Id { get; set; }
        public int PdrId { get; set; }
        public DateTime DateOrdered { get; set; }
        [Column(TypeName = "text")]
        public string Comments { get; set; }
        public DateTime? TimePosted { get; set; }
        public int? Signature { get; set; }

        [ForeignKey(nameof(PdrId))]
        [InverseProperty("DoctorOrders")]
        public virtual Pdr Pdr { get; set; }
        [ForeignKey(nameof(Signature))]
        [InverseProperty(nameof(Pdrusers.DoctorOrders))]
        public virtual Pdrusers SignatureNavigation { get; set; }
        [InverseProperty("DoctorOrder")]
        public virtual List<ListDocOrders> ListDocOrders { get; set; }
    }
}
