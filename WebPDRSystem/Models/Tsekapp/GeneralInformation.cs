using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class GeneralInformation
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string DengvaxiaRecipientNo { get; set; }
        public int? Respondent { get; set; }
        public string ContactNo { get; set; }
        public string StreetName { get; set; }
        public string Sitio { get; set; }
        public string Religion { get; set; }
        public string ReligionOthers { get; set; }
        public string BirthPlace { get; set; }
        public int? YrsCurrentAddress { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
