using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas.SelfControl
{
    public class SelfControlByShift
    {
        public int Item { get; set; }
        public SelfControlReportView Physical { get; set; }
        public SelfControlReportView Visual { get; set; }
    }
}