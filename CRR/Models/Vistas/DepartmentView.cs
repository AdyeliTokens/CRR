using CRR.Models.Vistas.Specs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas
{
    public class DepartmentView
    {
        #region Properties
        public int IdLESMES { get; set; }
        public string Name { get; set; }
        public string Facility { get; set; }
        public string Company { get; set; }
        public int CalendarID { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Navigation properties
        public ICollection<WasteDepartmentView> WasteDepartment { get; set; }
        public ICollection<FastShiftDataView> FastShiftData { get; set; }
        #endregion
    }
}