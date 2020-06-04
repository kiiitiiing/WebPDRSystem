using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Models.ViewModels
{
    public class ListMeds
    {
        public string PatientName { get; set; }
        public DateTime DateTaken { get; set; }
        public int Day { get; set; }
        public List<MedModel> Meds { get; set; }
    }
}
