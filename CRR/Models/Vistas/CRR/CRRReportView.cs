using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas.CRR
{
    public class CRRReportView
    {
        public string ItemName { get; set; }
        public string FAName { get; set; }
        public double? CRR { get; set; }
        public double? VolumenProduccion { get; set; }
        public double? VolumenWaste { get; set; }
        public double Specs { get; set; }
        public double? PorcentajeVolumen { get; set; }
    }
}