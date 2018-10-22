using CRR.Models.Vistas.SelfControl;
using CRR.Models.Vistas.Specs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas
{
    public class WorkCenterView
    {
        #region Properties
        public int TextID { get; set; }
        public string Name { get; set; }
        public string Facility { get; set; }
        public string Company { get; set; }
        public string DepartmentName { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Navigation properties
        public ICollection<FastShiftDataView> FastShiftData { get; set; }
        public ICollection<WasteDataView> WasteData { get; set; }
        public ICollection<WasteWorkCenterView> WasteWorkCenter { get; set; }
        public ICollection<QTMDataView> QTMsData { get; set; }
        public ICollection<VisualDataView> VisualData { get; set; }
        public ICollection<RunningTimeDataView> RunningTimeData { get; set; }
        #endregion
    }
}