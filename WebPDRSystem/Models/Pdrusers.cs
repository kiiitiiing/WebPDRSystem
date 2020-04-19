using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    [Table("PDRUsers")]
    public partial class Pdrusers
    {
        public Pdrusers()
        {
            Discharge = new HashSet<Discharge>();
            Pdr = new HashSet<Pdr>();
            Qdform = new HashSet<Qdform>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [Required]
        [StringLength(255)]
        public string Firstname { get; set; }
        [StringLength(255)]
        public string Middlename { get; set; }
        [Required]
        [StringLength(255)]
        public string Lastname { get; set; }
        [StringLength(255)]
        public string Picture { get; set; }
        public int? Team { get; set; }
        [Required]
        [StringLength(255)]
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [StringLength(255)]
        public string Schedule { get; set; }

        [ForeignKey(nameof(Team))]
        [InverseProperty(nameof(UserTeams.Pdrusers))]
        public virtual UserTeams TeamNavigation { get; set; }
        [InverseProperty("HealthCareBuddyNavigation")]
        public virtual ICollection<Discharge> Discharge { get; set; }
        [InverseProperty("InterviewedByNavigation")]
        public virtual ICollection<Pdr> Pdr { get; set; }
        [InverseProperty("HealthCareBuddyNavigation")]
        public virtual ICollection<Qdform> Qdform { get; set; }
    }
}
