using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas.SelfControl
{
    public class SelfControlByDepartment
    {
        public string Item { get; set; }
        public List<SelfControlByShift> Shift { get; set; }
    }
}