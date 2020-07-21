using System;
using System.Collections.Generic;

namespace WebPDRSystem.Models.Tsekapp
{
    public partial class PertinentExamination
    {
        public uint Id { get; set; }
        public int? ProfileId { get; set; }
        public int? PerOrrientedTime { get; set; }
        public int? PerConscious { get; set; }
        public int? PerAmbulatory { get; set; }
        public int? PerOthers { get; set; }
        public string PerOthersSpecify { get; set; }
        public string PerBp { get; set; }
        public string PerHr { get; set; }
        public string PerRr { get; set; }
        public string PerTemp { get; set; }
        public string PerBloodType { get; set; }
        public string PerWeight { get; set; }
        public string PerHeight { get; set; }
        public string PerWaist { get; set; }
        public string PerHip { get; set; }
        public string PerRatio { get; set; }
        public int? PerSkinGood { get; set; }
        public int? PerSkinPailor { get; set; }
        public int? PerSkinJaundice { get; set; }
        public int? PerSkinRashes { get; set; }
        public int? PerSkinLession { get; set; }
        public string PerSkinLessionSpecify { get; set; }
        public string PerSkinOthers { get; set; }
        public int? PerStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
