using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class Census
    {
        [Key]
        public int Id { get; set; }
        [Column("ODR")]
        public int Odr { get; set; }
        [Column("ODG")]
        public int Odg { get; set; }
        [Column("QD")]
        public int Qd { get; set; }
        [Column("NODA")]
        public int Noda { get; set; }
        [Column("NODB")]
        public int Nodb { get; set; }
        public int? Comorbidities { get; set; }
        public int? MayGoHome { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(Noda))]
        [InverseProperty(nameof(Pdrusers.CensusNodaNavigation))]
        public virtual Pdrusers NodaNavigation { get; set; }
        [ForeignKey(nameof(Nodb))]
        [InverseProperty(nameof(Pdrusers.CensusNodbNavigation))]
        public virtual Pdrusers NodbNavigation { get; set; }
        [ForeignKey(nameof(Odg))]
        [InverseProperty(nameof(Pdrusers.CensusOdgNavigation))]
        public virtual Pdrusers OdgNavigation { get; set; }
        [ForeignKey(nameof(Odr))]
        [InverseProperty(nameof(Pdrusers.CensusOdrNavigation))]
        public virtual Pdrusers OdrNavigation { get; set; }
        [ForeignKey(nameof(Qd))]
        [InverseProperty(nameof(Pdrusers.CensusQdNavigation))]
        public virtual Pdrusers QdNavigation { get; set; }
    }
}
