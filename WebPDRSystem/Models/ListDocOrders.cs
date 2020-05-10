using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class ListDocOrders
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string DoctorsOrder { get; set; }
        public bool Carried { get; set; }
        public bool Administered { get; set; }
        public bool RequestMade { get; set; }
        public bool Endorsed { get; set; }
        public bool Discontinued { get; set; }
        public int DoctorOrderId { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(DoctorOrderId))]
        [InverseProperty(nameof(DoctorOrders.ListDocOrders))]
        public virtual DoctorOrders DoctorOrder { get; set; }
    }
}
