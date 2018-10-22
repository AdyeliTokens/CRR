using CRR.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas.CRR
{
    public class CRRByWorkCenterView
    {
        public WorkCenter workCenter { get; set; }
        public List<CRRReportView> Values { get; set; }
    }
}