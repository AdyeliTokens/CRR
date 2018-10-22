using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRR.Models.Entidades.Specs
{
    public class SelfControlSpecs
    {
        #region Properties
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Value { get; set; }
        public string UM { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Navigation properties
        #endregion
    }
}