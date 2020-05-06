using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPDRSystem.Models.ViewModels
{
    public partial class QFNOverviewModel
    {
        public Pdr PDR { get;set; }
        public List<Qnform> Qnforms { get; set; }
    }
}
