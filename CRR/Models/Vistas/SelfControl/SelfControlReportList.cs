using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas.SelfControl
{
    public class SelfControlReportList
    {
        public string Item { get; set; }
        public string DayofWeek { get; set; }
        public DateTime Date { get; set; }
        public List<SelfControlByShift> Shift { get; set; }
    }
}