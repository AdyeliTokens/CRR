using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas.SelfControl
{
    public class SelfControlReportView
    {
        public string ItemName { get; set; }
        public int? Parameter{ get; set; }
        public int? Sampling { get; set; }
        public int? WorkingTime { get; set; }
        public double  Fulfillment { get; set; }
    }
}