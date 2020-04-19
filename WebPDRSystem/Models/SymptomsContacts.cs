using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class SymptomsContacts
    {
        public SymptomsContacts()
        {
            Pdr = new HashSet<Pdr>();
        }

        [Key]
        public int Id { get; set; }
        public string CloseContacts { get; set; }
        public string SymptomsOfPatient { get; set; }

        [InverseProperty("SymptomsContacts")]
        public virtual ICollection<Pdr> Pdr { get; set; }
    }
}
