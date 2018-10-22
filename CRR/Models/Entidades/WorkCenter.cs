using CRR.Models.Entidades.SelfControl;
using CRR.Models.Entidades.Specs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Entidades
{
    public class WorkCenter
    {
        #region Properties
        [Key, Required, MaxLength(11), Display(Name = "IdWorkCenter")]
        public string Name { get; set; }
        public int TextID { get; set; }
        public string Facility { get; set; }
        public string Company { get; set; }
        public string DepartmentName { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Navigation properties
        public ICollection<FastShiftData> FastShiftData { get; set; }
        public ICollection<WasteData> WasteData { get; set; }
        public ICollection<WasteWorkCenter> WasteWorkCenter { get; set; }
        public ICollection<QTMData> QTMsData { get; set; }
        public ICollection<VisualData> VisualData { get; set; }
        public ICollection<RunningTimeData> RunningTimeData { get; set; }
        #endregion
    }
}