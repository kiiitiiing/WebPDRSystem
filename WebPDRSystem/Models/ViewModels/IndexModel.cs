using System;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class IndexModel
    {
        public int BedNumber { get; set; }
        public string PatientName { get; set; }
        public string PatientAge { get; set; }
        public string PatientSex { get; set; }
        public DateTime DateAdmitted { get; set; }
        public Qnform MonitoringFormQN { get; set; }
        public Qdform MonitoringFormQD { get; set; }
        public string Diagnosis { get; set; }
    }
}
