using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class PersonalHistory
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public string PerSmoking { get; set; }
        public int? PerAgeStarted { get; set; }
        public int? PerAgeQuit { get; set; }
        public int? PerStickDay { get; set; }
        public int? PerPackYears { get; set; }
        public string PerHighFat { get; set; }
        public string PerFiberVegetable { get; set; }
        public string PerFiberFruits { get; set; }
        public string PerPhysicalActivity { get; set; }
        public string PerAlcohol { get; set; }
        public string PerDrugs { get; set; }
        public string PerDrugsYes { get; set; }
        public int? PerStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string PerDrunk { get; set; }
    }
}
