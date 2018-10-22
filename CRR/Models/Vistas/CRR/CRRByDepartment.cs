using CRR.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas.CRR
{
    public class CRRByDepartment
    {
        public Department Department { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
        public List<CRRReportView> Values { get; set; }
    }
}