using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas
{
    public class FastShiftDataView
    {
        #region Properties
        public int Id { get; set; }
        public string IdWorkcenter { get; set; }
        public string IdDepartment { get; set; }
        public string IdBrand { get; set; }
        public string FAName { get; set; }
        public decimal ProdVol { get; set; }
        public decimal TargetQty { get; set; }
        public decimal CurrentTargetQty { get; set; }
        public int OrderNo { get; set; }
        public short? OrderStatus { get; set; }
        public string CigaretteCode { get; set; }
        public string CigaretteName { get; set; }
        public DateTime RegistrationDate { get; set; }
        #endregion

        #region Navigation properties
        public WorkCenterView workCenter { get; set; }
        public BrandView brand { get; set; }
        public DepartmentView department { get; set; }
        #endregion
    }
}