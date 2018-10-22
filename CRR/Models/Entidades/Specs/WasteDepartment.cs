using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRR.Models.Entidades.Specs
{
    public class WasteDepartment
    {
        #region Properties
        public int Id { get; set; }
        public string IdDepartment { get; set; }
        public double Value { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Navigation properties
        public Department Department { get; set; }
        #endregion
    }
}