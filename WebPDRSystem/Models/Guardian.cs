using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class Guardian
    {
        public Guardian()
        {
            Pdr = new HashSet<Pdr>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Firstname { get; set; }
        [StringLength(255)]
        public string Middlename { get; set; }
        [Required]
        [StringLength(255)]
        public string Lastname { get; set; }
        [StringLength(255)]
        public string ContactNumber { get; set; }
        public int? Barangay { get; set; }
        public int Muncity { get; set; }
        public int Province { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [InverseProperty("GuardianNavigation")]
        public virtual ICollection<Pdr> Pdr { get; set; }
    }
}
