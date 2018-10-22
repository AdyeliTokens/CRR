using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas.Specs
{
    public class WasteWorkCenterView
    {
        #region Properties
        public int Id { get; set; }
        public string IdWorkCenter { get; set; }
        public double Value { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Navigation properties
        public WorkCenterView workCenter { get; set; }
        #endregion
    }
}