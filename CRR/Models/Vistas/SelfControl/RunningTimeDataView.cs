using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas.SelfControl
{
    public class RunningTimeDataView
    {
        #region Propieties
        public int Id { get; set; }
        public string IdWorkCenter { get; set; }
        public string Type { get; set; }
        public int RunningTime { get; set; }
        public int Shift { get; set; }
        public string ShiftName { get; set; }
        public int WeekNo { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        #endregion

        #region Navigation Properties
        public WorkCenterView WorkCenter { get; set; }
        #endregion
    }
}