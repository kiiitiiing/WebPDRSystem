using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class DashboardModel
    {
        public int TotalCensus { get; set; }
        public int CurrBedOccupancy { get; set; }
        public int TotalBedOccupancy { get; set; }
        public double BedOccupancyPecentage { get { return (CurrBedOccupancy / TotalBedOccupancy) * 100; } }
        public int MayGoHome { get; set; }
        public string ODR { get; set; }
        public string ODG { get; set; }
        public string QOD { get; set; }
        public string NODA { get; set; }
        public string NODB { get; set; }
    }
}
