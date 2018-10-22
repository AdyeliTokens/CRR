using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Entidades
{
    public class Brand
    {
        #region Properties
        [Key, Required, MaxLength(11), Display(Name = "FA")]
        public string CodeFA { get; set; }
        public string Description { get; set; }
        public string CigaretteCode { get; set; }
        public double CigaretteWeight { get; set; }
        public double TobaccoWeight { get; set; }
        public string VeinCode { get; set; }
        public double CigaretteCost { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Navigation properties
        public ICollection<FastShiftData> FastShiftData { get; set; }
        public ICollection<WasteData> WasteData { get; set; }
        #endregion
    }
}