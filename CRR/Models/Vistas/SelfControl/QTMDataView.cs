using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas.SelfControl
{
    public class QTMDataView
    {
        #region Properties
        public int Id { get; set; }
        public string IdWorkCenter { get; set; }
        public int Value { get; set; }
        public int WeekNo { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int Shift { get; set; }
        #endregion

        #region Navigation properties
        public WorkCenterView WorkCenter { get; set; }
        #endregion
    }
}