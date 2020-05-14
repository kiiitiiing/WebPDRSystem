using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class PatientMeds
    {
        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public string Medication { get; set; }
        public bool Discontinued { get; set; }
    }
}
