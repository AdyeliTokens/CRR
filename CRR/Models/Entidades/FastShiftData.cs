using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Entidades
{
    public class FastShiftData
    {
        #region Properties
        public int Id { get; set; }
        public string IdWorkcenter { get; set; }
        public string IdDepartment { get; set; }
        public string IdBrand { get; set; }
        public string FAName { get; set; }
        public double ProdVol { get; set; }
        public double TargetQty { get; set; }
        public double CurrentTargetQty { get; set; }
        public int OrderNo { get; set; }
        public short? OrderStatus { get; set; }
        public string CigaretteCode { get; set; }
        public string CigaretteName { get; set; }
        public DateTime RegistrationDate { get; set; }
        #endregion

        #region Navigation properties
        public WorkCenter WorkCenter { get; set; }
        public Brand Brand { get; set; }
        public Department Department { get; set; }
        #endregion
    }
}