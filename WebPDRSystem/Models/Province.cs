using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class Province
    {
        public Province()
        {
            Guardian = new HashSet<Guardian>();
            Patient = new HashSet<Patient>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("ProvinceNavigation")]
        public virtual ICollection<Guardian> Guardian { get; set; }
        [InverseProperty("ProvinceNavigation")]
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
