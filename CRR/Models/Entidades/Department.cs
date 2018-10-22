using CRR.Models.Entidades.Specs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Entidades
{
    public class Department
    {
        #region Properties
        public int IdLESMES { get; set; }
        [Key, Required, MaxLength(11), Display(Name = "Department")]
        public string Name { get; set; }
        public string Facility { get; set; }
        public string Company { get; set; }
        public int CalendarID { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Navigation properties
        public ICollection<WasteDepartment> WasteDepartment { get; set; }
        public ICollection<FastShiftData> FastShiftData { get; set; }
        #endregion

    }
}