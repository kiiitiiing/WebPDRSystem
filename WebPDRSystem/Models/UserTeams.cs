using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class UserTeams
    {
        public UserTeams()
        {
            Pdrusers = new HashSet<Pdrusers>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Team { get; set; }

        [InverseProperty("TeamNavigation")]
        public virtual ICollection<Pdrusers> Pdrusers { get; set; }
    }
}
